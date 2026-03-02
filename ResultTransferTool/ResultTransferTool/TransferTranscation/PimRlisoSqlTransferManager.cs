using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using Nlogger;
using ResultTransferTool.Exception;
using ResultTransferTool.TransferTranscation.ResultsXmlFormat;
using ResultTransferTool.TransferTranscation.Utility;

namespace ResultTransferTool.TransferTranscation
{
    class PimRlIsoSqlTransferManager
    {
        private readonly CatsSqlProxy _transcation;
        private TestResultTemplate _testResult;
        private double _timeCost;
        public double TimeCost => _timeCost;

        public PimRlIsoSqlTransferManager()
        {
            _transcation = new CatsSqlProxy();
        }

        public void Start(string filePath)
        {
            Start(filePath, FileMode.Normal);
        }

        public void Start(string filePath, FileMode fileMode, bool needToInsertSn)
        {
            _testResult = ReadResultsFromFile(filePath, fileMode);
            Start(needToInsertSn);
        }

        public void Start(string filePath, FileMode fileMode)
        {
            _testResult = ReadResultsFromFile(filePath, fileMode);
            Start(false);
        }

        public void Start(TestResultTemplate testResult)
        {
            _testResult = testResult;
            Start(false);
        }

        private void Start(bool needToInsertSn)
        {
            var startTime = DateTime.Now;
            try
            {
                _transcation.ConnectionString = _testResult.DbConnString;
                if (needToInsertSn)
                {
                    CheckAndInsertSn(_testResult);
                }
                CheckAndInsertWorkOrder(_testResult);
                //Cable
                //CheckAndInsertProductCable(_testResult);
                CheckAndInsertMeasMain(_testResult);
                CheckAndInsertTesterInfo(_testResult);
                CheckAndInsertMeasPhase(_testResult);
                CheckAndInsertAssyParts(_testResult);
                CheckAndInsertMeasGroup(_testResult);
                CheckAndInsertMeasDetail(_testResult);
                //CheckAndInsertMeasCriteria(_testResult);
                //CheckAndInsertMeasExtend(_testResult);
                //CheckAndInsertMeasTrace(_testResult);
                CheckAndInsertMeasInstrument(_testResult);
                //Cable
                //CheckAndInsertPhaseExtendCable(_testResult);
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

        private void CheckAndInsertPhaseExtendCable(TestResultTemplate testResult)
        {
            if (testResult.PhaseExtendCable != null)
            {
                LogManager.GetLogger("SQL").Info("Step: CheckAndInsertPhaseExtendCable");
                _transcation.CheckAndInsertPhaseExtendCable(testResult);
            }
        }

        private void CheckAndInsertProductCable(TestResultTemplate testResult)
        {
            if (testResult.Head.CoreNumber != null)
            {
                LogManager.GetLogger("SQL").Info("Step: CheckAndInsertProductCable");
                _transcation.CheckAndInsertProductCable(testResult);
            }
        }

        private void CheckAndInsertSn(TestResultTemplate testResult)
        {
            LogManager.GetLogger("SQL").Info("Step: CheckSn");
            _transcation.CheckAndInsertSn(testResult);
        }

        private void CheckAndInsertWorkOrder(TestResultTemplate testResult)
        {
            LogManager.GetLogger("SQL").Info("Step: CheckWorkOrder");
            if (testResult.Head.WorkOrder == "")
            {
                LogManager.GetLogger("SQL").Info("Step: WorkOrder is not provided.");
                return;
            }
            _transcation.CheckAndInsertWorkOrder(testResult);
        }

        private void CheckAndInsertTesterInfo(TestResultTemplate testResult)
        {
            LogManager.GetLogger("SQL").Info("Step: CheckTesterInfo");
            _transcation.CheckAndInsertTesterInfo(testResult);
        }

        private void CheckAndInsertMeasInstrument(TestResultTemplate testResult)
        {
            LogManager.GetLogger("SQL").Info("Step: CheckMeasInstrument");
            _transcation.CheckAndInsertMeasInstrument(testResult);
        }

        //private void CheckAndInsertMeasTrace(TestResultTemplate testResult)
        //{
        //    LogManager.GetLogger("SQL").Info("Step: CheckMeasTrace");
        //    _transcation.CheckAndInsertMeasTrace(testResult);
        //}

        //private void CheckAndInsertMeasExtend(TestResultTemplate testResult)
        //{
        //    LogManager.GetLogger("SQL").Info("Step: CheckMeasExtend");
        //    _transcation.CheckAndInsertMeasExtend(testResult);
        //}

        //private void CheckAndInsertMeasCriteria(TestResultTemplate results)
        //{
        //    LogManager.GetLogger("SQL").Info("Step: CheckMeasCriteria");
        //    _transcation.CheckAndInsertMeasCriteria(results);
        //}

        private void CheckAndInsertMeasDetail(TestResultTemplate results)
        {
            LogManager.GetLogger("SQL").Info("Step: CheckMeasDetail");
            UpdateMeasDetailRetestInfo(results);
            _transcation.CheckAndInsertMeasDetail(results);
        }

        private void UpdateMeasDetailRetestInfo(TestResultTemplate results)
        {
            foreach (var testGroup in results.TestPhaseGroup)
            {
                foreach (var testItem in testGroup.TestItems)
                {
                    if (testItem.LastTestFlag.HasValue)
                    {
                        continue;
                    }
                    testItem.LastTestFlag = false;
                    testItem.TestIndex = 1;
                    var specDetailId = testItem.SpecDetailId;
                    var retest = testGroup.TestItems.Where(x => x.SpecDetailId == specDetailId && x.TestIndex.HasValue == false).ToList();
                    if (retest.Count == 0)
                    {
                        testItem.LastTestFlag = true;
                        continue;
                    }
                    for (int i = 0; i < retest.Count; i++)
                    {
                        retest[i].LastTestFlag = false;
                        retest[i].TestIndex = i + 2;
                    }
                    retest.Last().LastTestFlag = true;
                }
            }
        }

        private void CheckAndInsertMeasGroup(TestResultTemplate results)
        {
            LogManager.GetLogger("SQL").Info("Step: CheckMeasGroup");
            UpdateMeasGroupRetestInfo(results);
            _transcation.CheckAndInsertMeasGroup(results);
        }

        private void UpdateMeasGroupRetestInfo(TestResultTemplate results)
        {
            foreach (var testGroup in results.TestPhaseGroup)
            {
                if (testGroup.LastTestFlag.HasValue)
                {
                    continue;
                }
                testGroup.LastTestFlag = false;
                testGroup.TestIndex = 1;
                var groupMainId = testGroup.GroupMainId;
                var retest = results.TestPhaseGroup.Where(x => x.GroupMainId == groupMainId && x.TestIndex.HasValue == false).ToList();
                if (retest.Count == 0)
                {
                    testGroup.LastTestFlag = true;
                    continue;
                }
                for (int i = 0; i < retest.Count; i++)
                {
                    retest[i].LastTestFlag = false;
                    retest[i].TestIndex = i + 2;
                }
                retest.Last().LastTestFlag = true;
            }
        }

        private void CheckAndInsertMeasPhase(TestResultTemplate results)
        {
            LogManager.GetLogger("SQL").Info("Step: CheckMeasPhase");
            _transcation.CheckAndInsertMeasPhase(results);
        }

        private void CheckAndInsertMeasMain(TestResultTemplate results)
        {
            LogManager.GetLogger("SQL").Info("Step: CheckMeasMain");
            _transcation.CheckAndInsertMeasMain(results);
        }

        private void CheckAndInsertAssyParts(TestResultTemplate results)
        {
            LogManager.GetLogger("SQL").Info("Step: CheckAssyParts");
            _transcation.CheckAndInsertMeasAssyPart(results);
        }

        private TestResultTemplate ReadResultsFromFile(string filePath, FileMode fileMode)
        {
            LogManager.GetLogger("SQL").Info("Step: ReadResultsFromFile");
            var reader = new ResultXmlParser();
            return reader.GetPimOrRlIsoTestResult(filePath, fileMode);
        }
    }
}
