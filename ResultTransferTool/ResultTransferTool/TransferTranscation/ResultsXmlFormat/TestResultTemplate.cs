using ResultTransferTool.TransferTranscation.CatsTableModel;
using System.Collections.Generic;

namespace ResultTransferTool.TransferTranscation.ResultsXmlFormat
{
    public class TestResultTemplate
    {
        public int Type;
        public HeadTemplate Head;
        public TransferFlagTemplate Flag;
        public List<AssyPartTemplate> AssyParts;
        public List<TestInstrumentTemplate> TestInstruments;
        public List<TestGroupTemplate> TestPhaseGroup;
        public PhaseExtendCableTemplate PhaseExtendCable;
        public double FormatVersion;
        public string DbConnString;

        public TestResultTemplate()
        {
            AssyParts = new List<AssyPartTemplate>();
            TestInstruments = new List<TestInstrumentTemplate>();
            TestPhaseGroup = new List<TestGroupTemplate>();
            Flag = new TransferFlagTemplate();
        }
    }
}
