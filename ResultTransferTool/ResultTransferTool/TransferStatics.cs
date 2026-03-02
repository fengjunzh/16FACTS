using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Xml.Linq;

namespace ResultTransferTool
{
    public class TransferStatics
    {
        //private const string ServerAddress = @"\\asz-42jc23x\CatsClientTransferStaticsRecord$"; //01/06/2022 adam comment for 42jx migrate
        private const string ServerAddress = @"\\ASZPWBCATSS02\CatsClientTransferStaticsRecord$";
        private readonly string _pcName;
        private string _filePath;
        private string _dateLabel;

        public TransferStatics()
        {
            _pcName = Environment.MachineName;
            var staticFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Statics");
            if (!Directory.Exists(staticFolder))
            {
                Directory.CreateDirectory(staticFolder);
            }
            CreateStaticFile();
        }

        private void CreateStaticFile()
        {
            var time = DateTime.Now;
            _dateLabel = $"{time.Year}-{time.Month}-{time.Day}";
            var fileName = _pcName + "_" + _dateLabel + ".xml";
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Statics", fileName);
            if (!File.Exists(_filePath))
            {
                InitializeXml();
            }
        }

        private void InitializeXml()
        {
            var xDoc = new XDocument();
            var rootElement = new XElement("Root");
            xDoc.Add(rootElement);
            var pcNameElement = new XElement("PcName") { Value = _pcName };
            var updateDateElement = new XElement("UpdateDate");
            rootElement.Add(pcNameElement);
            rootElement.Add(updateDateElement);
            var successElement = new XElement("Success");
            rootElement.Add(successElement);
            var failureElement = new XElement("Failure");
            rootElement.Add(failureElement);
            xDoc.Save(_filePath);
        }

        private void UpdateDateTime(XDocument xDoc)
        {
            xDoc.Root.Element("UpdateDate").Value = DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }

        public void InsertSuccessfulFileInfo(string fileName, double timeCost)
        {
            var xDoc = XDocument.Load(_filePath);
            Debug.Assert(xDoc.Root != null, "xDoc.Root != null");
            var successElement = xDoc.Root.Element("Success");
            var fileElement = new XElement("file", new XAttribute("name", fileName), new XAttribute("timeCost", timeCost));
            Debug.Assert(successElement != null, "successElement != null");
            successElement.Add(fileElement);
            UpdateDateTime(xDoc);
            xDoc.Save(_filePath);
        }

        public void InsertFailFileInfo(string fileName, string errorMessage)
        {
            var xDoc = XDocument.Load(_filePath);
            Debug.Assert(xDoc.Root != null, "xDoc.Root != null");
            var failureElement = xDoc.Root.Element("Failure");
            var fileElement = new XElement("file", new XAttribute("name", fileName), new XAttribute("errorMessage", errorMessage));
            Debug.Assert(failureElement != null, "failureElement != null");
            failureElement.Add(fileElement);
            UpdateDateTime(xDoc);
            xDoc.Save(_filePath);
        }

        public void TransferYesterdaysStaticFileToServer()
        {
            try
            {
                var staticFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Statics");
                var files = Directory.GetFiles(staticFolder);
                var today = DateTime.Parse(_dateLabel);
                foreach (var file in files)
                {
                    var lastModifiedTime = File.GetLastWriteTime(file);
                    if (lastModifiedTime < today)
                    {
                        TransferStaticToServer(file);
                    }
                }
                CreateStaticFile();
            }
            catch (System.Exception)
            {
                //Ignore
            }
        }

        public void TransferStaticFileToServerImmediately()
        {
            try
            {
                var staticFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Statics");
                var files = Directory.GetFiles(staticFolder);
                foreach (var file in files)
                {
                    try
                    {
                        TransferStaticToServer(file);
                    }
                    catch (System.Exception)
                    {
                        //ignore
                    }
                }
                CreateStaticFile();
            }
            catch (System.Exception)
            {
                //Ignore
            }
        }

        private void TransferStaticToServer(string filePath)
        {
            var dateLabel = GetDateLabel(filePath);
            var fileName = Path.GetFileName(filePath);
            Debug.Assert(fileName != null, "fileName != null");
            var targetFolder = Path.Combine(ServerAddress, dateLabel);
            if (!Directory.Exists(targetFolder))
            {
                Directory.CreateDirectory(targetFolder);
            }
            var targetPath = Path.Combine(ServerAddress, dateLabel, fileName);
            File.Copy(filePath, targetPath, true);
            var backUpFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Statics", "Backup");
            if (!Directory.Exists(backUpFolder))
            {
                Directory.CreateDirectory(backUpFolder);
            }
            var time = DateTime.Now;
            _dateLabel = $"{time.Year}-{time.Month}-{time.Day}";
            var todaysFileName = _pcName + "_" + _dateLabel + ".xml";
            if (fileName == todaysFileName)
            {
                return;
            }
            var backUpFilePath = Path.Combine(backUpFolder, fileName);
            if (File.Exists(backUpFilePath))
            {
                File.Delete(backUpFilePath);
            }
            File.Move(filePath, backUpFilePath);
        }

        private string GetDateLabel(string filePath)
        {
            try
            {
                var xDoc = XDocument.Load(filePath);
                var date = DateTime.Parse(xDoc.Root.Element("UpdateDate").Value);
                return $"{date.Year}-{date.Month}-{date.Day}";
            }
            catch (System.Exception)
            {
                File.Delete(filePath);
                throw;
            }
        }
    }
}
