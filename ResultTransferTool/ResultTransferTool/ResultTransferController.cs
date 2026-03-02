using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Nlogger;
using ResultTransferTool.Exception;
using ResultTransferTool.FolderTranscation;
using ResultTransferTool.TransferTranscation;
using ResultTransferTool.TransferTranscation.ResultsXmlFormat;
using FileMode = ResultTransferTool.TransferTranscation.FileMode;

namespace ResultTransferTool
{
    public class ResultTransferController
    {
        private readonly FileRemover _backupFileRemover;
        private readonly FileRemover _errorFileRemover;
        private readonly FolderMonitor _folderMonitor;
        private CancellationTokenSource _cs = new CancellationTokenSource();
        protected Task TransferTask;
        private readonly object _syncObject = new object();
        private readonly ResultXmlParser _resultReader = new ResultXmlParser();
        private readonly MTSResultUpdater _mtsResultUpdater = new MTSResultUpdater();
        private readonly AutoResetEvent _signalEvent = new AutoResetEvent(false);
        private bool _mtsTransferStatus;

        //12/28/2020 Adam add for cancel task when netwok is disconnected
        //public Action<string> OnPopupMessage;
        public ResultTransferController(string monitorFolderPath)
        {
            _backupFileRemover = new FileRemover(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ResultsBackUpCache"));
            _errorFileRemover = new FileRemover(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ResultsErrorCache"));
            _folderMonitor = new FolderMonitor(monitorFolderPath);
            _signalEvent.Reset();
        }

        public virtual void Run()
        {
            lock (_syncObject)
            {
                _cs = new CancellationTokenSource();
                var token = _cs.Token;
                TransferTask = Task.Run(() =>
                {
                    MonitorFolder();
                }, token);
            }
        }

        public void Interrupt()
        {
            Debug.WriteLine("Interrupt Monitor.");
            _cs.Cancel();
            LogManager.GetLogger("SQL Controller").Info("Thread is interrupted");
        }

        public Task RunningTransferTask => TransferTask;

        public Action<List<MonitoredFileInfo>> OnFolderChecked;

        public delegate bool IsCallerClosed();

        public IsCallerClosed IsCallerClosedDelegate;
        public bool NeedToInsertSN = false;
        public bool NeedToTransferToMTS = false;
        public bool IgnoreMTS = false;

        private void MonitorFolder()
        {
            while (true)
            {
                if (IsCallerClosedDelegate != null && IsCallerClosedDelegate())
                {
                    throw new CallerClosedException();
                }
                //12/29/2020 Adam add for check the local network
                if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    //if (OnPopupMessage != null)
                    //{                        
                    //    OnPopupMessage.Invoke("The network is disconnected,please check the network and then restart the transfer tool.");
                    //}
                  throw new System.Exception("The network is disconnected,please check the network and then restart the transfer tool.");
                }


                _mtsTransferStatus = true;
                var files = _folderMonitor.CheckFolder("*.dat");

                if (files.Count == 0)
                {
                    OnFolderChecked?.Invoke(files);
                }

                MonitoredFileInfo fileReadyToTransfer = null;
                try
                {
                    fileReadyToTransfer = files.First(x => x.Status == MonitoredFileStatus.Sleeping);
                }
                catch (System.Exception)
                {
                    try
                    {
                        fileReadyToTransfer = files.First(x => x.Status == MonitoredFileStatus.TransferError);

                    }
                    catch (System.Exception)
                    {
                        //ignore
                    }
                }

                if (fileReadyToTransfer != null)
                {
                    fileReadyToTransfer.Status = MonitoredFileStatus.Transferring;
                    OnFolderChecked?.Invoke(files);
                    if (_resultReader.GetTestResultType(fileReadyToTransfer.FileInfo.FullName, FileMode.Encryptor) == TestType.PimRlIso)
                    {
                        // The year that PIM RLISO only
                        var result = _resultReader.GetPimOrRlIsoTestResult(fileReadyToTransfer.FileInfo.FullName, FileMode.Encryptor);
                        MtsProcess(result, fileReadyToTransfer);
                        TriggerPimRlIsoTransferProcess(fileReadyToTransfer, NeedToInsertSN || result.Flag.InsertSN, result.Head.Factory == "Reynosa");
                    }
                    else
                    {
                        // Intergrate other tests
                        TriggerSqlTransferProcess(fileReadyToTransfer);
                    }
                }
                Thread.Sleep(2000);
            }
            // ReSharper disable once FunctionNeverReturns
        }

        private void TriggerSqlTransferProcess(MonitoredFileInfo fileReadyToTransfer)
        {
            LogManager.GetLogger("SQL Controller").Info($"Start to transfer file {fileReadyToTransfer.FileInfo.Name}");
            var filePath = fileReadyToTransfer.FileInfo.FullName;
            Debug.WriteLine($"Start transfer file ({filePath})");
            try
            {
                var transfer = new TransferToCatsManager();
                transfer.Start(filePath, FileMode.Encryptor);
                MoveResultFile(filePath, true);
                var staticManager = new TransferStatics();
                LogManager.GetLogger("SQL Controller").Info("Write successful static item");
                staticManager.InsertSuccessfulFileInfo(fileReadyToTransfer.FileInfo.Name, transfer.TimeCost);
                staticManager.TransferStaticFileToServerImmediately();

            }
            catch (ResultXmlParserException e)
            {
                //12/29/2020 Adam add for network disconnected
                if (fileReadyToTransfer.DisconnectedLog.Any())
                {
                    fileReadyToTransfer.DisconnectedLog.Clear();
                }

                Debug.WriteLine("Catch exception: " + e.Message);
                MoveResultFile(filePath, false);
                InsertFailureStatics(fileReadyToTransfer.FileInfo.Name, e.Message);
                throw;
            }
            catch (ResultFormatVersionNotSupportedException e)
            {
                //12/29/2020 Adam add for network disconnected
                if (fileReadyToTransfer.DisconnectedLog.Any())
                {
                    fileReadyToTransfer.DisconnectedLog.Clear();
                }

                Debug.WriteLine("Catch exception: " + e.Message);
                MoveResultFile(filePath, false);
                InsertFailureStatics(fileReadyToTransfer.FileInfo.Name, e.Message);
                throw;
            }
            catch (SqlTransferExceptionWithoutRetry e)
            {
                //12/29/2020 Adam add for network disconnected
                if (fileReadyToTransfer.DisconnectedLog.Any())
                {
                    fileReadyToTransfer.DisconnectedLog.Clear();
                }

                Debug.WriteLine("Catch exception: " + e.Message);
                MoveResultFile(filePath, false);
                InsertFailureStatics(fileReadyToTransfer.FileInfo.Name, e.Message);
                throw;
            }
            catch (SqlTransferException e)
            {
                Debug.WriteLine("Catch exception: " + e.Message);
                fileReadyToTransfer.Status = MonitoredFileStatus.TransferError;
                fileReadyToTransfer.ErrorRetryCount += 1;
                var now = DateTime.Now;

                fileReadyToTransfer.FileInfo.LastAccessTime = now;
                #region 12/29/2020 Adam add for network disconnected
                //if (fileReadyToTransfer.ErrorRetryCount > 5)
                //{
                //    MoveResultFile(filePath, false);
                //}
                if (!fileReadyToTransfer.DisconnectedLog.Any())
                {
                    fileReadyToTransfer.DisconnectedLog.Add(now.Date, 1);
                }
                else
                {
                    var maxValue = fileReadyToTransfer.DisconnectedLog.OrderByDescending(i => i.Key).First();
                    if (maxValue.Key == now.Date)
                    {
                        fileReadyToTransfer.DisconnectedLog[maxValue.Key] += 1;
                        if (fileReadyToTransfer.DisconnectedLog[maxValue.Key] >= 3)
                        {
                            if (fileReadyToTransfer.DisconnectedLog.Count >= 3)
                            {
                                _signalEvent.WaitOne(5000);
                                MoveResultFile(filePath, false, _mtsTransferStatus);
                            }
                        }
                    }
                    else
                    {
                        if (fileReadyToTransfer.DisconnectedLog.Count >= 3)
                        {
                            _signalEvent.WaitOne(5000);
                            MoveResultFile(filePath, false, _mtsTransferStatus);
                        }
                        else
                        {
                            fileReadyToTransfer.DisconnectedLog.Add(now.Date, 1);
                        }

                    }
                }
                #endregion
                InsertFailureStatics(fileReadyToTransfer.FileInfo.Name, e.Message);
                throw;
            }
            catch (System.Exception e)
            {
                //12/29/2020 Adam add for network disconnected
                if (fileReadyToTransfer.DisconnectedLog.Any())
                {
                    fileReadyToTransfer.DisconnectedLog.Clear();
                }

                Debug.WriteLine("Catch exception: " + e.Message);
                fileReadyToTransfer.Status = MonitoredFileStatus.TransferError;
                MoveResultFile(filePath, false);
                InsertFailureStatics(fileReadyToTransfer.FileInfo.Name, e.Message);
                throw;
            }
            LogManager.GetLogger("SQL Controller").Info($"Finish to transfer file {fileReadyToTransfer.FileInfo.Name}");
            Debug.WriteLine($"END transfer file ({filePath})");
        }

        private void MtsProcess(TestResultTemplate result, MonitoredFileInfo fileReadyToTransfer)
        {
            if (!IgnoreMTS)
            {
                if (NeedToTransferToMTS || result.Flag.TransferToMTS)
                {
                    Task.Run(() =>
                    {
                        try
                        {
                            _mtsResultUpdater.Run(fileReadyToTransfer.FileInfo.FullName, result);
                            _mtsTransferStatus = true;
                            _signalEvent.Set();
                        }
                        catch
                        {
                            _mtsTransferStatus = false;
                            _signalEvent.Set();
                        }
                    });
                }
                else
                {
                    _signalEvent.Set();
                }
            }
            else
            {
                _signalEvent.Set();
            }
        }

        private void TriggerPimRlIsoTransferProcess(MonitoredFileInfo preparedFile, bool needToInsertSN, bool isReynosa = false)
        {
            LogManager.GetLogger("SQL Controller").Info($"Start to transfer file {preparedFile.FileInfo.Name}");
            var filePath = preparedFile.FileInfo.FullName;
            Debug.WriteLine($"Start transfer file ({filePath})");
            try
            {
                var transfer = new PimRlIsoSqlTransferManager();
                transfer.Start(filePath, FileMode.Encryptor, needToInsertSN);
                _signalEvent.WaitOne(5000);
                MoveResultFile(filePath, true, _mtsTransferStatus);
                var staticManager = new TransferStatics();
                LogManager.GetLogger("SQL Controller").Info("Write successful static item");
                staticManager.InsertSuccessfulFileInfo(preparedFile.FileInfo.Name, transfer.TimeCost);
                if (isReynosa)
                {
                    LogManager.GetLogger("SQL Controller").Info("Skip to write static item");
                }
                else
                {
                    staticManager.TransferStaticFileToServerImmediately();
                }
            }
            catch (ResultXmlParserException e)
            {
                //12/29/2020 Adam add for network disconnected
                if (preparedFile.DisconnectedLog.Any())
                {
                    preparedFile.DisconnectedLog.Clear();
                }

                Debug.WriteLine("Catch exception: " + e.Message);
                _signalEvent.WaitOne(5000);
                MoveResultFile(filePath, false, _mtsTransferStatus);
                InsertFailureStatics(preparedFile.FileInfo.Name, e.Message);
                throw;
            }
            catch (ResultFormatVersionNotSupportedException e)
            {
                //12/29/2020 Adam add for network disconnected
                if (preparedFile.DisconnectedLog.Any())
                {
                    preparedFile.DisconnectedLog.Clear();
                }

                Debug.WriteLine("Catch exception: " + e.Message);
                _signalEvent.WaitOne(5000);
                MoveResultFile(filePath, false, _mtsTransferStatus);
                InsertFailureStatics(preparedFile.FileInfo.Name, e.Message);
                throw;
            }
            catch (SqlTransferExceptionWithoutRetry e)
            {
                //12/29/2020 Adam add for network disconnected
                if (preparedFile.DisconnectedLog.Any())
                {
                    preparedFile.DisconnectedLog.Clear();
                }

                Debug.WriteLine("Catch exception: " + e.Message);
                _signalEvent.WaitOne(5000);
                MoveResultFile(filePath, false, _mtsTransferStatus);
                InsertFailureStatics(preparedFile.FileInfo.Name, e.Message);
                throw;
            }
            catch (SqlTransferException e)
            {
                Debug.WriteLine("Catch exception: " + e.Message);

                var now = DateTime.Now;
                preparedFile.Status = MonitoredFileStatus.TransferError;
                preparedFile.ErrorRetryCount += 1;
                preparedFile.FileInfo.LastAccessTime = now;
                #region 12/29/2020 Adam add for network disconnected
                if (preparedFile.ErrorRetryCount > 5)
                {
                    _signalEvent.WaitOne(5000);
                    MoveResultFile(filePath, false, _mtsTransferStatus);
                }

                //if (!preparedFile.DisconnectedLog.Any())
                //{
                //    preparedFile.DisconnectedLog.Add(now.Date, 1);
                //}
                //else
                //{
                //    var maxValue = preparedFile.DisconnectedLog.OrderByDescending(i => i.Key).First();
                //    if (maxValue.Key == now.Date)
                //    {
                //        if (preparedFile.DisconnectedLog[maxValue.Key] >= 3)
                //        {
                //            if (preparedFile.DisconnectedLog.Count >= 3)
                //            {
                //                _signalEvent.WaitOne(5000);
                //                MoveResultFile(filePath, false, _mtsTransferStatus);
                //            }
                //        }
                //        else
                //        {
                //            preparedFile.DisconnectedLog[maxValue.Key] += 1;
                //        }
                //    }
                //    else
                //    {
                //        if (preparedFile.DisconnectedLog.Count >= 3)
                //        {
                //            _signalEvent.WaitOne(5000);
                //            MoveResultFile(filePath, false, _mtsTransferStatus);
                //        }
                //        else
                //        {
                //            preparedFile.DisconnectedLog.Add(now.Date, 1);
                //        }

                //    }
                //}

                #endregion
                InsertFailureStatics(preparedFile.FileInfo.Name, e.Message);
                throw;
            }
            catch (System.Exception e)
            {
                //12/29/2020 Adam add for network disconnected
                if (preparedFile.DisconnectedLog.Any())
                {
                    preparedFile.DisconnectedLog.Clear();
                }

                Debug.WriteLine("Catch exception: " + e.Message);
                preparedFile.Status = MonitoredFileStatus.TransferError;
                MoveResultFile(filePath, false);
                InsertFailureStatics(preparedFile.FileInfo.Name, e.Message);
                throw;
            }
            LogManager.GetLogger("SQL Controller").Info($"Finish to transfer file {preparedFile.FileInfo.Name}");
            Debug.WriteLine($"END transfer file ({filePath})");
        }

        private void InsertFailureStatics(string fileName, string msg)
        {
            var staticManager = new TransferStatics();
            LogManager.GetLogger("SQL Controller").Info("Write failure static item");
            staticManager.InsertFailFileInfo(fileName, msg);
            staticManager.TransferStaticFileToServerImmediately();
        }

        private void MoveResultFile(string filePath, bool sqlStatus, bool mtsStatus)
        {
            if (sqlStatus && mtsStatus)
            {
                _backupFileRemover.MoveFile(filePath);
            }
            else
            {
                _errorFileRemover.MoveFile(filePath);
            }
        }

        private void MoveResultFile(string filePath, bool sqlStatus)
        {
            if (sqlStatus)
            {
                _backupFileRemover.MoveFile(filePath);
            }
            else
            {
                _errorFileRemover.MoveFile(filePath);
            }
        }
        //12/29/2020 Adam add for check the local network
        public void StopTask()
        {
            _cs.Dispose();
        }
    }
}
