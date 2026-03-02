using ResultTransferTool.Exception;
using ResultTransferTool.TransferTranscation.ArgusXmlFormat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ResultTransferTool.TransferTranscation.XmlParser
{
    class ArgusXmlParser : BasicXmlParser
    {
        public TestResultTemplate GetTestResult(XDocument xDoc)
        {
            var result = new TestResultTemplate();
            var root = xDoc.Root;
            result.Type = int.Parse(GetElementValue(root, "Type"));
            result.DbConnString = GetDbConnString(root);
            result.Head = GetHeadInfo(root);
            result.ArgusGroup = GetArgusGroup(root);
            return result;
        }

        private ArgusGroupTemplate GetArgusGroup(XElement root)
        {
            var group = new ArgusGroupTemplate();
            var config = GetRetConfigurationSteps(root);
            group.GroupStatus = config.FinalTestResult;
            return group;
        }

        private RetConfigurationTemplate GetRetConfigurationSteps(XElement root)
        {
            var config = new RetConfigurationTemplate();
            var parentElement = root.Element("RETConfiguration");
            if (parentElement == null)
            {
                throw new ResultXmlParserException(@"Can't find element (RETConfiguration) in result xml file.");
            }
            config.SwitchToSRETforConfiguration = GetElementValue(parentElement, "SwitchToSRETforConfiguration");
            config.Configuration = GetElementValue(parentElement, "Configuration");
            config.ConfirmI2CFunction = GetElementValue(parentElement, "ConfirmI2CFunction");
            config.RETMode = GetElementValue(parentElement, "RETMode");
            config.ConfirmConfirguration = GetElementValue(parentElement, "ConfirmConfirguration");
            config.CycleTestFunction = GetElementValue(parentElement, "CycleTestFunction");
            config.FinalTestResult = GetElementValue(parentElement, "FinalTestResult");
            return config;
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
            head.Mode = GetElementValue(parentElement, "Mode");
            head.ProductName = GetElementValue(parentElement, "ProductName");
            head.PhaseName = GetElementValue(parentElement, "Phase");
            head.MeasStartTime = TrimMicroSecond(GetElementValue(parentElement, "MeasStartTime"));
            head.MeasStopTime = TrimMicroSecond(GetElementValue(parentElement, "MeasStopTime"));
            head.MeasStatus = GetElementValue(parentElement, "TestResult");
            head.UserName = GetElementValue(parentElement, "TestUser");
            head.Factory = GetElementValue(parentElement, "Factory");
            head.Controller = GetElementValue(parentElement, "PCName");
            head.TotalTime = (int)(head.MeasStopTime - head.MeasStartTime).TotalSeconds;
            return head;
        }
    }
}
