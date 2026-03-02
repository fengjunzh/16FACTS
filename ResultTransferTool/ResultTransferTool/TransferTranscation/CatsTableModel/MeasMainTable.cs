using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultTransferTool.TransferTranscation.CatsTableModel
{
    class MeasMainTable
    {
        public int Id;
        public int ProductSnId;
        public int ProductModeId;
        public string Mode;
        public DateTime StartDateTime;
        public DateTime StopDateTime;
        public int DurationInMinute;
        public char MeasStatus;
        public string gen1;
        public string gen2;
        public string gen3;
    }

    interface IMeasMainTable
    {
        MeasMainTable GetMeasMainTable();
        void SetMeasMainId(int id);
    }
}
