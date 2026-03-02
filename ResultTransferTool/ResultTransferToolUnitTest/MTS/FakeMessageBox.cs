using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResultTransferTool.MTS;

namespace ResultTransferToolUnitTest.MTS
{
    class FakeMessageBox : IDialog
    {
        public bool UserConfirmToUpdate(string msg)
        {
            Console.WriteLine(msg);
            return false;
        }

        public void ShowMessageBox(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
