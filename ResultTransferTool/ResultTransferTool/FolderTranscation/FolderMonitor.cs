using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ResultTransferTool.FolderTranscation
{
    class FolderMonitor
    {
        private readonly string _folderPath;

        private readonly List<MonitoredFileInfo> _monitoredFileInfos;

        public List<MonitoredFileInfo> CheckFolder(string pattern)
        {
            var files = GetFiles(pattern);
            UpdateFileList(files);
            FindAndMarkSleepingFiles();
            return _monitoredFileInfos.OrderBy(x => x.FileInfo.LastAccessTime).ToList();
        }

        public List<MonitoredFileInfo> CheckFolder(int sleepTimespanMinutes, params string[] patterns)
        {
            var files = GetFiles(patterns[0]);
            for (int i = 1; i < patterns.Count(); i++)
            {
                files.AddRange(GetFiles(patterns[i]));
            }
            UpdateFileList(files);
            FindAndMarkSleepingFiles(sleepTimespanMinutes);
            return _monitoredFileInfos.OrderBy(x => x.FileInfo.LastAccessTime).ToList();
        }

        private void FindAndMarkSleepingFiles()
        {
            foreach (var monitoredFileInfo in _monitoredFileInfos)
            {
                if (monitoredFileInfo.Status == MonitoredFileStatus.Writing)
                {
                    var baseTime = DateTime.UtcNow;
                    if ((baseTime - monitoredFileInfo.FileInfo.LastWriteTimeUtc).TotalSeconds > 10)
                    {
                        monitoredFileInfo.Status = MonitoredFileStatus.Sleeping;
                    }
                }
            }
        }

        private void FindAndMarkSleepingFiles(int sleepTimespanMinute)
        {
            foreach (var monitoredFileInfo in _monitoredFileInfos)
            {
                if (monitoredFileInfo.Status == MonitoredFileStatus.Writing)
                {
                    var baseTime = DateTime.UtcNow;
                    if ((baseTime - monitoredFileInfo.FileInfo.LastWriteTimeUtc).TotalMinutes > sleepTimespanMinute)
                    {
                        monitoredFileInfo.Status = MonitoredFileStatus.Sleeping;
                    }
                }
            }
        }

        private void UpdateFileList(List<FileInfo> fileInfos)
        {
            foreach (var fileInfo in fileInfos)
            {
                if (_monitoredFileInfos.All(x => x.FileInfo.Name != fileInfo.Name))
                {
                    _monitoredFileInfos.Add(new MonitoredFileInfo(fileInfo));
                }
            }

            var readyToDelete = new List<FileInfo>();
            foreach (var monitoredFileInfo in _monitoredFileInfos)
            {
                if (fileInfos.All(x => x.Name != monitoredFileInfo.FileInfo.Name))
                {
                    readyToDelete.Add(monitoredFileInfo.FileInfo);
                }
            }
            foreach (var file in readyToDelete)
            {
                var index = _monitoredFileInfos.FindIndex(x => x.FileInfo.Name == file.Name);
                _monitoredFileInfos.RemoveAt(index);
            }
        }

        public FolderMonitor(string folderPath)
        {
            _folderPath = folderPath;
            _monitoredFileInfos = new List<MonitoredFileInfo>();
        }

        private List<FileInfo> GetFiles(string pattern)
        {
            var folder = new DirectoryInfo(_folderPath);
            return folder.GetFiles(pattern).ToList();
        }
    }
}
