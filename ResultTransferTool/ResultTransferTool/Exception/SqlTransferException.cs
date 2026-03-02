using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultTransferTool.Exception
{
    class SqlTransferException : System.Exception
    {
        public SqlTransferException(string msg) : base(msg)
        {

        }
    }
}
