using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace ResultTransferTool.MTS
{
    public class WorkStationDefinationManager
    {
        private readonly string _filePath;
        //private readonly string _serverFilePath = @"\\asz-42jc23x\CatsResultTransferTool\Workstation.xml"; //01/06/2022 adam comment for 42jx migrate
        private readonly string _serverFilePath = @"\\sdcnas01\sts_cats\APP_Fiber\FACTSResultTransferTool\Workstation.xml";

        public WorkStationDefinationManager()
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cfg", "Workstation.xml");
        }

        public WorkStationDefinationManager(string filePath)
        {
            _filePath = filePath;
        }

        public bool UpdateFileFromServer()
        {
            var serverFile = new FileInfo(_serverFilePath);
            var localFile = new FileInfo(_filePath);
            //if (serverFile.LastWriteTimeUtc > localFile.LastWriteTimeUtc)
            //{
            File.Copy(_serverFilePath, _filePath, true);
            return true;
            //}
            //return false;
        }

        public List<string> GetAlternateWorkStationName(string testType)
        {
            var result = new List<string>();
            var xDoc = Load();
            var workStationElement = xDoc.Root.Element("Workstation");
            var alternateElement = workStationElement.Element("Alternate");
            if (alternateElement == null)
            {
                workStationElement.Add(new XElement("Alternate"));
                alternateElement = workStationElement.Element("Alternate");
            }
            var targetElements = alternateElement.Elements(testType);
            if (!targetElements.Any())
            {
                switch (testType)
                {
                    case "PIM_Test":
                        alternateElement.Add(new XElement("PIM_Test", "PIM存盘"));
                        break;
                    case "RL_ISO":
                        alternateElement.Add(new XElement("RL_ISO", @"RL/ISO存盘"));
                        alternateElement.Add(new XElement("RL_ISO", "RL_ISO存盘"));
                        break;
                    default:
                        throw new XmlException("Default value is node defined");
                }
                xDoc.Save(_filePath);
            }
            result = alternateElement.Elements(testType).Select(x => x.Value).ToList();
            return result;
        }

        public string GetTestTypeNodeName(string value)
        {
            var xDoc = Load();
            var workStationElement = xDoc.Root.Element("Workstation");
            return workStationElement.Elements().Where(x => x.Value == value).First().Name.ToString();
        }

        public void UpdateValidWorkStationName(string testType, string stationName)
        {
            var xDoc = Load();
            var workStationElement = xDoc.Root.Element("Workstation");
            var firstName = workStationElement.Element(testType).Value;
            if (firstName != stationName)
            {
                var alternateElement = workStationElement.Element("Alternate");
                var alternateNames = alternateElement.Elements(testType).Where(x => x.Value == stationName).ToList();
                if (alternateNames.Count != 0)
                {
                    workStationElement.Element(testType).Value = alternateNames.First().Value;
                    alternateNames.First().Value = firstName;
                    xDoc.Save(_filePath);
                }
            }
        }

        public string GetWorkStationName(string testType)
        {
            var xDoc = Load();
            var workStationElement = xDoc.Root.Element("Workstation");
            var targetElement = workStationElement.Element(testType);
            if (targetElement == null)
            {
                switch (testType)
                {
                    case "PIM_Test":
                        workStationElement.Add(new XElement("PIM_Test", "STS存盘"));
                        break;
                    case "RL_ISO":
                        workStationElement.Add(new XElement("RL_ISO", "RLISO存盘"));
                        break;
                    default:
                        throw new XmlException("Default value is node defined");
                }
                xDoc.Save(_filePath);
            }
            return xDoc.Root.Element("Workstation").Element(testType).Value;
        }

        public void InitializeXmlFile()
        {
            if (!File.Exists(_filePath))
            {
                var xDoc = new XDocument();
                xDoc.Add(new XElement("root"));
                xDoc.Root.Add(new XElement("Workstation"));
                var worStationElement = xDoc.Root.Element("Workstation");
                worStationElement.Add(new XElement("PIM_Test", "STS存盘"));
                worStationElement.Add(new XElement("RL_ISO", "RLISO存盘"));
                xDoc.Save(_filePath);
            }
        }

        private XDocument Load()
        {
            try
            {
                var xDoc = XDocument.Load(_filePath);
                if (!xDoc.Root.Elements("Workstation").Any())
                {
                    CreateWorkstationFile();
                }
                return xDoc;
            }
            catch (System.Exception)
            {
                CreateWorkstationFile();
            }
            return XDocument.Load(_filePath);
        }

        private void CreateWorkstationFile()
        {
            var xDoc = new XDocument();
            xDoc.Add(new XElement("root"));
            xDoc.Root.Add(new XElement("Workstation"));
            xDoc.Save(_filePath);
        }
    }
}
