using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Threading;
using System.Xml.Linq;

namespace Updater
{
    public class UpdateManager
    {
        private readonly ConfigurationManager _configuration;
        private string _versionBackupFolder;
        public Action<string> LogAction;

        public UpdateManager(ConfigurationManager configuration)
        {
            _configuration = configuration;
        }

        public void KillCallerProcess()
        {
            foreach (var process in Process.GetProcessesByName(_configuration.CallerName))
            {
                process.Kill();
            }

            Thread.Sleep(2000);
        }
        private static void KillProcessAndChildrens(int pid)
        {
            ManagementObjectSearcher processSearcher = new ManagementObjectSearcher
              ("Select * From Win32_Process Where ParentProcessID=" + pid);
            ManagementObjectCollection processCollection = processSearcher.Get();

            try
            {
                Process proc = Process.GetProcessById(pid);
                if (!proc.HasExited) proc.Kill();
            }
            catch (ArgumentException)
            {
                // Process already exited.
            }

            if (processCollection != null)
            {
                foreach (ManagementObject mo in processCollection)
                {
                    KillProcessAndChildrens(Convert.ToInt32(mo["ProcessID"])); //kill child processes(also kills childrens of childrens etc.)
                }
            }
        }

        public void RestartApplication()
        {
            Process.Start(CallerPath(), CallerArgs());
        }

        private string CallerArgs()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configuration", "args.txt");
            if (File.Exists(path))
            {
                var text = File.ReadAllText(path);
                try
                {
                    var args = text.Substring(text.IndexOf(".exe") + 5);
                }
                catch
                {
                    text = "";
                }
                return text;
            }
            return "";
        }

        public void CopyFolderFromServer()
        {
            _versionBackupFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup",
                _configuration.VersionSubFolder);
            var source = _configuration.Server + "\\" + _configuration.VersionSubFolder;
            DirectoryCopy(source, _versionBackupFolder, true);
            LogAction?.Invoke(
                $"Copy version folder ({_configuration.VersionSubFolder}) from server ({_configuration.Server})");
        }

        public void UpdateFiles()
        {
            foreach (var component in _configuration.Components)
            {
                //01/13/2022 Adam change
                //var sourceFile = Path.Combine(_versionBackupFolder, component.Source);
                var sourceFile = Path.Combine(_configuration.Server,string.Concat("Version", _configuration.ServerVersion), component.Source);
                var targetFile = BuildTargetFilePath(component.Target);
                if (File.Exists(sourceFile))
                {
                    File.Copy(sourceFile, targetFile, true);
                }
                LogAction?.Invoke($"Copy file from ({sourceFile}) to ({targetFile})");
            }
        }

        public void CopyErrorFiles()
        {
            try
            {
                var errCfgSrcPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup",
                    _configuration.VersionSubFolder, "Updater", "Configuration", "ErrorFileNames.xml");
                var erroCfgTargPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configuration",
                    "ErrorFileNames.xml");
                File.Copy(errCfgSrcPath, erroCfgTargPath, true);
                var resultFolder = GetResultFolder();
                var directInfo = new DirectoryInfo(resultFolder);
                var errorFolder = Path.Combine(directInfo.Parent.FullName, "ResultsError");
                var folders = GetErrorFoldersShouldMoveBack();
                foreach (var folder in folders)
                {
                    var tmpFolder = Path.Combine(errorFolder, folder);
                    if (!Directory.Exists(tmpFolder))
                    {
                        continue;
                    }
                    var files = Directory.GetFiles(tmpFolder);
                    foreach (var file in files)
                    {
                        var fileInfo = new FileInfo(file);
                        var targetFilePath = Path.Combine(resultFolder, fileInfo.Name);
                        if (!File.Exists(targetFilePath))
                        {
                            File.Move(file, targetFilePath);
                        }
                    }
                }
            }
            catch
            {
                //ignore
            }
        }

        private string[] GetErrorFoldersShouldMoveBack()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configuration", "ErrorFileNames.xml");
            var xDoc = XDocument.Load(path);
            var root = xDoc.Root;
            var elements = root.Elements("FileName");
            var result = new List<string>();
            foreach (var xElement in elements)
            {
                result.Add(xElement.Value);
            }
            return result.ToArray();
        }

        public string GetResultFolder()
        {
            try
            {
                var appPath = AppDomain.CurrentDomain.BaseDirectory;
                var directInfo = new DirectoryInfo(appPath);
                var parentPath = directInfo.Parent.FullName;
                var cfgPath = Path.Combine(parentPath, "Cfg", "UserSetting.xml");
                var xDoc = XDocument.Load(cfgPath);
                var root = xDoc.Root;
                var resultFolder = root.Element("ResultFolder").Value;
                return resultFolder;
            }
            catch (Exception)
            {
                throw new FileNotFoundException();
            }
        }

        private string CallerPath()
        {
            var appPath = AppDomain.CurrentDomain.BaseDirectory;
            var directInfo = new DirectoryInfo(appPath);
            var parentPath = directInfo.Parent.FullName;
            return Path.Combine(parentPath, _configuration.CallerName + ".exe");
        }

        private string BuildTargetFilePath(string relativePath)
        {
            var appPath = AppDomain.CurrentDomain.BaseDirectory;
            if (relativePath.StartsWith("..\\"))
            {
                var directInfo = new DirectoryInfo(appPath);
                var parentPath = directInfo.Parent.FullName;
                return Path.Combine(parentPath, relativePath.Substring(3));
            }
            else
            {
                return Path.Combine(appPath, relativePath.Substring(3));
            }
        }

        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                if (!File.Exists(temppath))
                {
                    file.CopyTo(temppath, false);
                }
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }
}
