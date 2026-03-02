using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using ResultTransferTool.Exception;
using ResultTransferTool.TransferTranscation.ResultsXmlFormat;
using ResultTransferTool.TransferTranscation.Utility;

namespace ResultTransferTool.MTS
{
    public class CacheBridge
    {
        private MeasureStatusCache _cache = new MeasureStatusCache();
        private CatsSqlProxy _catsSqlProxy = new CatsSqlProxy();

        public void CacheCurrentTest(TestResultTemplate rawResult)
        {
            var statusResult = GetTestStatusResult(rawResult);
            _cache.RefreshCache(rawResult.Head.ProductMainId.ToString());
            _cache.CacheTestStatus(statusResult);
        }

        public void SetDbConnectionString(string connectionString)
        {
            _catsSqlProxy.ConnectionString = connectionString;
        }

        private CacheTestDataModel GetTestStatusResult(TestResultTemplate rawResult)
        {
            var statusResult = new CacheTestDataModel();
            statusResult.SerialNumber = rawResult.Head.SerialNumber;
            statusResult.MeasStartTime = rawResult.Head.MeasStartTime.ToString();
            statusResult.MeasStatus = rawResult.Head.MeasStatus;
            statusResult.SpecMainId = rawResult.Head.SpecMainId;
            try
            {
                var lastTestItem = rawResult.TestPhaseGroup.First(x => x.LastTestFlag == true).TestItems.First(x => x.LastTestFlag == true);
                statusResult.MeasValue = lastTestItem.MeasValue.ToString();
                statusResult.PlotPath = lastTestItem.PlotPath;
            }
            catch (System.Exception)
            {
                //ignore
            }

            return statusResult;
        }

        public void RefreshCacheIfNeeded(int productMainId, string sn)
        {
            if (_cache.RefreshCache(productMainId.ToString()))
            {
                var productName = GetProductNameFromCats(sn);
                _cache.CacheProductName(productName);
            }
        }

        public string GetProductName(string sn)
        {
            try
            {
                return _cache.GetProductName();

            }
            catch (MeasureStatusCacheException)
            {
                var productName = GetProductNameFromCats(sn);
                _cache.CacheProductName(productName);
                return productName;
            }
        }

        private string GetProductNameFromCats(string sn)
        {
            var retryCount = 0;
            while (retryCount < 10)
            {
                try
                {
                    return _catsSqlProxy.GetProductName(sn);
                }
                catch (System.Exception)
                {
                    retryCount++;
                    Thread.Sleep(1000);
                }
            }
            throw new CatsSqlException("Network error");
        }

        public int[] GetSpecMainIds(string sn, int productMainId, string phaseName, string mode)
        {
            try
            {
                return _cache.GetSpecMainIds(sn);
            }
            catch (MeasureStatusCacheException)
            {
                var ids = GetSpecsMainIdsFromDb(sn, productMainId, phaseName, mode);
                _cache.CacheSpecMainIds(sn, ids);
                return ids;
            }
        }

        private int[] GetSpecsMainIdsFromDb(string sn, int productMainId, string phaseName, string mode)
        {
            var retryCount = 0;
            while (retryCount < 6)
            {
                try
                {
                    string prefix = "";
                    if (phaseName == "RL_ISO")
                    {
                        prefix = "RL_ISO";
                    }
                    if (phaseName.Contains("PIM"))
                    {
                        prefix = "PIM";
                    }
                    return _catsSqlProxy.GetSpecsMainIds(sn, productMainId, prefix, mode);
                }
                catch (System.Exception)
                {
                    retryCount++;
                    Thread.Sleep(1000);
                }
            }
            throw new CatsSqlException("Network error");
        }

        public CacheTestDataModel GetTestResult(string sn, int specMainID)
        {
            var cacheResult = _cache.GetTestStatus(sn, specMainID);
            if (cacheResult == null)
            {
                var result = DumpResultFromCatsDb(sn, specMainID);
                if (result != null)
                {
                    _cache.CacheTestStatus(result);
                }
                return result;
            }
            return cacheResult;
        }

        private CacheTestDataModel DumpResultFromCatsDb(string sn, int specMainId)
        {
            var retryCount = 0;
            while (retryCount < 6)
            {
                try
                {
                    var result = new CacheTestDataModel();
                    var table = _catsSqlProxy.GetTestPhaseStatus(sn, specMainId);
                    var row = GetLastTestRow(table);
                    result.SerialNumber = sn;
                    result.SpecMainId = specMainId;
                    result.MeasStartTime = row["start_datetime"].ToString();
                    result.MeasStatus = row["phase_status"].ToString();
                    result.MeasValue = row["meas_value"].ToString();
                    result.PlotPath = row["plot_path"].ToString();
                    return result;
                }
                catch (CatsSqlException)
                {
                    return null;
                }
                catch (System.Exception e)
                {
                    Debug.WriteLine(e.Message);
                    retryCount++;
                    Thread.Sleep(1000);
                }
            }
            throw new CatsSqlException("Network error");
        }

        private DataRow GetLastTestRow(DataTable table)
        {
            if (table.Rows.Count == 0)
            {
                throw new CatsSqlException("Empty table");
            }
            //TODO:Bug, should loop plot name?
            var result = table.Rows[0];
            var lastTestDateTime = DateTime.Parse(result["start_datetime"].ToString());
            foreach (DataRow tableRow in table.Rows)
            {
                var testDateTime = DateTime.Parse(tableRow["start_datetime"].ToString());
                if (testDateTime > lastTestDateTime)
                {
                    result = tableRow;
                }
            }
            return result;
        }
    }
}
