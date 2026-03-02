using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ResultTransferTool;
using ResultTransferTool.MTS;
using ResultTransferTool.TransferTranscation.Utility;

namespace ResultTransferToolUnitTest.MTS
{
    [TestFixture]
    class MTSTest
    {
        [Test]
        public void UpdateTestResultTest()
        {
            var proxy = new MTSProxy();
            proxy.UpdateTestResult(new MTSTestResultTemplate());
        }

        [Test]
        public void GetSpeciMainIds()
        {
            var sn = "16CN104712556";
            var productMainId = 25;
            var proxy = new CatsSqlProxy();
            var ids = proxy.GetSpecsMainIds(sn, productMainId, "PIM", "PROD");
            Assert.AreEqual(13, ids[0]);
            Assert.AreEqual(14, ids[1]);
        }

        [Test]
        public void GetLastTestMeasStatus()
        {
            var sn = "16CN104712556";
            var specMainId = 13;
            var proxy = new CatsSqlProxy();
            var result = proxy.GetTestPhaseStatus(sn, specMainId);
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetLastTestMeasStatusShouldReturnNull()
        {
            var sn = "16CN104712556";
            var specMainId = 0;
            var proxy = new CatsSqlProxy();
            var result = proxy.GetTestPhaseStatus(sn, specMainId);
            Assert.AreEqual(0, result.Rows.Count);
        }

        [Test]
        public void GetProductName()
        {
            var sn = "16CN104712556";
            var proxy = new CatsSqlProxy();
            Assert.AreEqual("UNA010FI-0-V2", proxy.GetProductName(sn));
        }

        [Test]
        public void LoopUpdateMTS()
        {
            var updater = new MTSResultUpdater();
            updater.LoopUpdateTestResult(new MTSTestResultTemplate(), "RL_ISO");
        }
    }
}
