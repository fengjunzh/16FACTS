using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultTransferTool.TransferTranscation.CatsTableModel
{
    class ControllerTable
    {
        public int Id;
        public string Name;
        public string Location;
        public int OwnerId;
        public int FactoryId;
    }

    interface IControllerTable
    {
        ControllerTable GetControllerTable();
        void SetControllerId(int controllerId);
    }
}
