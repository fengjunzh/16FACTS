using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ResultTransferTool.MTS;

namespace ResultTransferToolUnitTest.MTS
{
    [TestFixture]
    class WorkStationDefiniationManagerTest
    {
        [Test]
        public void NotValidXmlFile()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "NotValidXmlFile.xml");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            var file = File.Create(filePath);
            file.Close();
            var reader = new WorkStationDefinationManager(filePath);
            Assert.AreEqual("STS存盘", reader.GetWorkStationName("PIM_Test"));
            var anotherReader = new WorkStationDefinationManager(filePath);
            Assert.AreEqual("RLISO存盘", anotherReader.GetWorkStationName("RL_ISO"));
        }

        [Test]
        public void NotExistedlFile()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "NotExistedFile.xml");
            var reader = new WorkStationDefinationManager(filePath);
            reader.GetWorkStationName("PIM_Test");
            Assert.IsTrue(File.Exists(filePath));
        }

        [Test]
        public void GetAlternateStationNames()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AlternateStation.xml");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            var reader = new WorkStationDefinationManager(filePath);
            Assert.AreEqual("PIM存盘", reader.GetAlternateWorkStationName("PIM_Test")[0]);
            Assert.AreEqual("RL/ISO存盘", reader.GetAlternateWorkStationName("RL_ISO")[0]);
            Assert.AreEqual("RL_ISO存盘", reader.GetAlternateWorkStationName("RL_ISO")[1]);
        }

        [Test]
        public void UpdateWorkstationName()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AlternateStation.xml");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            var reader = new WorkStationDefinationManager(filePath);
            Assert.AreEqual("RLISO存盘", reader.GetWorkStationName("RL_ISO"));
            Assert.AreEqual("PIM存盘", reader.GetAlternateWorkStationName("PIM_Test")[0]);
            Assert.AreEqual("RL/ISO存盘", reader.GetAlternateWorkStationName("RL_ISO")[0]);
            Assert.AreEqual("RL_ISO存盘", reader.GetAlternateWorkStationName("RL_ISO")[1]);
            reader.UpdateValidWorkStationName("RL_ISO", "RLISO存盘");
            Assert.AreEqual("RLISO存盘", reader.GetWorkStationName("RL_ISO"));
            reader.UpdateValidWorkStationName("RL_ISO", "RL/ISO存盘");
            Assert.AreEqual("RL/ISO存盘", reader.GetWorkStationName("RL_ISO"));
            Assert.AreEqual("RLISO存盘", reader.GetAlternateWorkStationName("RL_ISO")[0]);
            Assert.AreEqual("RL_ISO", reader.GetTestTypeNodeName("RL/ISO存盘"));
        }

        [Test]
        public void UpdateFile()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AlternateStation.xml");
            var manager = new WorkStationDefinationManager(filePath);
            manager.UpdateFileFromServer();
        }
    }
}
