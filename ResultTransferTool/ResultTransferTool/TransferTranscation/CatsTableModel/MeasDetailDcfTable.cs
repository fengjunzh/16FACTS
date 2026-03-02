using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultTransferTool.TransferTranscation.CatsTableModel
{
    class MeasDetailDcfTable
    {
        public int Id;
        public int MeasPhaseId;
        public int MeasGroupDcfId;
        public string MeasItem;
        public int OrderIdx;
        public decimal LimitLow;
        public decimal LimitUp;
        public string LimitString;
        public string LimitUnit;
        public decimal MeasValue;
        public string MeasString;
        public char MeasStatus;
        public string PlotPath;
        public string TracePath;
        public int TestIdx;
        public bool LastTestFlag;
        public int DurationSec;
        public int ElapsedSec;
        public string Gen1;
        public string Gen2;
        public string Gen3;
        public int Gen4;
    }

    interface IMeasDetailDcfTables
    {
        List<MeasDetailDcfTable> GetMeasDetailDcfTables();
    }
}
