using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultTransferTool.TransferTranscation.CatsTableModel
{
    class FactoryTable
    {
        public int Id;
        public string Name;
        public string Code;
        public string Description;
    }

    interface IFactoryTable
    {
        FactoryTable GetFactoryTable();
        void SetFactoryId(int id);
    }
}
