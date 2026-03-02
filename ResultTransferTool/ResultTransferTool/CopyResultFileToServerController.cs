using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nlogger;
using ResultTransferTool.Exception;
using ResultTransferTool.TransferTranscation;

namespace ResultTransferTool
{
    public abstract class CopyResultFileToServerController
    {
        protected string ServerAddress;
        protected string MonitorFolderPath;
        protected string BackupFolderPath;
        private readonly ResultXmlParser _resultReader = new ResultXmlParser();
        private readonly object _syncObject = new object();
        public delegate bool IsCallerClosed();
        public IsCallerClosed IsCallerClosedDelegate;
        //12/28/2020 Adam add for cancel task when netwok is disconnected
        private CancellationTokenSource _cs = new CancellationTokenSource();
        //public Action<string> OnPopupMessage;
        public void Run()
        {
            lock (_syncObject)
            {
                Task.Run(() =>
                {
                    DoCopy();
                });
            }
        }

        private void DoCopy()
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

                if (!Directory.Exists(MonitorFolderPath))
                {
                    Directory.CreateDirectory(MonitorFolderPath);
                }
                var subFolders = Directory.GetDirectories(MonitorFolderPath);
                foreach (var subFolder in subFolders)
                {
                    var files = Directory.GetFiles(subFolder);
                    if (files.Length == 0)
                    {
                        DeleteOldFolder(subFolder);
                    }
                    foreach (var file in files)
                    {
                        CopyFileToServer(file);
                    }
                }
                Thread.Sleep(3000);
            }
            // ReSharper disable once FunctionNeverReturns
        }

        private void DeleteOldFolder(string folderPath)
        {
            var folderName = Path.GetFileName(folderPath);
            var date = BuildDateTime(folderName);
            var today = DateTime.Today;
            if (date < today)
            {
                Directory.Delete(folderPath);
            }
        }

        private void CopyFileToServer(string filePath)
        {
            try
            {
                var fileName = Path.GetFileName(filePath);
                Debug.Assert(fileName != null, "fileName != null");
                var targetPath = Path.Combine(GetFolderPath(filePath), fileName);

                //TODO: Template solution. It takes too long from Reynosa to Suzhou
                var result = _resultReader.GetPimOrRlIsoTestResult(filePath, TransferTranscation.FileMode.Encryptor);
                if (result.Head.Factory == "Reynosa")
                {
                    LogManager.GetLogger("Backup Controller").Info($"SKip to copy {fileName} to server finished.");
                }
                else
                {
                    File.Copy(filePath, targetPath, true);
                    LogManager.GetLogger("Backup Controller").Info($"Copy {fileName} to server finished.");
                }
                MoveFileToLocalBackup(filePath);
            }
            catch (System.Exception e)
            {
                Debug.WriteLine(e);
                //ignore
            }
        }

        private void MoveFileToLocalBackup(string filePath)
        {
            var fileName = Path.GetFileName(filePath);
            var folderName = Path.GetFileName(Path.GetDirectoryName(filePath));
            var date = BuildDateTime(folderName);
            var dateTimeLabel = date.ToString("yyyyMMdd");
            var dateTimeFolderPath = Path.Combine(BackupFolderPath, dateTimeLabel);
            if (!Directory.Exists(dateTimeFolderPath))
            {
                Directory.CreateDirectory(dateTimeFolderPath);
            }
            Debug.Assert(fileName != null, "fileName != null");
            var targetPath = Path.Combine(dateTimeFolderPath, fileName);
            File.Copy(filePath, targetPath, true);
            File.Delete(filePath);
        }


        private string GetFolderPath(string filePath)
        {
            var folderName = Path.GetFileName(Path.GetDirectoryName(filePath));
            var date = BuildDateTime(folderName);
            var dateTimeLabel = date.ToString("yyyy-MM-dd");
            var dateTimeFolderPath = Path.Combine(ServerAddress, dateTimeLabel);
            if (!Directory.Exists(dateTimeFolderPath))
            {
                Directory.CreateDirectory(dateTimeFolderPath);
            }
            var machineNameFolderPath = Path.Combine(dateTimeFolderPath, Environment.MachineName);
            if (!Directory.Exists(machineNameFolderPath))
            {
                Directory.CreateDirectory(machineNameFolderPath);
            }
            return machineNameFolderPath;
        }

        private DateTime BuildDateTime(string folderName)
        {
            var year = folderName.Substring(0, 4);
            var month = folderName.Substring(4, 2);
            var day = folderName.Substring(6, 2);
            return DateTime.Parse($"{year}/{month}/{day}");
        }
        //12/29/2020 Adam add for check the local network
        public void Interrupt()
        {
            Debug.WriteLine("Interrupt Monitor.");
            _cs.Cancel();
            LogManager.GetLogger("SQL Controller").Info("Thread is interrupted");
        }
        public void StopTask()
        {
            _cs.Dispose();
        }
    }
}
