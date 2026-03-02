using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using NUnit.Framework;
using ResultTransferTool.FolderTranscation;

namespace ResultTransferToolUnitTest.FolderTranscation
{
    [TestFixture]
    class FolderMonitorTest
    {
        private readonly string _folderPath = AppDomain.CurrentDomain.BaseDirectory + "\\Results";

        [OneTimeSetUp]
        public void RegisterTrace()
        {
            Debug.Listeners.Add(new ConsoleTraceListener());
        }

        [SetUp]
        public void SetUp()
        {
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }

            if (Directory.GetFiles(_folderPath, "*.xml").Length == 0)
            {
                CreateDumpFiles();
            }
        }

        [Test]
        public void GetXmlFiles()
        {
            var monitor = new FolderMonitor(_folderPath);
            var files = monitor.CheckFolder("*.xml");
            Assert.IsNotEmpty(files);
        }

        [Test]
        public void NewFileComes()
        {
            var monitor = new FolderMonitor(_folderPath);
            monitor.CheckFolder("*.xml");
            var newFileInfo = CreateFile("newfile.xml");
            var files = monitor.CheckFolder("*.xml");
            Assert.IsNotEmpty(files);
            Assert.True(files.Any(x => x.FileInfo.Name == "newfile.xml"));
            File.Delete(newFileInfo.FullName);
        }

        [Test]
        public void DeleteFileFired()
        {
            var monitor = new FolderMonitor(_folderPath);
            var files = monitor.CheckFolder("*.xml");
            var fileReadyToDelete = files.First();
            File.Delete(fileReadyToDelete.FileInfo.FullName);
            var updateFiles = monitor.CheckFolder("*.xml");
            Assert.IsNotEmpty(updateFiles);
            Assert.True(updateFiles.All(x => x.FileInfo.Name != fileReadyToDelete.FileInfo.Name));
        }

        private void CreateDumpFiles()
        {
            for (int i = 0; i < 10; i++)
            {
                var fileInfo = CreateFile($"TestMonitorFile{i}.xml");
                fileInfo.LastWriteTime = new DateTime(2016, 1, i + 1);
            }
        }

        private FileInfo CreateFile(string fileName)
        {
            var fileInfo = new FileInfo(Path.Combine(_folderPath, fileName));
            var fs = fileInfo.Create();
            fs.Close();
            return fileInfo;
        }
    }
}
