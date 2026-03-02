using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResultTransferTool.MTS;

namespace ResultTransferToolUnitTest.MTS
{
    class FakeMTSProxy : IMTSProxy
    {
        public bool DumpUpdateStatus = false;
        public bool UpdateTestResult(MTSTestResultTemplate result)
        {
            Console.WriteLine("WorkStationName: " + result.WorkStationName);
            Console.WriteLine("UUTType: " + result.UUTType);
            Console.WriteLine("SN: " + result.SN);
            Console.WriteLine("TestResult: " + result.TestResult);
            Console.WriteLine("DateTime: " + result.DateTime);
            Console.WriteLine("OperatorID: " + result.OperatorID);
            Console.WriteLine("TesterID: " + result.TesterID);
            Console.WriteLine("TestProgramRev: " + result.TestProgramRev);
            Console.WriteLine("FailReason: " + result.FailReason);
            Console.WriteLine("FailValue: " + result.FailValue);
            Console.WriteLine("Description: " + result.Description);
            return DumpUpdateStatus;
        }
    }
}
