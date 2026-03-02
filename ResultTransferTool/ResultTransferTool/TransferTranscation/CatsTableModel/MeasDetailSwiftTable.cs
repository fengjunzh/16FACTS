using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultTransferTool.TransferTranscation.CatsTableModel
{
    class MeasDetailSwiftTable
    {
        public int Id;
        public int? TestItemId;
        public int MeasPhaseId;
        public string BandName;
        public string PortName;
        public decimal FrequencyInMHz;
        public decimal TiltUpperLimit;
        public decimal TiltLowerLimit;
        public decimal TiltMeasure;
        public decimal DUpperLimit;
        public decimal DLowerLimit;
        public decimal DMeasure;
        public decimal SllUpperLimit;
        public decimal SllLowerLimit;
        public decimal SllMeasure;
        public decimal LslUpperLimit;
        public decimal LslLowerLimit;
        public decimal LslMeasure;
        public decimal NullFillUpperLimit;
        public decimal NullFillLowerLimit;
        public decimal NullFillMeasure;
        public decimal BwUpperLimit;
        public decimal BwLowerLimit;
        public decimal BwMeasure;
    }

    interface IMeasDetailSwiftTable
    {
        List<MeasDetailSwiftTable> GetMeasDetailSwiftTable();
        void SetMeasDetailSwiftId(int id, int itemId);
    }
}
