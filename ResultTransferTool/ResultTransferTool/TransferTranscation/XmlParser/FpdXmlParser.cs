using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ResultTransferTool.Exception;
using ResultTransferTool.TransferTranscation.FpdXmlFormat;

namespace ResultTransferTool.TransferTranscation.XmlParser
{
    class FpdXmlParser : BasicXmlParser
    {
        public TestResultTemplate GetTestResult(XDocument xDoc)
        {
            var result = new TestResultTemplate();
            var root = xDoc.Root;
            result.Type = int.Parse(GetElementValue(root, "Type"));
            result.DbConnString = GetDbConnString(root);
            result.Head = GetHeadInfo(root);
            result.Antenna.TestItems = GetTestItems(root);
            result.Antenna.SpecItems = GetSpecItems(root);
            return result;
        }

        protected override string GetDbConnString(XElement root)
        {
            try
            {
                var headElement = GetElementByName(root, "Head");
                return GetElementValue(headElement, "DBConnString");
            }
            catch (System.Exception)
            {
                //01/06/2022 adam comment for 42jx migrate
                //return "Data Source=asz-42jc23x; Initial Catalog=CATS; User ID=sa; Password=Asc4tore";
                return "";
            }
        }

        private List<SpecItemTemplate> GetSpecItems(XElement root)
        {
            var resp = new List<SpecItemTemplate>();
            var antennaElement = GetElementByName(root, "Antenna");
            var infoElement = GetElementByName(antennaElement, "Info");
            var bandsElement = GetElementByName(infoElement, "Bands");
            var bandsItems = bandsElement.Elements("Item");
            if (bandsItems == null)
            {
                throw new ResultXmlParserException(@"Can't find element (Bands -> Item) in result xml file.");
            }
            foreach (var item in bandsItems)
            {
                var indexValue = item.Attribute("Index").Value;
                var specElement = GetElementByName(item, "Spec");
                var bw = GetSpecMinMaxValue(specElement, "BW");
                var d = GetSpecMinMaxValue(specElement, "D");
                var lsl = GetSpecMinMaxValue(specElement, "LSL");
                var nullFill = GetSpecMinMaxValue(specElement, "NullFill");
                var sll = GetSpecMinMaxValue(specElement, "SLL");
                var tilt = GetSpecMinMaxValue(specElement, "Tilt");
                resp.Add(new SpecItemTemplate
                {
                    BandIndex = indexValue,
                    BwLowerLimit = bw[0],
                    BwUpperLimit = bw[1],
                    DLowerLimit = d[0],
                    DUpperLimit = d[1],
                    LSLLowerLimit = lsl[0],
                    LSLUpperLimit = lsl[1],
                    NullFillLowerLimit = nullFill[0],
                    NullFillUpperLimit = nullFill[1],
                    SLLLowerLimit = sll[0],
                    SLLUpperLimit = sll[1],
                    TiltLowerLimit = tilt[0],
                    TiltUpperLimit = tilt[1]
                });
            }
            return resp;
        }

        private double[] GetSpecMinMaxValue(XElement specElement, string name)
        {
            var returnValue = new double[2];
            var items = specElement.Elements("Item");
            foreach (var item in items)
            {
                if (item.Element("Name").Value == name)
                {
                    returnValue[0] = Convert.ToDouble(item.Element("Min").Value);
                    returnValue[1] = Convert.ToDouble(item.Element("Max").Value);
                    return returnValue;
                }
            }
            throw new ResultXmlParserException($"Can't find spec with name ({name}) in result xml file.");
        }

        private List<TestItemTemplate> GetTestItems(XElement root)
        {
            var resp = new List<TestItemTemplate>();
            var antennaElement = GetElementByName(root, "Antenna");
            var dataElement = GetElementByName(antennaElement, "Data");
            var testItemElements = dataElement.Elements("Item");
            if (testItemElements == null)
            {
                throw new ResultXmlParserException(@"Can't find element (Item) in result xml file.");
            }
            var index = 0;
            foreach (var item in testItemElements)
            {
                var patternElement = GetElementByName(item, "Pattern");
                var resultElement = GetElementByName(patternElement, "Result");
                var specIndex = item.Attribute("Band");
                if (specIndex == null)
                {
                    throw new ResultXmlParserException(@"Can't find attribute (Item Band Spec index) in result xml file.");
                }
                resp.Add(new TestItemTemplate
                {
                    Band = GetItemAttributeValueByName(item, "Band"),
                    Port = GetItemAttributeValueByName(item, "Port"),
                    Frequency = GetItemAttributeValueByName(item, "Freq"),
                    BW = GetTestValueByAttributeName(resultElement, "BW"),
                    Tilt = GetTestValueByAttributeName(resultElement, "Tilt"),
                    SLL = GetTestValueByAttributeName(resultElement, "SLL"),
                    D = GetTestValueByAttributeName(resultElement, "D"),
                    LSL = GetTestValueByAttributeName(resultElement, "LSL"),
                    NullFill = GetTestValueByAttributeName(resultElement, "NullFill"),
                    Curve = GetElementValue(patternElement, "Curve"),
                    SpecBandIndex = specIndex.Value,
                    id = index
                });
                index++;
            }
            return resp;
        }

        private string GetItemAttributeValueByName(XElement xElement, string name)
        {
            var attr = xElement.Attribute(name);
            if (attr == null)
            {
                throw new ResultXmlParserException($"Can't find attribute ({name}) in result xml file.");
            }
            return attr.Value;
        }

        private string GetElementValueByName(XElement xElement, string name)
        {
            var element = xElement.Element(name);
            if (element == null)
            {
                throw new ResultXmlParserException($"Can't find element ({name}) in result xml file.");
            }
            return element.Value;
        }

        private double GetTestValueByAttributeName(XElement resultElement, string name)
        {
            var element = resultElement.Elements("Item").Where(x => x.Attribute(name) != null);
            if (element == null)
            {
                throw new ResultXmlParserException($"Can't find attribute ({name}) in result xml file.");
            }
            return double.Parse(element.Attributes(name).First().Value);
        }

        private XElement GetElementByName(XElement xElement, string name)
        {
            var element = xElement.Element(name);
            if (element == null)
            {
                throw new ResultXmlParserException($"Can't find element ({name}) in result xml file.");
            }
            return element;
        }

        private HeadTemplate GetHeadInfo(XElement root)
        {
            var head = new HeadTemplate();
            var headElement = GetElementByName(root, "Head");
            head.SerialNumber = GetElementValue(headElement, "SerialNumber").Trim();
            head.ProductName = GetElementValue(headElement, "Model");
            head.PhaseName = "FPD";
            var timePoint = GetTimePoint(root);
            head.MeasStartTime = TrimMicroSecond(timePoint.StartTime);
            head.MeasStopTime = TrimMicroSecond(timePoint.EndTime);
            head.TotalTime = (int)(head.MeasStopTime - head.MeasStartTime).TotalSeconds;
            head.UserName = GetElementValue(headElement, "UserName");
            head.Controller = GetElementValue(headElement, "StationName");
            head.Mode = GetElementValue(headElement, "Mode");
            head.MeasStatus = GetElementValue(headElement, "Result");
            head.Factory = GetElementValue(headElement, "Factory");
            return head;
        }

        class TestTimePoint
        {
            public string StartTime;
            public string EndTime;
        }

        private TestTimePoint GetTimePoint(XElement root)
        {
            var resp = new TestTimePoint();
            var antennaElement = GetElementByName(root, "Antenna");
            var dataElement = GetElementByName(antennaElement, "Data");
            resp.StartTime = dataElement.Attribute("BeginTime").Value;
            resp.EndTime = dataElement.Attribute("EndTime").Value;
            return resp;
        }
    }
}
