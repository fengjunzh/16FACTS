using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultTransferTool.TransferTranscation.ArgusXmlFormat
{
    class ArgusGroupTemplate
    {
        public string GroupName = "Argus_Station1";
        public int? MeasGroudDcfId;
        public int TestIdx = 0;
        public string GroupStatus;
        public RetConfigurationTemplate RetConfigurations = new RetConfigurationTemplate();
    }
}
