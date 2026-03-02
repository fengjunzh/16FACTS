using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResultTransferTool.TransferTranscation;
using ResultTransferTool.TransferTranscation.CatsTableModel;
using Nlogger;
using ResultTransferTool.Exception;

namespace ResultTransferTool.TransferTranscation
{
    class TransferToCatsManager
    {
        private double _timeCost;
        private CatsSqlManager _catsSqlManager;

        public double TimeCost => _timeCost;

        public void Start(string filePath, FileMode fileMode)
        {
            var startTime = DateTime.Now;
            try
            {
                var parser = new ResultXmlParser();
                var testType = parser.GetTestResultType(filePath, fileMode);
                switch (testType)
                {
                    case TestType.PimRlIso:
                        Start(parser.GetPimOrRlIsoTestResult(filePath, fileMode));
                        break;
                    case TestType.RET:
                        Start(parser.GetRetTestResult(filePath, fileMode));
                        break;
                    case TestType.FPD:
                        Start(parser.GetFpdTestResult(filePath, fileMode));
                        break;
                    case TestType.Argus:
                        Start(parser.GetArgusTestResult(filePath, fileMode));
                        break;
                    default:
                        throw new NotImplementedException("Transfer To Cats For Default.");
                }
            }
            catch (SqlTransferExceptionWithoutRetry)
            {
                throw;
            }
            catch (System.Exception exception)
            {
                throw new SqlTransferException(exception.Message);
            }
            finally
            {
                _timeCost = (DateTime.Now - startTime).TotalSeconds;
                LogManager.GetLogger("SQL").Info($"Time cost: { _timeCost}");
            }

        }

        private void Start(FpdXmlFormat.TestResultTemplate testResult)
        {
            _catsSqlManager = new CatsSqlManager(testResult.DbConnString);
            CheckAndInsertSnTable(testResult);
            CheckAndInsertMeasMain(testResult);
            CheckAndInsertFactory(testResult);
            CheckAndInsertEmployee(testResult);
            CheckAndInsertController(testResult);
            CheckAndInsertMeasPhase(testResult);
            //CheckAndInsertMeasDetailSwiftTable(testResult);
            //CheckAndInsertMeasTraceSwiftTable(testResult);
        }

        private void Start(ResultsXmlFormat.TestResultTemplate testResult)
        {
            //Old Code is working.
            throw new NotImplementedException("Use old code instead for PimRlIso.");
        }

        private void Start(RetXmlFormat.TestResultTemplate testResult)
        {
            _catsSqlManager = new CatsSqlManager(testResult.DbConnString);
            CheckAndInsertSnTable(testResult);
            CheckAndInsertMeasMain(testResult);
            CheckAndInsertFactory(testResult);
            CheckAndInsertEmployee(testResult);
            CheckAndInsertController(testResult);
            CheckAndInsertMeasPhase(testResult);
            //CheckAndInsertMeasGroupDcf(testResult);
            //CheckAndInsertMeasDetailDcf(testResult);
        }

        private void Start(ArgusXmlFormat.TestResultTemplate testResult)
        {
            _catsSqlManager = new CatsSqlManager(testResult.DbConnString);
            CheckAndInsertSnTable(testResult);
            CheckAndInsertMeasMain(testResult);
            CheckAndInsertFactory(testResult);
            CheckAndInsertEmployee(testResult);
            CheckAndInsertController(testResult);
            CheckAndInsertMeasPhase(testResult);
            //CheckAndInsertMeasGroupDcf(testResult);
            //CheckAndInsertMeasDetailDcf(testResult);
        }

        private void CheckAndInsertSnTable(IProductSnTable testResult)
        {
            LogManager.GetLogger("SQL").Info("Step: Check SN Table");
            _catsSqlManager.CheckAndInsertSn(testResult);
        }

        private void CheckAndInsertMeasMain(IMeasMainTable testResult)
        {
            LogManager.GetLogger("SQL").Info("Step: Check MeasMain Table");
            _catsSqlManager.CheckAndInsertMeasMain(testResult);
        }

        private void CheckAndInsertController(IControllerTable testResult)
        {
            LogManager.GetLogger("SQL").Info("Step: Check Controller Table");
            _catsSqlManager.CheckAndInsertController(testResult);
        }

        private void CheckAndInsertFactory(IFactoryTable testResult)
        {
            LogManager.GetLogger("SQL").Info("Step: Check Factory Table");
            _catsSqlManager.CheckAndInsertFactory(testResult);
        }

        private void CheckAndInsertEmployee(IEmployeeTable testResult)
        {
            LogManager.GetLogger("SQL").Info("Step: Check Employee Table");
            _catsSqlManager.CheckAndInsertEmployee(testResult);
        }

        private void CheckAndInsertMeasPhase(IMeasPhaseTable results)
        {
            LogManager.GetLogger("SQL").Info("Step: Check MeasPhase Table");
            _catsSqlManager.CheckAndInsertMeasPhase(results);
        }

        //private void CheckAndInsertMeasGroupDcf(IMeasGroupDcfTables results)
        //{
        //    LogManager.GetLogger("SQL").Info("Step: Check MeasGroupDcf Table");
        //    _catsSqlManager.CheckAndInsertMeasGroupDcf(results);
        //}

        //private void CheckAndInsertMeasDetailDcf(IMeasDetailDcfTables results)
        //{
        //    LogManager.GetLogger("SQL").Info("Step: Check MeasDetailDcf Table");
        //    _catsSqlManager.CheckAndInsertMeasDetailDcf(results);
        //}

        //private void CheckAndInsertMeasDetailSwiftTable(IMeasDetailSwiftTable results)
        //{
        //    LogManager.GetLogger("SQL").Info("Step: Check MeasDetailSwift Table");
        //    _catsSqlManager.CheckAndInsertMeasDetailSwiftTable(results);
        //}

        //private void CheckAndInsertMeasTraceSwiftTable(IMeasTraceSwift results)
        //{
        //    LogManager.GetLogger("SQL").Info("Step: Check MeasTraceSwift Table");
        //    _catsSqlManager.CheckAndInsertMeasTraceSwiftTable(results);
        //}
    }
}
