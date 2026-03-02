using Nlogger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResultTransferTool.Addon
{
    public class CopyFolderToServer
    {
        //01/06/2022 adam comment for 42jx migrate
        //private string _serverPath = @"\\asz-42jc23x\tempdata$";
        private string _serverPath = @"\\ASZPWBCATSS02\tempdata$";
        
        private string _monitorPath;
        private string _backupPath;

        public CopyFolderToServer(string appRootPath)
        {
            _monitorPath = Path.Combine(new DirectoryInfo(appRootPath).Parent.FullName, "JasonData");
            _backupPath = Path.Combine(new DirectoryInfo(appRootPath).Parent.FullName, "JasonDataBackup");
            if (!Directory.Exists(_backupPath))
            {
                Directory.CreateDirectory(_backupPath);
            }
            _serverPath = Path.Combine(_serverPath, "JasonData");
            if (Directory.Exists(_serverPath))
            {
                Directory.CreateDirectory(_serverPath);
            }
        }

        public void Execute()
        {
            while (true)
            {
                if (!Directory.Exists(_monitorPath))
                {
                    Thread.Sleep(1000);
                    continue;
                }
                var folders = Directory.GetDirectories(_monitorPath);
                foreach (var folder in folders)
                {
                    try
                    {
                        var files = Directory.GetFiles(folder);
                        if (files.Length == 0)
                        {
                            continue;
                        }
                        var folderName = new DirectoryInfo(folder).Name;
                        var targetFolder = Path.Combine(_serverPath, folderName);
                        var backupFolder = Path.Combine(_backupPath, folderName);
                        if (!Directory.Exists(targetFolder))
                        {
                            Directory.CreateDirectory(targetFolder);
                        }
                        if (!Directory.Exists(backupFolder))
                        {
                            Directory.CreateDirectory(backupFolder);
                        }
                        foreach (var file in files)
                        {
                            var fileName = Path.GetFileName(file);
                            var targetFile = Path.Combine(_serverPath, folderName, fileName);
                            var backupFIle = Path.Combine(_backupPath, folderName, fileName);
                            File.Copy(file, targetFile, true);
                            File.Move(file, backupFIle);
                        }
                        LogManager.GetLogger("Folder Controller").Info($"Copy folder {folderName} to server is finished.");
                        Thread.Sleep(1000);
                    }
                    catch (System.Exception ex)
                    {
                        LogManager.GetLogger("Folder Controller").Warn($"Copy folder to server is failure.");
                    }
                }
            }
        }
    }
}