using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using NUnit.Framework;
using ResultTransferTool;

namespace ResultTransferToolUnitTest
{
    [TestFixture]
    public class ResultTransferControllerTest
    {
        [OneTimeSetUp]
        public void RegisterTrace()
        {
            Debug.Listeners.Add(new ConsoleTraceListener());
        }

        [Test]
        [Ignore("")]
        public void StartTransfer()
        {
            var folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Results");
            var controller = new ResultTransferController(folderPath);
            controller.Run();
            Thread.Sleep(5000);
            controller.Interrupt();
            try
            {
                controller.RunningTransferTask.Wait();
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}
