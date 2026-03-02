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
    public class TestErrorFileCopyManager
    {
        [Test]
        public void RunTest()
        {
            var manager = new ErrorFileCopyManager(@"C:\Users\yz1048\Documents\CSC\Projects\TestSystem\ResultTransferTool\ResultTransferGUI\bin\x86\Debug\ResultsError");
            manager.Run();
        }
    }
}
