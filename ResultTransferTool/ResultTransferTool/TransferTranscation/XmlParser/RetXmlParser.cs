using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ResultTransferTool.TransferTranscation.RetXmlFormat;
using ResultTransferTool.Exception;
using Nlogger;

namespace ResultTransferTool.TransferTranscation.XmlParser
{
    class RetXmlParser : BasicXmlParser
    {
        public TestResultTemplate GetTestResult(XDocument xDoc)
        {
            var result = new TestResultTemplate();
            var root = xDoc.Root;
            result.Type = int.Parse(GetElementValue(root, "Type"));
            result.DbConnString = GetDbConnString(root);
            result.Head = GetHeadInfo(root);
            result.Testgroups = GetTestGroups(root);
            return result;
        }

        private HeadTemplate GetHeadInfo(XElement root)
        {
            var head = new HeadTemplate();
            var parentElement = root.Element("Head");
            if (parentElement == null)
            {
                throw new ResultXmlParserException(@"Can't find element (Head) in result xml file.");
            }
            head.SerialNumber = GetElementValue(parentElement, "SerialNumber").Trim();
            head.Mode = GetElementValue(parentElement, "ProductMode");
            head.ProductName = GetElementValue(parentElement, "ProductName");
            head.PhaseName = GetElementValue(parentElement, "PhaseName");
            head.MeasStartTime = TrimMicroSecond(GetElementValue(parentElement, "MeasStartTime"));
            head.MeasStopTime = TrimMicroSecond(GetElementValue(parentElement, "MeasStopTime"));
            head.SoftwareRev = GetElementValue(parentElement, "SoftwareRev");
            head.MeasStatus = GetElementValue(parentElement, "MeasStatus");
            head.TotalTime = GetElementValue(parentElement, "TotalTime");
            head.UserName = GetElementValue(parentElement, "UserName");
            head.Factory = GetElementValue(parentElement, "Factory");
            head.Controller = GetElementValue(parentElement, "Controller");
            return head;
        }

        private decimal CastToDecimal(string value, int precision, int scale)
        {
            var result = decimal.Parse(value);
            return Math.Round(result, scale);
        }

        private List<TestGroupTemplate> GetTestGroups(XElement root)
        {
            var testGroups = new List<TestGroupTemplate>();
            var testGroupElements = root.Elements("Group");
            if (testGroupElements == null)
            {
                LogManager.GetLogger("Controller").Warn(@"Can't find element (TestPhase) in result xml file.");
                return testGroups;
            }
            foreach (var groupElement in testGroupElements)
            {
                testGroups.Add(new TestGroupTemplate
                {
                    GroupName = GetElementValue(groupElement, "GroupName"),
                    GroupStatus = GetElementValue(groupElement, "GroupStatus"),
                    Index = int.Parse(GetElementValue(groupElement, "Index")),
                    TestItems = GetTestItems(groupElement)
                });
            }
            return testGroups;
        }

        private List<TestItemTemplate> GetTestItems(XElement groupElement)
        {
            var testItems = new List<TestItemTemplate>();
            var testItemElements = groupElement.Elements("Item");
            if (testItemElements == null)
            {
                throw new ResultXmlParserException(@"Can't find element (Item) in result xml file.");
            }
            foreach (var testItemElement in testItemElements)
            {
                testItems.Add(new TestItemTemplate
                {
                    ItemName = GetElementValue(testItemElement, "ItemName"),
                    Index = int.Parse(GetElementValue(testItemElement, "Index")),
                    Status = GetElementValue(testItemElement, "Status"),
                    NunNumericValue = GetElementValue(testItemElement, "NonNumericValue", null),
                    Units = GetElementValue(testItemElement, "Units", null),
                    UpperLimit = double.Parse(GetElementValue(testItemElement, "UpperLimit")),
                    LowerLimit = double.Parse(GetElementValue(testItemElement, "LowerLimit")),
                    NumbericValue = CastToDecimal(GetElementValue(testItemElement, "NumericValue", "0"), 8, 3),
                    ElapsedTime = int.Parse(GetElementValue(testItemElement, "ElapsedTime")),
                });
            }
            return testItems;
        }
    }
}
