using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultTransferTool.TransferTranscation.CatsTableModel
{
    class ProductSnTable
    {
        public int Id;
        public int ProductMainId;
        public string ProductSerialNumber;
        public DateTime RegisterDate;
        public bool validity;
        public int SnStatusId;
        public string gen1;
        public string gen2;
        public string gen3;
    }

    interface IProductSnTable
    {
        ProductSnTable GetProductSnTable();
    }
}
