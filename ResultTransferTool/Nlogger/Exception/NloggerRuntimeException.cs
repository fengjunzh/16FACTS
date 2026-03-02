using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlogger.Exception
{
    internal class NLoggerRuntimeException : System.Exception
    {
        public NLoggerRuntimeException(string msg) : base(msg)
        {

        }
    }
}
