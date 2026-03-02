using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultTransferTool.TransferTranscation.CatsTableModel
{
    class MeasGroupDcfTable
    {
        public int Id;
        public int MeasPhaseId;
        public string MeasGroupName;
        public int OrderIdx;
        public char GroupStatus;
        public int TestIdx;
        public bool LastTestFlag;
        public int DurationSec;
        public int ElapsedSec;
        public string Gen1;
        public string Gen2;
        public string Gen3;
        public int Gen4;
    }

    interface IMeasGroupDcfTables
    {
        List<MeasGroupDcfTable> GetMeasGroupDcfTables();
        void SetMeasGroupDcfId(int it, string GroupName, int testIndex);
    }
}
