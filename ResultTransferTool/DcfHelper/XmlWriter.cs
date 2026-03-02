using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Encryptor;

namespace DcfHelper
{
    public class XmlWriter
    {
        private string _folder;

        public XmlWriter()
        {
            _folder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Results");
            if (!System.IO.Directory.Exists(_folder))
            {
                System.IO.Directory.CreateDirectory(_folder);
            }
        }

        public XmlWriter(string outputFolder)
        {
            _folder = outputFolder;
            if (!System.IO.Directory.Exists(_folder))
            {
                System.IO.Directory.CreateDirectory(_folder);
            }
        }

        public void Write(string dcfFilePath, ExtraPara extraPara)
        {
            if (!System.IO.File.Exists(dcfFilePath))
            {
                throw new System.IO.FileNotFoundException($"File Not Found! {0}", dcfFilePath);
            }
            var fileName = System.IO.Path.GetFileNameWithoutExtension(dcfFilePath);
            var dcfContents = ParseDcfFile(dcfFilePath);
            for (int i = 0; i < dcfContents.Count(); i++)
            {
                var xDoc = new XDocument(new XElement("TestResult"));
                WriteExtrPara(xDoc.Root, extraPara);
                WriteHead(xDoc.Root, dcfContents[i], extraPara);
                WriteMeasurement(xDoc.Root, dcfContents[i]);
                var targetFilePath = System.IO.Path.Combine(_folder, fileName + "_" + i + ".dat");
                EncryptedXmlFile(xDoc.ToString(), targetFilePath);
                //xDoc.Save(targetFilePath);
            }
        }

        private void EncryptedXmlFile(string content, string targetFilePath)
        {
            var encryptor = new Encryptor.Encryptor();
            encryptor.EncryptToFile(content, targetFilePath);
        }

        private List<DataModel.DcfDataModel> ParseDcfFile(string filePath)
        {
            var reader = new DcfReader();
            var dcfContent = reader.Parser(filePath);
            return dcfContent;
        }

        private void WriteExtrPara(XElement root, ExtraPara extraPara)
        {
            root.Add(new XElement("Type", 20));
            root.Add(new XElement("ConnString", extraPara.DbConnString));
        }

        private void WriteHead(XElement root, DataModel.DcfDataModel dcfData, ExtraPara extraPara)
        {
            var head = new XElement("Head");
            head.Add(new XElement("SerialNumber", dcfData.StartRow.SerialNumber));
            head.Add(new XElement("ProductName", dcfData.StartRow.AssemblyType));
            head.Add(new XElement("PhaseName", dcfData.StartRow.ProcessStep));
            head.Add(new XElement("SoftwareRev", dcfData.StopRow.TestSoftwareVersion));
            head.Add(new XElement("FirmwareRev", dcfData.StopRow.ProductFirmwareVersion));
            head.Add(new XElement("MeasStartTime", dcfData.StartRow.EventDateTime));
            head.Add(new XElement("MeasStopTime", dcfData.StartRow.EventDateTime.AddSeconds(dcfData.StopRow.EventDuration)));
            head.Add(new XElement("MeasStatus", dcfData.StopRow.EventStatus));
            head.Add(new XElement("TotalTime", dcfData.StopRow.EventDuration));
            head.Add(new XElement("UserName", dcfData.StartRow.Operator));
            head.Add(new XElement("Factory", dcfData.StartRow.ProductionSite));
            head.Add(new XElement("Controller", dcfData.StartRow.Controller));
            head.Add(new XElement("ProductMode", extraPara.Mode));
            root.Add(head);
        }

        private void WriteMeasurement(XElement root, DataModel.DcfDataModel dcfData)
        {
            var measurement = new XElement("Measurement");
            var groups = dcfData.MeasurementRows.Select(x => x.GroupName).Distinct().ToList();
            for (int i = 0; i < groups.Count(); i++)
            {
                var itemByGroup = dcfData.MeasurementRows.Where(x => x.GroupName == groups[i]);
                var groupNode = new XElement("Group");
                groupNode.Add(new XElement("GroupName", groups[i]));
                groupNode.Add(new XElement("Index", i));
                groupNode.Add(new XElement("GroupStatus", itemByGroup.All(x => x.TestStatus == "PASS") ? "PASS" : "FAIL"));
                foreach (var item in itemByGroup)
                {
                    var itemNode = new XElement("Item");
                    itemNode.Add(new XElement("ItemName", item.TestDesignator));
                    itemNode.Add(new XElement("Index", item.Index));
                    itemNode.Add(new XElement("Status", item.TestStatus));
                    itemNode.Add(new XElement("UpperLimit", item.UpperLimit));
                    itemNode.Add(new XElement("LowerLimit", item.LowerLimit));
                    itemNode.Add(new XElement("NonNumericValue", item.NonNumericValue));
                    itemNode.Add(new XElement("NumericValue", item.NumericValue));
                    itemNode.Add(new XElement("Units", item.Units));
                    itemNode.Add(new XElement("ElapsedTime", item.ElapsedTime));
                    groupNode.Add(itemNode);
                }
                root.Add(groupNode);
            }
        }
    }

    public class ExtraPara
    {
        public string DbConnString;
        public string Mode;
    }
}
