using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ResultTransferTool.MTS;

namespace ResultTransferToolUnitTest.MTS
{
    [TestFixture]
    class MeasureStatusCacheTest
    {
        [Test]
        public void HandleSpecMainIdsCache()
        {
            var cache = new MeasureStatusCache();
            try
            {
                cache.GetSpecMainIds("sn");
                Assert.Fail("Should throw exception");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Nothing found", e.Message);
            }
            cache.CacheSpecMainIds("sn", new[] { 1, 2, 3 }, DateTime.Parse("2016-12-01"));
            try
            {
                cache.GetSpecMainIds("sn");
                Assert.Fail("Should throw exception");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Buffer is out of date", e.Message);
            }
            cache.CacheSpecMainIds("sn", new[] { 1, 2, 3, 4 });
            var ids = cache.GetSpecMainIds("sn");
            Assert.AreEqual(4, ids[3]);
        }

        [Test]
        public void CacheTestStatusTest()
        {
            var cache = new MeasureStatusCache();
            Assert.IsNull(cache.GetTestStatus("First", 1));
            var firstTest = new CacheTestDataModel
            {
                SerialNumber = "First",
                MeasStartTime = "2016-12-01",
                MeasStatus = "PASS",
                SpecMainId = 10
            };
            var anotherFirstTest = new CacheTestDataModel
            {
                SerialNumber = "First",
                MeasStartTime = "2016-12-01",
                MeasStatus = "FAIL",
                SpecMainId = 13
            };
            var secondTest = new CacheTestDataModel
            {
                SerialNumber = "Second",
                MeasStartTime = "2016-12-01",
                MeasStatus = "FAIL",
                SpecMainId = 11
            };
            cache.CacheTestStatus(firstTest);
            cache.CacheTestStatus(secondTest);
            cache.CacheTestStatus(anotherFirstTest);
            Assert.AreEqual("PASS", cache.GetTestStatus("First", 10).MeasStatus);
            Assert.AreEqual("FAIL", cache.GetTestStatus("First", 13).MeasStatus);
            Assert.AreEqual("FAIL", cache.GetTestStatus("Second", 11).MeasStatus);
            Assert.IsNull(cache.GetTestStatus("First", 1));
            var oldTest = new CacheTestDataModel
            {
                SerialNumber = "Second",
                MeasStartTime = "2016-11-01",
                MeasStatus = "PASS",
                SpecMainId = 11
            };
            cache.CacheTestStatus(oldTest);
            Assert.AreEqual("FAIL", cache.GetTestStatus("Second", 11).MeasStatus);
            var newTest = new CacheTestDataModel
            {
                SerialNumber = "Second",
                MeasStartTime = "2016-12-11",
                MeasStatus = "PASS",
                SpecMainId = 11
            };
            cache.CacheTestStatus(newTest);
            Assert.AreEqual("PASS", cache.GetTestStatus("Second", 11).MeasStatus);
        }
    }
}
