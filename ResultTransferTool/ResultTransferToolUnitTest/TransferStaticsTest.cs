using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ResultTransferTool;

namespace ResultTransferToolUnitTest
{
    [TestFixture]
    class TransferStaticsTest
    {
        [Test]
        public void TestWriteXml()
        {
            var staticsManager = new TransferStatics();

            staticsManager.TransferStaticFileToServerImmediately();
        }
    }
}
