using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nlogger;
using ResultTransferTool.Exception;
using ResultTransferTool.MTS;
using ResultTransferTool.TransferTranscation.ResultsXmlFormat;

namespace ResultTransferTool
{
    public class MTSResultUpdater
    {
        private readonly CacheBridge _bridge = new CacheBridge();
        private static string _lastFilePath = "";
        public IMTSProxy MTSProxyInstance = new MTSProxy();
        public IDialog MessageDialogInstance = new WindowsMessageBox();

        public void Run(string filePath, TestResultTemplate testResult)
        {
            LogManager.GetLogger("MTS").Info("Start to update result to MTS");
            if (filePath == _lastFilePath)
            {
                LogManager.GetLogger("MTS").Warn("Same file triggered, ignore");
                return;
            }
            _bridge.SetDbConnectionString(testResult.DbConnString);
            var rawResult = UpdateRawTestResult(testResult);
            var phaseName = rawResult.Head.PhaseName;
            Run(rawResult, phaseName);
            _lastFilePath = filePath;
            LogManager.GetLogger("MTS").Info("Finished to update result to MTS");
        }

        private string GetWorkStationName(string measurePhaseName)
        {
            var reader = new WorkStationDefinationManager();
            var workstationPhase = "";
            if (measurePhaseName == "RL_ISO")
            {
                workstationPhase = "RL_ISO";
            }
            if (measurePhaseName.Contains("PIM"))
            {
                workstationPhase = "PIM_Test";
            }
            var workStationName = reader.GetWorkStationName(workstationPhase);
            return workStationName;
        }

        private List<string> GetAlternateWorkStationName(string measurePhaseName)
        {
            var reader = new WorkStationDefinationManager();
            var workstationPhase = "";
            if (measurePhaseName == "RL_ISO")
            {
                workstationPhase = "RL_ISO";
            }
            if (measurePhaseName.Contains("PIM"))
            {
                workstationPhase = "PIM_Test";
            }
            var workStationName = reader.GetAlternateWorkStationName(workstationPhase);
            return workStationName;
        }

        private void UpdateValidWorkStationName(string measurePhaseName, string validStationName)
        {
            var reader = new WorkStationDefinationManager();
            reader.UpdateValidWorkStationName(measurePhaseName, validStationName);
        }

        public void Run(TestResultTemplate rawResult, string phaseName)
        {
            if (rawResult.Head.MeasStatus == "A")
            {
                LogManager.GetLogger("MTS").Info("Aborted test results, ignore.");
                return;
            }
            try
            {
                if (phaseName == "RL_ISO")
                {
                    if (rawResult.Head.MeasStatus == "F")
                    {
                        LogManager.GetLogger("MTS").Info("Failure Test Result.");
                    }
                    else
                    {
                        LogManager.GetLogger("MTS").Info("All spec are tested.");
                    }
                    UpdateToMTS(rawResult, phaseName);
                    return;
                }
                #region obsolate
                _bridge.RefreshCacheIfNeeded(rawResult.Head.ProductMainId, rawResult.Head.SerialNumber);
                _bridge.CacheCurrentTest(rawResult);
                if (rawResult.Head.MeasStatus == "F")
                {
                    LogManager.GetLogger("MTS").Info("Failure Test Result.");
                    UpdateToMTS(rawResult, phaseName);
                    return;
                }
                if (IsAllSpecTested(rawResult.Head.SerialNumber, rawResult.Head.ProductMainId, rawResult.Head.PhaseName, rawResult.Head.ProductMode))
                {
                    LogManager.GetLogger("MTS").Info("All spec are tested.");
                    UpdateToMTS(rawResult, phaseName);
                    return;
                }
                LogManager.GetLogger("MTS").Info("Not all spec are tested. Ignore");
                #endregion
            }
            catch (CatsSqlException e)
            {
                LogManager.GetLogger("MTS").Error(e.Message);
                MessageDialogInstance.ShowMessageBox("Network issue. Update to MTS failed");
                throw;
            }
        }

        private void UpdateToMTS(TestResultTemplate rawResult, string phaseName)
        {
            var workStationName = GetWorkStationName(phaseName);
            var mtsResult = BuilMTSResult(rawResult, workStationName);
            if (mtsResult.TestResult == "FAIL")
            {
                if (!MessageDialogInstance.UserConfirmToUpdate($"SerialNumber: {mtsResult.SN}. Result: {mtsResult.TestResult}. Fail Value: {mtsResult.FailValue}. Information: {mtsResult.FailReason}"))
                {
                    LogManager.GetLogger("MTS").Info("Test fail, user select ignore.");
                    return;
                }
            }
            if (!LoopUpdateTestResult(mtsResult, phaseName))
            {
                LogManager.GetLogger("MTS").Warn($"{mtsResult.SN} updates to MTS failed.");
                MessageDialogInstance.ShowMessageBox($"{mtsResult.SN} updates to MTS failed");
            }
        }

        public bool LoopUpdateTestResult(MTSTestResultTemplate mtsResult, string phaseName)
        {
            var names = new List<string>();
            names.Add(GetWorkStationName(phaseName));
            names.AddRange(GetAlternateWorkStationName(phaseName));
            foreach (var name in names)
            {
                mtsResult.WorkStationName = name;
                if (MTSProxyInstance.UpdateTestResult(mtsResult))
                {
                    UpdateValidWorkStationName(phaseName, name);
                    return true;
                }
            }
            return UpdateFileFromServerAndRetry(mtsResult, names, phaseName);
        }

        private bool UpdateFileFromServerAndRetry(MTSTestResultTemplate mtsResult, List<string> names, string phaseName)
        {
            var manager = new WorkStationDefinationManager();
            if (manager.UpdateFileFromServer())
            {
                var newNames = manager.GetAlternateWorkStationName(phaseName);
                foreach (var newName in newNames)
                {
                    if (names.Contains(newName))
                    {
                        continue;
                    }
                    mtsResult.WorkStationName = newName;
                    if (MTSProxyInstance.UpdateTestResult(mtsResult))
                    {
                        UpdateValidWorkStationName(phaseName, newName);
                        return true;
                    }
                }
            }
            return false;
        }

        private MTSTestResultTemplate BuilMTSResult(TestResultTemplate rawResult, string workStationName)
        {
            var mtsResult = new MTSTestResultTemplate
            {
                WorkStationName = workStationName,
                DateTime = DateTime.Now.ToString(),
                OperatorID = rawResult.Head.UserName,
                SN = rawResult.Head.SerialNumber,
                UUTType = _bridge.GetProductName(rawResult.Head.SerialNumber),
                TesterID = rawResult.Head.Controller,
                TestProgramRev = rawResult.Head.SoftwareRev
            };
            //var historyResults = GetTestStatus(rawResult.Head.SerialNumber, rawResult.Head.ProductMainId,
            //    rawResult.Head.PhaseName, rawResult.Head.ProductMode);
            //var testFinaleResult = historyResults.All(x => x.MeasStatus == "P");
            mtsResult.TestResult = rawResult.Head.MeasStatus == "P" ? "PASS" : "FAIL";
            var description = "";
            //foreach (var result in historyResults)
            //{
            //    description += result.MeasValue + ";";
            //}
            mtsResult.Description = description;
            var failReason = "";
            var failValue = "";
            mtsResult.FailReason = failReason;
            mtsResult.FailValue = failValue;
            return mtsResult;
        }

        private List<CacheTestDataModel> GetTestStatus(string sn, int productMainId, string phaseName, string mode)
        {
            var results = new List<CacheTestDataModel>();
            var specIds = _bridge.GetSpecMainIds(sn, productMainId, phaseName, mode);
            foreach (var specId in specIds)
            {
                var result = _bridge.GetTestResult(sn, specId);
                results.Add(result);
            }
            return results;
        }

        private bool IsAllSpecTested(string sn, int productMainId, string phaseName, string mode)
        {
            var specIds = _bridge.GetSpecMainIds(sn, productMainId, phaseName, mode);
            foreach (var specId in specIds)
            {
                var result = _bridge.GetTestResult(sn, specId);
                if (result == null)
                {
                    return false;
                }
            }
            return true;
        }

        private TestResultTemplate UpdateRawTestResult(TestResultTemplate rawResult)
        {
            UpdateMeasGroupRetestInfo(rawResult);
            UpdateMeasDetailRetestInfo(rawResult);
            return rawResult;
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
    }
}
