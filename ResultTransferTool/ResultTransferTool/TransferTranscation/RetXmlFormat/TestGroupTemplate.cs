using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultTransferTool.TransferTranscation.RetXmlFormat
{
    class TestGroupTemplate
    {
        public string GroupName;
        public int Index;
        public string GroupStatus;
        public int? MeasGroupDcfId;
        public List<TestItemTemplate> TestItems = new List<TestItemTemplate>();
    }
}
