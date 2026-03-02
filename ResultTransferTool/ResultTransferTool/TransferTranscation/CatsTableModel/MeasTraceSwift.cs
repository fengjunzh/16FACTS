using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultTransferTool.TransferTranscation.CatsTableModel
{
    class MeasTraceSwift
    {
        public int MeasDetailSwiftId;
        public int TraceIdx;
        public string TraceName;
        public int PointsNum;
        public string XData;
        public string YData;
    }

    interface IMeasTraceSwift
    {
        List<MeasTraceSwift> GetMeasTraceSwift();
    }
}
