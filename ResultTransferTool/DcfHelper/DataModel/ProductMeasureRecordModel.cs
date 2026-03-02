using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcfHelper.DataModel
{
    public class ProductMeasureRecordModel
    {
        public string RecordType;
        public string DcfRevision;
        public string TestDesignator;
        public string TestStatus;
        public string NonNumericValue;
        public double NumericValue;
        public string Units;
        public string LowerLimit;
        public string UpperLimit;
        public string GroupName;
        public int ElapsedTime;
        public int Index;
    }
}
