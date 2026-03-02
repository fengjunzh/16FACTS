using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultTransferTool.TransferTranscation.CatsTableModel
{
    class MeasPhaseTable
    {
        public int Id;
        public int MeasMainId;
        public int SpecMainId;
        public int PhaseMainId;
        public string Phase;
        public char PhaseStatus;
        public DateTime StartDateTime;
        public DateTime StopDateTime;
        public string SoftwareRev;
        public int EmployeeId;
        public int ControllerId;
        public int FactoryId;
        public bool ForcedStatus;
        public int ConnTime;
        public int MeasTime;
        public int SetupTime;
        public int TotalTime;
        //Comment to show phaseStationId is not supported
        //public int Gen1;
        public string Gen2;
        public string Gen3;
    }

    interface IMeasPhaseTable
    {
        MeasPhaseTable GetMeasPhaseTable();
        void SetMeasPhaseId(int id);
    }
}
