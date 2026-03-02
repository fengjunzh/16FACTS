using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcfHelper.DataModel
{
    public class DcfDataModel
    {
        public EventStartRecordModel StartRow = new EventStartRecordModel();
        public EventStopRecordModel StopRow = new EventStopRecordModel();
        public List<ProductMeasureRecordModel> MeasurementRows = new List<ProductMeasureRecordModel>();
    }
}
