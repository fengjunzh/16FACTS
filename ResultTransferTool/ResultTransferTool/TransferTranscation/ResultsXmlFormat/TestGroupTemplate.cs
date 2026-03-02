using System.Collections.Generic;

namespace ResultTransferTool.TransferTranscation.ResultsXmlFormat
{
    public class TestGroupTemplate
    {
        public int GroupMainId;
        public string GroupName;
        public string GroupStatus;
        public int? MeasPhaseId;
        public bool? LastTestFlag;
        public int? TestIndex;
        public List<TestItemTemplate> TestItems;

        public TestGroupTemplate()
        {
            TestItems = new List<TestItemTemplate>();
        }
    }
}
