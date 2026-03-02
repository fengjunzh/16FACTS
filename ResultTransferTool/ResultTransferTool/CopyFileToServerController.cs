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

namespace ResultTransferTool
{
    public class CopyFileToServerController
    {
        private readonly FileRemover _backupFileRemover;
        private readonly FileRemover _errorFileRemover;
        private readonly FolderMonitor _folderMonitor;
        //private const string TargetFolder = @"\\asz-42jc23x\tempdata$"; //01/06/2022 adam comment for 42jx migrate
        private const string TargetFolder = @"\\ASZPWBCATSS02\tempdata$";
        private CancellationTokenSource _cs = new CancellationTokenSource();
        protected Task TransferTask;
        private readonly object _syncObject = new object();
        //12/28/2020 Adam add for cancel task when netwok is disconnected
        //public Action<string> OnPopupMessage;
        
        public CopyFileToServerController(string monitorFolderPath)
        {
            _backupFileRemover = new FileRemover(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ResultsBackUp"));
            _errorFileRemover = new FileRemover(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ResultsError"));
            _folderMonitor = new FolderMonitor(monitorFolderPath);
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
            LogManager.GetLogger("PNG Controller").Info("Thread is interrupted");
        }

        public Task RunningTransferTask => TransferTask;

        public Action<List<MonitoredFileInfo>> OnFolderChecked;

        public delegate bool IsCallerClosed();

        public IsCallerClosed IsCallerClosedDelegate;

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

                var files = _folderMonitor.CheckFolder(10, "*.png", "*.txt", "*.dcf", "*.s1p");

                if (files.Count == 0)
                {
                    OnFolderChecked?.Invoke(files);
                }

                MonitoredFileInfo preparedFile = null;
                try
                {
                    preparedFile = files.First(x => x.Status == MonitoredFileStatus.Sleeping);
                }
                catch (System.Exception)
                {
                    try
                    {
                        preparedFile = files.First(x => x.Status == MonitoredFileStatus.TransferError);
                    }
                    catch (System.Exception)
                    {
                        //ignore
                    }
                }

                if (preparedFile != null)
                {
                    preparedFile.Status = MonitoredFileStatus.Transferring;
                    OnFolderChecked?.Invoke(files);
                    TriggerTransferProcess(preparedFile);
                }
                Thread.Sleep(2000);
            }
            // ReSharper disable once FunctionNeverReturns
        }

        private void TriggerTransferProcess(MonitoredFileInfo preparedFile)
        {
            LogManager.GetLogger("PNG Controller").Info($"Start to copy file {preparedFile.FileInfo.Name}");
            var filePath = preparedFile.FileInfo.FullName;
            try
            {
                File.Copy(filePath, $"{TargetFolder}\\{preparedFile.FileInfo.Name}");
                _backupFileRemover.MoveFile(filePath);
            }
            catch (System.Exception e)
            {
                Debug.WriteLine("Catch exception: " + e.Message);
                if (e.Message.Contains("already exists"))
                {
                    _errorFileRemover.MoveFile(preparedFile.FileInfo.FullName);
                }
                else
                {
                    preparedFile.Status = MonitoredFileStatus.TransferError;
                    preparedFile.ErrorRetryCount += 1;
                    preparedFile.FileInfo.LastAccessTime = DateTime.Now;
                    if (preparedFile.ErrorRetryCount > 5)
                    {
                        _errorFileRemover.MoveFile(preparedFile.FileInfo.FullName);
                    }
                }
                throw;
            }
            LogManager.GetLogger("PNG Controller").Info($"Finish to copy file {preparedFile.FileInfo.Name}");
        }

        //12/29/2020 Adam add for check the local network
        public void StopTask()
        {
            _cs.Dispose();
        }
    }
}