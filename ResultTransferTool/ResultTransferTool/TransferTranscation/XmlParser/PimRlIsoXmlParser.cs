using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ResultTransferTool.TransferTranscation.ResultsXmlFormat;
using ResultTransferTool.Exception;
using Nlogger;
using System.Globalization;


namespace ResultTransferTool.TransferTranscation.XmlParser
{
    class PimRlIsoXmlParser : BasicXmlParser
    {
        public TestResultTemplate GetTestResult(XDocument xDoc)
        {
            var result = new TestResultTemplate();
            var root = xDoc.Root;
            result.Type = int.Parse(GetElementValue(root, "Type"));
            result.FormatVersion = GetFormatVersion(root);
            CheckIsFormatVersionSupported(result.FormatVersion);
            result.DbConnString = GetDbConnString(root);
            result.Flag = GetTransferFlagInfo(root);
            result.Head = GetHeadInfo(root);
            result.AssyParts = GetAssyParts(root);
            result.TestInstruments = GetTestInstruments(root);
            result.TestPhaseGroup = GetTestPhaseGroup(root);
            result.PhaseExtendCable = GetPhaseExtendCable(root);
            return result;
        }

        private PhaseExtendCableTemplate GetPhaseExtendCable(XElement root)
        {
            var resp = new PhaseExtendCableTemplate();
            var testPhaseElement = root.Element("TestPhase");
            if (testPhaseElement == null)
            {
                LogManager.GetLogger("Controller").Warn(@"Can't find element (TestPhase) in result xml file.");
                return null;
            }
            var phaseExtendCable = testPhaseElement.Element("PhaseExtendCable");
            if (phaseExtendCable == null)
            {
                LogManager.GetLogger("Controller").Warn(@"Can't find element (PhaseExtendCable) in result xml file.");
                return null;
            }
            else
            {
                resp.TestConnector = GetElementValue(phaseExtendCable, "TestConnector");
                resp.TestLengthM = CastToDecimal(GetElementValue(phaseExtendCable, "TestLengthM", "0"), 18, 3);
                resp.TemperatureC = CastToDecimal(GetElementValue(phaseExtendCable, "TemperatureC", "0"), 18, 1);
                resp.Notes = GetElementValue(phaseExtendCable, "Notes", "");
            }
            return resp;
        }

        private void CheckIsFormatVersionSupported(double versionNumber)
        {
            if (!VersionConstant.SupportedResultFormat.Contains(versionNumber))
            {
                throw new ResultFormatVersionNotSupportedException($"Result Format Version {versionNumber} is not supported");
            }
        }

        private double GetFormatVersion(XElement root)
        {
            try
            {
                return double.Parse(root.Element("Version").Value);
            }
            catch (System.Exception)
            {
                return 1;
            }
        }

        private List<TestGroupTemplate> GetTestPhaseGroup(XElement root)
        {
            var testPhase = new List<TestGroupTemplate>();
            var testPhaseElement = root.Element("TestPhase");
            if (testPhaseElement == null)
            {
                LogManager.GetLogger("Controller").Warn(@"Can't find element (TestPhase) in result xml file.");
                return testPhase;
                //throw new ResultXmlParserException(@"Can't find element (TestPhase) in result xml file.");
            }
            var testGroupElements = testPhaseElement.Elements("TestGroup");
            if (testGroupElements == null)
            {
                throw new ResultXmlParserException(@"Can't find element (TestPhase/TestGroup) in result xml file.");
            }
            foreach (var xElement in testGroupElements)
            {
                var testgroup = new TestGroupTemplate
                {
                    GroupMainId = int.Parse(GetElementValue(xElement, "GroupMainId")),
                    GroupName = GetElementValue(xElement, "GroupName"),
                    GroupStatus = GetElementValue(xElement, "GroupStatus"),
                    TestItems = GetTestItem(xElement)
                };
                testPhase.Add(testgroup);
            }

            return testPhase;
        }

        private List<TestItemTemplate> GetTestItem(XElement testGroupElement)
        {
            var testItems = new List<TestItemTemplate>();
            var testItemElements = testGroupElement.Elements("TestItem");
            if (testItemElements == null)
            {
                throw new ResultXmlParserException(@"Can't find element (TestItem) in result xml file.");
            }
            foreach (var testItemElement in testItemElements)
            {
                var testItem = new TestItemTemplate
                {
                    SpecDetailId = int.Parse(GetElementValue(testItemElement, "SpecDetailId")),
                    OrderIdx = int.Parse(GetElementValue(testItemElement, "OrderIdx")),
                    TiltIdxs = GetElementValue(testItemElement, "TiltIdxs", ""),
                    TiltAngs = GetElementValue(testItemElement, "TiltAngs", ""),
                    MeasValue = CastToDecimal(GetElementValue(testItemElement, "MeasValue", "0"), 8, 3),
                    MeasString = GetElementValue(testItemElement, "MeasString", null),
                    MeasStatus = GetElementValue(testItemElement, "MeasStatus"),
                    PlotPath = GetElementValue(testItemElement, "PlotPath", null),
                    TracePath = GetElementValue(testItemElement, "TracePath", null),
                    Gen1 = GetElementValue(testItemElement, "Gen1", null),
                    TestExtend = GetTestExtend(testItemElement),
                    Traces = GetTraces(testItemElement),
                    CriterialItems = GetCriterialItems(testItemElement)
                };
                testItems.Add(testItem);
            }
            return testItems;
        }

        private decimal CastToDecimal(string value, int precision, int scale)
        {
            var result = decimal.Parse(value);
            return Math.Round(result, scale);
        }

        private List<TestTraceTemplate> GetTraces(XElement testItemElement)
        {
            var testTraces = new List<TestTraceTemplate>();
            var tracesElement = testItemElement.Element("Traces");
            if (tracesElement == null)
            {
                LogManager.GetLogger("Controller").Warn(@"Can't find element (Traces) in result xml file.");
                return testTraces;
                //throw new ResultXmlParserException(@"Can't find element (Traces) in result xml file.");
            }
            var traces = tracesElement.Elements("Trace");
            if (traces == null)
            {
                throw new ResultXmlParserException(@"Can't find element (Traces/Trace) in result xml file.");
            }
            foreach (var trace in traces)
            {
                var testTrace = new TestTraceTemplate
                {
                    Index = int.Parse(GetElementValue(trace, "Index")),
                    TraceName = GetElementValue(trace, "TraceName"),
                    X1 = GetElementValue(trace, "TraceX1", ""),
                    X2 = GetElementValue(trace, "TraceX2", ""),
                    X3 = GetElementValue(trace, "TraceX3", ""),
                    X4 = GetElementValue(trace, "TraceX4", ""),
                    Y1 = GetElementValue(trace, "TraceY1", ""),
                    Y2 = GetElementValue(trace, "TraceY2", ""),
                    Y3 = GetElementValue(trace, "TraceY3", ""),
                    Y4 = GetElementValue(trace, "TraceY4", "")
                };
                testTraces.Add(testTrace);
            }
            return testTraces;
        }

        private TestExtendTemplate GetTestExtend(XElement testItemElement)
        {
            var result = new TestExtendTemplate();
            var xElement = testItemElement.Element("TestExtend");
            if (xElement == null)
            {
                //LogManager.GetLogger("Controller").Warn(@"Can't find element (TestExtend) in result xml file.");
                return result;
                //throw new ResultXmlParserException(@"Can't find element (TestExtend) in result xml file.");
            }
            var elements = xElement.Elements("MeasValue");
            if (elements == null)
            {
                throw new ResultXmlParserException(@"Can't find element (TestExtend/MeasValue) in result xml file.");
            }
            foreach (var element in elements)
            {
                result.MeasValues.Add(element.Value);
            }
            return result;
        }

        private List<CriterialItemTemplate> GetCriterialItems(XElement testItemElement)
        {
            var criterialItems = new List<CriterialItemTemplate>();
            var criterialItemElement = testItemElement.Element("CriteriaItems");
            if (criterialItemElement == null)
            {
                //LogManager.GetLogger("Controller").Warn(@"Can't find element (TestExtend) in result xml file.");
                return criterialItems;
                //throw new ResultXmlParserException(@"Can't find element (CriterialItems) in result xml file.");
            }
            var items = criterialItemElement.Elements("Item");
            if (items == null)
            {
                throw new ResultXmlParserException(@"Can't find element (CriterialItems/Item) in result xml file.");
            }
            foreach (var itemElement in items)
            {
                var item = new CriterialItemTemplate
                {
                    CriteriaDetailId = int.Parse(GetElementValue(itemElement, "CriteriaDetailId")),
                    Descr = GetElementValue(itemElement, "Descr"),
                    LL = GetElementValue(itemElement, "LL"),
                    UL = GetElementValue(itemElement, "UL"),
                    Unit = GetElementValue(itemElement, "Unit"),
                    Value = GetElementValue(itemElement, "Value"),
                    Status = GetElementValue(itemElement, "Status")
                };
                criterialItems.Add(item);
            }
            return criterialItems;
        }

        private List<TestInstrumentTemplate> GetTestInstruments(XElement root)
        {
            var testInstruments = new List<TestInstrumentTemplate>();
            var parentElement = root.Element("TestInstruments");
            if (parentElement == null)
            {
                LogManager.GetLogger("Controller").Warn(@"Can't find element (TestInstruments) in result xml file.");
                return testInstruments;
                //throw new ResultXmlParserException(@"Can't find element (TestInstruments) in result xml file.");
            }
            var instrumentElements = parentElement.Elements("Instrument").ToArray();
            if (!instrumentElements.Any())
            {
                LogManager.GetLogger("Controller").Warn(@"Can't find element (TestInstruments/Instrument) in result xml file.");
                return testInstruments;
                //throw new ResultXmlParserException(@"Can't find element (TestInstruments/Instrument) in result xml file.");
            }
            foreach (var instrumentElement in instrumentElements)
            {
                var instrument = new TestInstrumentTemplate
                {
                    Model = GetElementValue(instrumentElement, "Model"),
                    SerialNumber = GetElementValue(instrumentElement, "SerialNumber"),
                    Hardware = GetElementValue(instrumentElement, "Hardware"),
                    Firmware = GetElementValue(instrumentElement, "Firmware"),
                    Idn = GetElementValue(instrumentElement, "Idn")
                };
                testInstruments.Add(instrument);
            }

            return testInstruments;
        }

        private HeadTemplate GetHeadInfo(XElement root)
        {
            var head = new HeadTemplate();
            var parentElement = root.Element("Head");
            if (parentElement == null)
            {
                throw new ResultXmlParserException(@"Can't find element (Head) in result xml file.");
            }
            head.SerialNumber = GetElementValue(parentElement, "SerialNumber");
            head.ProductMainId = int.Parse(GetElementValue(parentElement, "ProductMainId"));
            head.ProductModeId = int.Parse(GetElementValue(parentElement, "ProductModeId"));
            head.ProductMode = GetElementValue(parentElement, "ProductMode");
            head.SpecMainId = int.Parse(GetElementValue(parentElement, "SpecMainId"));
            head.PhaseMainId = int.Parse(GetElementValue(parentElement, "PhaseMainId"));
            head.PhaseName = GetElementValue(parentElement, "PhaseName");
            head.SoftwareRev = GetElementValue(parentElement, "SoftwareRev");
            head.MeasStartTime = TrimMicroSecond(GetElementValue(parentElement, "MeasStartTime"));
            head.MeasStopTime = TrimMicroSecond(GetElementValue(parentElement, "MeasStopTime"));
            head.MeasStatus = GetElementValue(parentElement, "MeasStatus");
            head.ConnectTime = GetElementValue(parentElement, "ConnectTime");
            head.MeasTime = GetElementValue(parentElement, "MeasTime");
            head.SetupTime = GetElementValue(parentElement, "SetupTime");
            head.TotalTime = GetElementValue(parentElement, "TotalTime");
            head.UserName = GetElementValue(parentElement, "UserName");
            head.Factory = GetElementValue(parentElement, "Factory");
            head.Controller = GetElementValue(parentElement, "Controller");
            head.WorkOrder = GetElementValue(parentElement, "WorkOrder", "");
            head.CoreNumber = GetElementValue(parentElement, "CoreNumber", null);
            var length_tmp = GetElementValue(parentElement, "Length", null);
            if (length_tmp != null)
            {
                head.Length = CastToDecimal(length_tmp, 8, 3);
            }
            var phaseStationMainId = GetElementValue(parentElement, "PhaseStationMainId", null);
            if (phaseStationMainId != null)
            {
                head.PhaseStationMainId = int.Parse(phaseStationMainId);
            }
            return head;
        }

        private List<AssyPartTemplate> GetAssyParts(XElement root)
        {
            var parts = new List<AssyPartTemplate>();
            var parentElement = root.Element("AssyParts");
            if (parentElement == null)
            {
                LogManager.GetLogger("Controller").Warn(@"Can't find element (AssyParts) in result xml file.");
                return parts;
                //throw new ResultXmlParserException(@"Can't find element (AssyParts) in result xml file.");
            }
            var partElements = parentElement.Elements("Part").ToArray();
            if (!partElements.Any())
            {
                LogManager.GetLogger("Controller").Warn(@"Can't find element (AssyParts/Part) in result xml file.");
                return parts;
                //throw new ResultXmlParserException(@"Can't find element (AssyParts/Part) in result xml file.");
            }
            foreach (var partElement in partElements)
            {
                var part = new AssyPartTemplate
                {
                    Index = int.Parse(GetElementValue(partElement, "Index")),
                    Model = GetElementValue(partElement, "Model"),
                    SerialNumber = GetElementValue(partElement, "SerialNumber"),
                    Hardware = GetElementValue(partElement, "Hardware"),
                    Firmware = GetElementValue(partElement, "Firmware"),

                    TiltMin = GetElementValue(partElement, "TiltMin"),
                    TiltMax = GetElementValue(partElement, "TiltMax")
                };
                try
                {
                    part.Mode = GetElementValue(partElement, "Mode");
                }
                catch
                {
                    LogManager.GetLogger("Controller").Warn(@"Compatibility - (Type) is used instead of (Mode)");
                    part.Mode = GetElementValue(partElement, "Type");
                }
                parts.Add(part);
            }
            return parts;
        }
    }
}
