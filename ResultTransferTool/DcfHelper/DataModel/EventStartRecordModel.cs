using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcfHelper.DataModel
{
    public class EventStartRecordModel
    {
        public string RecordType;
        public string DcfRevision;
        public DateTime EventDateTime;
        public string EventType;
        public string ProductionSite;
        public string ProcessStep;
        public string Controller;
        public string Program;
        public string Resource;
        public string AssemblyType;
        public string SerialNumber;
        public string Operator;
    }
}
