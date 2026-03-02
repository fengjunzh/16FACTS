using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using Nlogger;
using ResultTransferTool.Exception;
using ResultTransferTool.TransferTranscation.XmlParser;

namespace ResultTransferTool.TransferTranscation
{
    enum FileMode
    {
        Normal,
        Encryptor
    }

    enum TestType
    {
        PimRlIso,
        RET,
        FPD,
        Argus
    }

    class ResultXmlParser
    {
        public ResultsXmlFormat.TestResultTemplate GetPimOrRlIsoTestResult(string filePath, FileMode fileMode)
        {
            var xDoc = GetXDocument(filePath, fileMode);
            var parser = new PimRlIsoXmlParser();
            return parser.GetTestResult(xDoc);
        }

        public RetXmlFormat.TestResultTemplate GetRetTestResult(string filePath, FileMode fileMode)
        {
            var xDoc = GetXDocument(filePath, fileMode);
            var parser = new RetXmlParser();
            return parser.GetTestResult(xDoc);
        }

        public FpdXmlFormat.TestResultTemplate GetFpdTestResult(string filePath, FileMode fileMode)
        {
            var xDoc = GetXDocument(filePath, fileMode);
            var parser = new FpdXmlParser();
            return parser.GetTestResult(xDoc);
        }

        public ArgusXmlFormat.TestResultTemplate GetArgusTestResult(string filePath, FileMode fileMode)
        {
            var xDoc = GetXDocument(filePath, fileMode);
            var parser = new ArgusXmlParser();
            return parser.GetTestResult(xDoc);
        }

        public TestType GetTestResultType(string filePath, FileMode fileMode)
        {
            var xDoc = GetXDocument(filePath, fileMode);
            int.TryParse(xDoc.Root.Element("Type")?.Value, out int typeNumber);
            var typeIndex = typeNumber / 10;
            if (typeIndex == 2)
            {
                return TestType.RET;
            }
            if (typeIndex == 66)
            {
                return TestType.FPD;
            }
            if (typeIndex == 4)
            {
                return TestType.Argus;
            }
            return TestType.PimRlIso;
        }

        private XDocument GetXDocument(string filePath, FileMode fileMode)
        {
            XDocument xDoc;
            switch (fileMode)
            {
                case FileMode.Normal:
                    xDoc = XDocument.Load(filePath);
                    break;
                case FileMode.Encryptor:
                    try
                    {
                        var encryptor = new Encryptor.Encryptor();
                        xDoc = XDocument.Parse(encryptor.DecryptFromFile(filePath));
                    }
                    catch (System.Exception)
                    {
                        throw new ResultXmlParserException("dat file is invalid.");
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(fileMode), fileMode, null);
            }
            if (xDoc.Root == null)
            {
                throw new ResultXmlParserException("Result XML Root is null");
            }
            return xDoc;
        }
    }
}
