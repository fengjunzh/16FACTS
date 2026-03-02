using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultTransferTool.Exception
{
    public class ResultFormatVersionNotSupportedException : System.Exception
    {
        public ResultFormatVersionNotSupportedException(string msg) : base(msg)
        {
            
        }
    }
}
