using System;
using System.IO;
using System.Linq;
using Nlogger;

namespace ResultTransferTool.FolderTranscation
{
    class FileRemover
    {
        private readonly string _folderPath;
        public int MaxFileCount = 100;

        public FileRemover(string folderPath)
        {
            _folderPath = folderPath;
            CreateResultBackUpFolder();
        }

        private void CreateResultBackUpFolder()
        {
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>new file path</returns>
        public string MoveFile(string filePath)
        {
            //KeepFolderSizeUnderMaximum();
            var subFolderPath = CreateSubFolderByDate();
            if (filePath == null) throw new ArgumentNullException();
            var newFilePath = Path.Combine(subFolderPath, Path.GetFileName(filePath));
            if (File.Exists(newFilePath))
            {
                File.Delete(newFilePath);
            }
            File.Move(filePath, newFilePath);
            LogManager.GetLogger("Controller").Info($"Move file to {newFilePath}.");
            return newFilePath;
        }

        private string CreateSubFolderByDate()
        {
            var date = DateTime.Now;
            var subFolderPath = Path.Combine(_folderPath,
                $"{date.Year}{date.Month:00}{date.Day:00}");
            if (!Directory.Exists(subFolderPath))
            {
                Directory.CreateDirectory(subFolderPath);
            }
            return subFolderPath;
        }

        private void KeepFolderSizeUnderMaximum()
        {
            var folder = new DirectoryInfo(_folderPath);
            var files = folder.GetFiles("*.xml").OrderByDescending(x => x.LastWriteTime).ToList();
            if (files.Count < MaxFileCount)
            {
                return;
            }
            var iterate = files.Count - MaxFileCount;
            for (int i = 0; i < iterate; i++)
            {
                File.Delete(files.Last().FullName);
                files.RemoveAt(files.Count - 1);
            }
        }
    }
}
