using System;

namespace ResultTransferTool.TransferTranscation.ResultsXmlFormat
{
    public class HeadTemplate
    {
        public string SerialNumber { set { _serialNumber = value; } get { return _serialNumber.Trim(); } }
        public string WorkOrder;
        public int? WorkOrderId;
        public string CoreNumber; //Cable
        public decimal? Length; //Cable
        private string _serialNumber;
        public int ProductMainId;
        public int ProductModeId;
        public int? MeasureMainId;
        public string ProductMode;
        public int SpecMainId;
        public int PhaseMainId;
        public string PhaseName;
        public string SoftwareRev;
        public DateTime MeasStartTime;
        public DateTime MeasStopTime;
        public string MeasStatus;
        public string ConnectTime;
        public string MeasTime;
        public string SetupTime;
        public string TotalTime;
        public string UserName;
        public string Factory;
        public string Controller;
        public int? ControllerId;
        public int? EmployeeId;
        public int? FactoryId;
        public int? PhaseStationMainId;
    }
}
