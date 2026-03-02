using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultTransferTool.TransferTranscation.CatsTableModel
{
    abstract class CatsTestResult
    {
        public string DbConnString;

        protected int GetPorductMainId(string productName)
        {
            var catsSqlManager = new CatsSqlManager(DbConnString);
            return catsSqlManager.GetProductMainId(productName);
        }

        protected int GetProductSnId(string sn)
        {
            var catsSqlManager = new CatsSqlManager(DbConnString);
            return catsSqlManager.GetProductSnId(sn);
        }

        protected int GetProductModeId(int porductMainId, string mode)
        {
            var catsSqlManager = new CatsSqlManager(DbConnString);
            return catsSqlManager.GetProductModeId(porductMainId, mode);
        }

        protected int GetPhaseMainId(string phaseName)
        {
            var catsSqlManager = new CatsSqlManager(DbConnString);
            return catsSqlManager.GetPhaseMainId(phaseName);
        }

        protected int GetSpecMainId(string productName, string phaseName, string mode)
        {
            var catsSqlManager = new CatsSqlManager(DbConnString);
            return catsSqlManager.GetSpecMainId(productName, phaseName, mode);
        }
    }
}
