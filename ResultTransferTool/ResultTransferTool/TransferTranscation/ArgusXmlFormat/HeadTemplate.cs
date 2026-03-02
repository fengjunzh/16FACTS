using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultTransferTool.TransferTranscation.ArgusXmlFormat
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
        public string MeasStatus;
        public string UserName;
        public int? EmployeeId;
        public string Factory;
        public int? FactoryId;
        public string Controller;
        public int? ControllerId;
        public DateTime MeasStartTime;
        public DateTime MeasStopTime;
        public int TotalTime;

        public int? MeasMainId;
        public int? MeasPhaseId;
        public int? PhaseMainId;
        public int? SpecMainId;
    }
}
