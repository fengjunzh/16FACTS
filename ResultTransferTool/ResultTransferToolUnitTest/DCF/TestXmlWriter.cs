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
    class TestXmlWriter
    {
        [Test]
        public void TestWriterSingleXml()
        {
            var filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DCF", "DumpFile", "TestExample.dcf");
            var extraPara = new ExtraPara()
            {
                //01/06/2022 adam comment for 42jx migrate
                //DbConnString = @"Data Source=asz-42jc23x; Initial Catalog=CATS; User ID=sa; Password=Asc4tore",
                DbConnString = @"",
                Mode = "RD"
            };
            var writer = new XmlWriter();
            writer.Write(filePath, extraPara);
        }

        [Test]
        public void TestWriteMultiXml()
        {
            var filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DCF", "DumpFile", "MultiTestExample.dcf");
            var extraPara = new ExtraPara()
            {
                //01/06/2022 adam comment for 42jx migrate
                //DbConnString = @"Data Source=asz-42jc23x; Initial Catalog=CATS; User ID=sa; Password=Asc4tore",
                DbConnString = @"",
                Mode = "TEST"
            };
            var writer = new XmlWriter();
            writer.Write(filePath, extraPara);
        }
    }
}
