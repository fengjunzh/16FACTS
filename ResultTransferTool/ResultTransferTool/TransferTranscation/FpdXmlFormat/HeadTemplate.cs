using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultTransferTool.TransferTranscation.FpdXmlFormat
{
    class HeadTemplate
    {
        public string SerialNumber;
        public int? ProductSnId;
        public string ProductName;
        public int? ProductMainId;
        public string Mode;
        public int? ProductModeId;
        public string PhaseName;
        public string SoftwareRev;
        public DateTime MeasStartTime;
        public DateTime MeasStopTime;
        public string MeasStatus;
        public int TotalTime;
        public string UserName;
        public int? EmployeeId;
        public string Factory;
        public int? FactoryId;
        public string Controller;
        public int? ControllerId;
        public int? MeasMainId;
        public int? MeasPhaseId;
        public int? PhaseMainId;
        public int? SpecMainId;
    }
}
