using ResultTransferTool.Exception;
using ResultTransferTool.TransferTranscation.ResultsXmlFormat;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ResultTransferTool.TransferTranscation.XmlParser
{
    class BasicXmlParser
    {
        protected virtual string GetDbConnString(XElement root)
        {
            try
            {
                return root.Element("ConnString").Value;
            }
            catch (System.Exception)
            {
                //01/06/2022 adam comment for 42jx migrate
                //return "Data Source=asz-42jc23x; Initial Catalog=CATS; User ID=sa; Password=Asc4tore";
                return "";
            }
        }

        protected TransferFlagTemplate GetTransferFlagInfo(XElement root)
        {
            var result = new TransferFlagTemplate();
            try
            {
                result.InsertSN = bool.Parse(root.Element("Flag").Element("InsertSN").Value);
            }
            catch (System.Exception)
            {
                result.InsertSN = false;
            }
            try
            {
                result.TransferToMTS = bool.Parse(root.Element("Flag").Element("MTS").Value);
            }
            catch (System.Exception)
            {
                result.TransferToMTS = false;
            }
            return result;
        }

        protected string GetElementValue(XElement parentElement, string elementName)
        {
            var parentPath = "";
            var iteratorParent = parentElement;
            while (iteratorParent != null)
            {
                parentPath = parentPath.Insert(0, "/" + iteratorParent.Name);
                iteratorParent = iteratorParent.Parent;
            }
            var value = parentElement.Element(elementName);
            if (value == null)
            {
                throw new ResultXmlParserException($"Can't find element ({parentPath}/{elementName}) in result xml file.");
            }
            return value.Value;
        }

        protected string GetElementValue(XElement parentElement, string elementName, string defaultValue)
        {
            try
            {
                return GetElementValue(parentElement, elementName);
            }
            catch
            {
                return defaultValue;
            }
        }

        protected DateTime TrimMicroSecond(string time)
        {
            var orginalDateTime = DateTime.Parse(time, CultureInfo.InvariantCulture);
            return DateTime.Parse(orginalDateTime.ToString(CultureInfo.InvariantCulture));
        }
    }
}
