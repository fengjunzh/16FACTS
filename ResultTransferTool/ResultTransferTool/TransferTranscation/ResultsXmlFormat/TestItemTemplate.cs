using System.Collections.Generic;

namespace ResultTransferTool.TransferTranscation.ResultsXmlFormat
{
    public class TestItemTemplate
    {
        public int? MeasGroupID;
        public int? MeasPhaseId;
        public bool? LastTestFlag;
        public int? TestIndex;
        public int SpecDetailId;
        public int OrderIdx;
        public string TiltIdxs;
        public string TiltAngs;
        public decimal MeasValue;
        public string MeasString;
        public string MeasStatus;
        public string PlotPath;
        public string TracePath;
        public string Gen1;
        public List<CriterialItemTemplate> CriterialItems;
        public TestExtendTemplate TestExtend;
        public List<TestTraceTemplate> Traces;

        public TestItemTemplate()
        {
            CriterialItems = new List<CriterialItemTemplate>();
            Traces = new List<TestTraceTemplate>();
            TestExtend = new TestExtendTemplate();
        }
    }
}
