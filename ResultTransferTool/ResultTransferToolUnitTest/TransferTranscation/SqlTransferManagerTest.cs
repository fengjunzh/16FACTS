using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using NUnit.Framework;
using ResultTransferTool.TransferTranscation;
using FileMode = ResultTransferTool.TransferTranscation.FileMode;

namespace ResultTransferToolUnitTest.TransferTranscation
{
    [TestFixture]
    class SqlTransferManagerTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Debug.Listeners.Add(new ConsoleTraceListener());
        }

        [Test]
        public void SingleTransfer()
        {
            var parser = new ResultXmlParser();
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TransferTranscation", "DumpFile", "TestResult.xml");
            var result = parser.GetPimOrRlIsoTestResult(filePath, FileMode.Normal);
            result.Head.ProductModeId = 2;
            result.Head.SpecMainId = 5;
            result.Head.PhaseMainId = 1;
            //result.Head.MeasStartTime = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            foreach (var testGroup in result.TestPhaseGroup)
            {
                testGroup.GroupMainId = 11;
                foreach (var testItem in testGroup.TestItems)
                {
                    testItem.SpecDetailId = 20;
                    foreach (var criterialItem in testItem.CriterialItems)
                    {
                        criterialItem.CriteriaDetailId = 5;
                    }
                }
            }

            var manager = new PimRlIsoSqlTransferManager();
            manager.Start(result);
        }
    }
}
