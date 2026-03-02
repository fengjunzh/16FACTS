using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Nlogger
{
    public class LogToFile
    {
        private readonly object _syncRoot = new object();
        private string _logFilePath;
        private readonly int _maxFileCount = 100;
        private readonly double _maxFileSize = 1024 * 1024 * 10;
        private readonly string _logFolderPath;

        public LogToFile(string folderPath)
        {
            _logFolderPath = folderPath;
            CreateLogFile(folderPath);
            WriteToFile("Trace start......");
        }

        private void CreateLogFile(string folderPath)
        {
            var dateTime = DateTime.Now;
            var fileName = $"{dateTime.Year}{dateTime.Month:00}{dateTime.Day:00}-{dateTime.Hour:00}{dateTime.Minute:00}{dateTime.Second:00}.txt";
            _logFilePath = Path.Combine(folderPath, fileName);
            var file = File.Create(_logFilePath);
            file.Close();
        }

        public void LogReceived(LogEventInfo log)
        {
            WriteToFile($"{log.TimeStamp}: {log.LoggerName} [{log.Level}] -> {log.Message}");
        }

        private void WriteToFile(string text)
        {
            lock (_syncRoot)
            {
                var fileSize = new FileInfo(_logFilePath).Length;
                if (fileSize > _maxFileSize)
                {
                    CreateLogFile(_logFolderPath);
                }
                using (var sw = File.AppendText(_logFilePath))
                {
                    sw.WriteLine(text);
                }
            }
        }

        private void KeepFolderSizeUnderMaximum(string folderPath)
        {
            var folder = new DirectoryInfo(folderPath);
            var files = folder.GetFiles().OrderByDescending(x => x.LastWriteTime).ToList();
            if (files.Count < _maxFileCount)
            {
                return;
            }
            var iterate = files.Count - _maxFileCount;
            for (int i = 0; i < iterate; i++)
            {
                File.Delete(files.Last().FullName);
                files.RemoveAt(files.Count - 1);
            }
        }
    }
}
