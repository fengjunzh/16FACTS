using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using ResultTransferTool;
using ResultTransferTool.TransferTranscation.ResultsXmlFormat;
using ResultTransferToolUnitTest.MTS;

namespace ResultTransferToolUnitTest
{
    [TestFixture]
    class MTSResultUpdaterTest
    {
        private readonly FakeMTSProxy _fakeMtsProxy = new FakeMTSProxy();
        private readonly FakeMessageBox _fakeMessageBox = new FakeMessageBox();

        [Test]
        public void FirstTest()
        {
            var controller = new MTSResultUpdater
            {
                MTSProxyInstance = _fakeMtsProxy,
                MessageDialogInstance = _fakeMessageBox
            };
            controller.Run(BuildFakeBasciTestResult("P"), "FakeStation");
        }

        private TestResultTemplate BuildFakeBasciTestResult(string measStatus)
        {
            var template = new TestResultTemplate();
            var head = new HeadTemplate
            {
                ProductMainId = 25,
                SerialNumber = "16CN104712556",
                MeasStartTime = DateTime.Parse("2016-12-01"),
                MeasStatus = measStatus,
                SpecMainId = 1,
                Controller = "Developer PC",
                UserName = "Visual Studio",
                SoftwareRev = "unit test",
                PhaseName = "PIM800"
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
            return template;
        }
    }
}
