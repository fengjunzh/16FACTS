using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DcfHelper;


namespace ResultTransferToolUnitTest.DCF
{
    [TestFixture]
    class TestDcfReader
    {
        [Test]
        public void TestFileNotExists()
        {
            try
            {
                var reader = new DcfReader();
                reader.Parser(@"C:\Tmp\NotExisted.dcf");
            }
            catch (System.IO.FileNotFoundException)
            {
                Assert.Pass();
                return;
            }
            Assert.Fail();
        }

        [Test]
        public void TestParseSingleDcf()
        {
            var reader = new DcfReader();
            var filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DCF", "DumpFile", "TestExample.dcf");
            var result = reader.Parser(filePath);
        }

        [Test]
        public void TestParseMultiDcf()
        {
            var reader = new DcfReader();
            var filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DCF", "DumpFile", "MultiTestExample.dcf");
            var result = reader.Parser(filePath);
        }

        [Test]
        public void Playground()
        {
            var number = int.Parse("");
        }
    }
}
