using System;
using System.IO;
using NUnit.Framework;
using ResultTransferTool.FolderTranscation;

namespace ResultTransferToolUnitTest.FolderTranscation
{
    [TestFixture]
    class FileRemoverTest
    {
        [Test]
        public void CreateBackUpFolder()
        {
            var folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ResultsBackUp");
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
            }
            var remover = new FileRemover(folderPath);
            Assert.True(Directory.Exists(folderPath));
        }

        [Test]
        public void MoveFile()
        {
            var fileUnderMove = "tmp.xml";
            var folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ResultsBackUp");
            CreateDumpFiles();
            var remover = new FileRemover(folderPath);
            var tmpFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileUnderMove);
            var fs = File.Create(tmpFilePath);
            fs.Close();
            remover.MoveFile(tmpFilePath);
            Assert.False(File.Exists(tmpFilePath));
        }

        private void CreateDumpFiles()
        {
            var folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ResultsBackUp");
            for (int i = 0; i < 10; i++)
            {
                var fileInfo = new FileInfo(Path.Combine(folderPath, $"test{i}.xml"));
                var fs = fileInfo.Create();
                fs.Close();
                fileInfo.LastWriteTime = new DateTime(2016, 1, i + 1);
            }
        }
    }
}
