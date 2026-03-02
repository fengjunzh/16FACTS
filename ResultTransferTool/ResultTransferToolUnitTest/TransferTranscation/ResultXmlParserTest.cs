using System;
using System.IO;
using NUnit.Framework;
using ResultTransferTool.TransferTranscation;
using ResultTransferTool.TransferTranscation.ResultsXmlFormat;
using ResultTransferTool.Exception;
using FileMode = ResultTransferTool.TransferTranscation.FileMode;
//using TestType = ResultTransferTool.TransferTranscation.TestType;

namespace ResultTransferToolUnitTest.TransferTranscation
{
    [TestFixture]
    class ResultXmlParserTest
    {
        [Test]
        public void TestFlag()
        {
            var parser = new ResultXmlParser();
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TransferTranscation", "DumpFile", "TestResult.xml");
            var result = parser.GetPimOrRlIsoTestResult(filePath, FileMode.Normal);
            Assert.AreEqual(false, result.Flag.InsertSN);
            Assert.AreEqual(false, result.Flag.TransferToMTS);
            var filePathWithFlag = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TransferTranscation", "DumpFile", "TestResultWithFlag.xml");
            var resultWithFlag = parser.GetPimOrRlIsoTestResult(filePathWithFlag, FileMode.Normal);
            Assert.AreEqual(true, resultWithFlag.Flag.InsertSN);
            Assert.AreEqual(true, resultWithFlag.Flag.TransferToMTS);
        }

        [Test]
        public void TestGetTestResultType()
        {
            var parser = new ResultXmlParser();
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TransferTranscation", "DumpFile", "TestResultWithType.xml");
            var testType = parser.GetTestResultType(filePath, FileMode.Normal);
            Assert.AreEqual(TestType.FPD, testType);
            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TransferTranscation", "DumpFile", "TestResultWithoutType.xml");
            testType = parser.GetTestResultType(filePath, FileMode.Normal);
            Assert.AreEqual(TestType.PimRlIso, testType);
        }

        [Test]
        public void TestParseDumpXmlFile()
        {
            var parser = new ResultXmlParser();
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TransferTranscation", "DumpFile", "TestResult.xml");
            var result = parser.GetPimOrRlIsoTestResult(filePath, FileMode.Normal);
            AssertTestResult(result);
        }

        [Test]
        public void TestParseDumpXmlFileWithOptionalElement()
        {
            var parser = new ResultXmlParser();
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TransferTranscation", "DumpFile", "TestResultWithOptionalElement.xml");
            var result = parser.GetPimOrRlIsoTestResult(filePath, FileMode.Normal);
            Assert.AreEqual(0, result.AssyParts.Count);
            Assert.AreEqual(0, result.TestInstruments.Count);
        }

        [Test]
        public void TestParseEncryptorDumpXmlFile()
        {
            var xmlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TransferTranscation", "DumpFile", "TestResult.xml");
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TransferTranscation", "DumpFile", "Encrypted.dat");
            var parser = new ResultXmlParser();
            var encryptor = new Encryptor.Encryptor();
            var content = File.ReadAllText(xmlFilePath);
            encryptor.EncryptToFile(content, filePath);
            var result = parser.GetPimOrRlIsoTestResult(filePath, FileMode.Encryptor);
            AssertTestResult(result);
        }

        [Test]
        public void TestParseInvalidEncryptorDumpXmlFile()
        {
            var parser = new ResultXmlParser();
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TransferTranscation", "DumpFile", "InvalidEncrypted.dat");
            try
            {
                var result = parser.GetPimOrRlIsoTestResult(filePath, FileMode.Encryptor);
                Assert.Fail("Should not reach here");
            }
            catch (Exception e)
            {
                Assert.True(e is ResultXmlParserException);
            }
        }

        private void AssertTestResult(TestResultTemplate result)
        {
            Assert.AreEqual(3, result.Type);

            Assert.AreEqual("16CN103215733", result.Head.SerialNumber);
            Assert.AreEqual(6, result.Head.ProductMainId);
            Assert.AreEqual(2, result.Head.ProductModeId);
            Assert.AreEqual("ProductMode", result.Head.ProductMode);
            Assert.AreEqual(5, result.Head.SpecMainId);
            Assert.AreEqual(1, result.Head.PhaseMainId);
            Assert.AreEqual("PhaseName", result.Head.PhaseName);
            Assert.AreEqual("SoftwareRev", result.Head.SoftwareRev);
            Assert.AreEqual(DateTime.Parse("2016-01-10"), result.Head.MeasStartTime);
            Assert.AreEqual(DateTime.Parse("2016.01.11"), result.Head.MeasStopTime);
            Assert.AreEqual("15", result.Head.MeasStatus);
            Assert.AreEqual("16", result.Head.ConnectTime);
            Assert.AreEqual("17", result.Head.MeasTime);
            Assert.AreEqual("18", result.Head.SetupTime);
            Assert.AreEqual("19", result.Head.TotalTime);
            Assert.AreEqual("UserName", result.Head.UserName);
            Assert.AreEqual("Factory", result.Head.Factory);
            Assert.AreEqual("Controller", result.Head.Controller);

            Assert.AreEqual(26, result.AssyParts[0].Index);
            Assert.AreEqual("Model", result.AssyParts[0].Model);
            Assert.AreEqual("SerialNumber", result.AssyParts[0].SerialNumber);
            Assert.AreEqual("Hardware", result.AssyParts[0].Hardware);
            Assert.AreEqual("Firmware", result.AssyParts[0].Firmware);
            Assert.AreEqual("Type", result.AssyParts[0].Mode);
            Assert.AreEqual("32", result.AssyParts[0].TiltMin);
            Assert.AreEqual("33", result.AssyParts[0].TiltMax);


            Assert.AreEqual("Model1", result.TestInstruments[0].Model);
            Assert.AreEqual("SerialNumber1", result.TestInstruments[0].SerialNumber);
            Assert.AreEqual("Hardware1", result.TestInstruments[0].Hardware);
            Assert.AreEqual("Firmware1", result.TestInstruments[0].Firmware);
            Assert.AreEqual("Idn1", result.TestInstruments[0].Idn);

            Assert.AreEqual(11, result.TestPhaseGroup[0].GroupMainId);
            Assert.AreEqual("GroupName", result.TestPhaseGroup[0].GroupName);
            Assert.AreEqual("GroupStatus", result.TestPhaseGroup[0].GroupStatus);
            Assert.AreEqual(20, result.TestPhaseGroup[0].TestItems[0].SpecDetailId);
            Assert.AreEqual(52, result.TestPhaseGroup[0].TestItems[0].OrderIdx);
            Assert.AreEqual("TiltIdxs", result.TestPhaseGroup[0].TestItems[0].TiltIdxs);
            Assert.AreEqual("TiltAngs", result.TestPhaseGroup[0].TestItems[0].TiltAngs);
            Assert.AreEqual(55, result.TestPhaseGroup[0].TestItems[0].MeasValue);
            Assert.AreEqual("MeasString", result.TestPhaseGroup[0].TestItems[0].MeasString);
            Assert.AreEqual("MeasStatus", result.TestPhaseGroup[0].TestItems[0].MeasStatus);

            Assert.AreEqual("59", result.TestPhaseGroup[0].TestItems[0].TestExtend.MeasValues[0]);
            Assert.AreEqual("60", result.TestPhaseGroup[0].TestItems[0].TestExtend.MeasValues[1]);
            Assert.AreEqual("TraceName1", result.TestPhaseGroup[0].TestItems[0].Traces[0].TraceName);
            Assert.AreEqual("TraceX1", result.TestPhaseGroup[0].TestItems[0].Traces[0].X1);
            Assert.AreEqual("TraceX2", result.TestPhaseGroup[0].TestItems[0].Traces[0].X2);
            Assert.AreEqual("TraceX3", result.TestPhaseGroup[0].TestItems[0].Traces[0].X3);
            Assert.AreEqual("TraceX4", result.TestPhaseGroup[0].TestItems[0].Traces[0].X4);
            Assert.AreEqual(70, result.TestPhaseGroup[0].TestItems[0].Traces[0].Index);
            Assert.AreEqual(77, result.TestPhaseGroup[0].TestItems[0].Traces[1].Index);
            Assert.AreEqual("TraceName2", result.TestPhaseGroup[0].TestItems[0].Traces[1].TraceName);

            Assert.AreEqual(5, result.TestPhaseGroup[0].TestItems[0].CriterialItems[0].CriteriaDetailId);
            Assert.AreEqual("Descr", result.TestPhaseGroup[0].TestItems[0].CriterialItems[0].Descr);
            Assert.AreEqual("82", result.TestPhaseGroup[0].TestItems[0].CriterialItems[0].LL);
            Assert.AreEqual("83", result.TestPhaseGroup[0].TestItems[0].CriterialItems[0].UL);
            Assert.AreEqual("Unit", result.TestPhaseGroup[0].TestItems[0].CriterialItems[0].Unit);
            Assert.AreEqual("85", result.TestPhaseGroup[0].TestItems[0].CriterialItems[0].Value);
            Assert.AreEqual("Status", result.TestPhaseGroup[0].TestItems[0].CriterialItems[0].Status);

            Assert.AreEqual(11, result.TestPhaseGroup[1].GroupMainId);
            Assert.AreEqual(20, result.TestPhaseGroup[1].TestItems[1].SpecDetailId);
            Assert.AreEqual(5, result.TestPhaseGroup[1].TestItems[1].CriterialItems[1].CriteriaDetailId);
        }
    }
}
