using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using NUnit.Framework;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ResultTransferTool;
using System.Globalization;

namespace ResultTransferToolUnitTest
{
    [TestFixture]
    class Playground
    {
        [Test]
        public void Play()
        {
            var path = Path.Combine(@"C:\Users\yz1048\Documents\CSC\Projects\TestSystem\ResultTransferTool\ResultTransferGUI\bin\x86\Debug\Updater\Configuration", "args.txt");
            var text = File.ReadAllText(path);
            text = "";
            var args = text.Substring(text.IndexOf(".exe") + 5);
            Console.WriteLine(args);
        }

        [Test]
        public void PlayReflect()
        {
            var argusData = new ResultTransferTool.TransferTranscation.ArgusXmlFormat.TestResultTemplate();
            argusData.ArgusGroup.RetConfigurations.SwitchToSRETforConfiguration = "NoNeed";
            argusData.ArgusGroup.RetConfigurations.Configuration = "PASS";
            argusData.ArgusGroup.RetConfigurations.ConfirmI2CFunction = "PASS";
            argusData.ArgusGroup.RetConfigurations.RETMode = "SRET";
            argusData.ArgusGroup.RetConfigurations.ConfirmConfirguration = "PASS";
            argusData.ArgusGroup.RetConfigurations.CycleTestFunction = "PASS";
            argusData.ArgusGroup.RetConfigurations.FinalTestResult = "PASS";
            argusData.SetMeasPhaseId(0);
            argusData.SetMeasGroupDcfId(0, "", 0);

            argusData.GetMeasDetailDcfTables();
        }
    }
}

