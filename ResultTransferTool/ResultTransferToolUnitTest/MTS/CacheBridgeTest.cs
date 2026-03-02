using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ResultTransferTool.MTS;
using ResultTransferTool.TransferTranscation.ResultsXmlFormat;

namespace ResultTransferToolUnitTest.MTS
{
    [TestFixture]
    class CacheBridgeTest
    {
        [Test]
        public void CacheCurrentTest()
        {
            var template = new TestResultTemplate();
            var head = new HeadTemplate
            {
                ProductMainId = 25,
                SerialNumber = "Test",
                MeasStartTime = DateTime.Parse("2016-12-01"),
                MeasStatus = "P",
                SpecMainId = 1
            };
            template.Head = head;
            var testGroup1 = new TestGroupTemplate
            {
                LastTestFlag = false
            };
            var testItem11 = new TestItemTemplate
            {
                LastTestFlag = true,
                MeasValue = 11,
                PlotPath = "Plot11"
            };
            testGroup1.TestItems.Add(testItem11);
            template.TestPhaseGroup.Add(testGroup1);
            var testGroup2 = new TestGroupTemplate
            {
                LastTestFlag = true
            };
            var testItem21 = new TestItemTemplate
            {
                LastTestFlag = false,
                MeasValue = 21,
                PlotPath = "Plot21"
            };
            var testItem22 = new TestItemTemplate
            {
                LastTestFlag = true,
                MeasValue = 22,
                PlotPath = "Plot22"
            };
            testGroup2.TestItems.Add(testItem21);
            testGroup2.TestItems.Add(testItem22);
            template.TestPhaseGroup.Add(testGroup2);
            var bridege = new CacheBridge();
            bridege.CacheCurrentTest(template);
            var result = bridege.GetTestResult("Test", template.Head.SpecMainId);
            Assert.AreEqual("Test", result.SerialNumber);
            Assert.AreEqual(DateTime.Parse("2016-12-01").ToString(), result.MeasStartTime);
            Assert.AreEqual("P", result.MeasStatus);
            Assert.AreEqual("22", result.MeasValue);
            Assert.AreEqual("Plot22", result.PlotPath);
            Assert.AreEqual(1, result.SpecMainId);
        }

        [Test]
        public void GetEmptyTable()
        {
            var bridge = new CacheBridge();
            Assert.IsNull(bridge.GetTestResult("16CN104712556", 1));

        }
    }
}
