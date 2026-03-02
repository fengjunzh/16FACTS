using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security.Policy;
using Nlogger;
using ResultTransferTool.Exception;
using ResultTransferTool.TransferTranscation.CatsTableModel;
using ResultTransferTool.TransferTranscation.ResultsXmlFormat;

namespace ResultTransferTool.TransferTranscation.Utility
{
    class CatsSqlProxy
    {
        //01/06/2022 adam comment for 42jx migrate
        //public string ConnectionString = "Data Source=asz-42jc23x; Initial Catalog=CATS; User ID=sa; Password=Asc4tore";
        public string ConnectionString = "";

        private int GetProductSnId(string serialNumber)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand($"SELECT id FROM product_sn WHERE product_serial_num='{serialNumber}'", conn);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        var result = reader.GetInt32(0);
                        return result;
                    }
                }
            }
            throw new CatsSqlException($"Can't find SN ({serialNumber}).");
        }

        public void CheckAndInsertMeasAssyPart(TestResultTemplate results)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                foreach (var assyPart in results.AssyParts)
                {
                    Debug.Assert(assyPart.MeasPhaseId != null, "assyPart.MeasPhaseId != null");

                    var command = new SqlCommand($"SELECT id FROM meas_assy_part WHERE meas_phase_id={assyPart.MeasPhaseId.Value} " +
                                                 $"AND part_sn='{assyPart.SerialNumber}'" +
                                                 $"AND part_idx={assyPart.Index}", conn);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            continue;
                        }
                    }
                    LogManager.GetLogger("SQL").Info($"Step: InsertAssyParts ({assyPart.Model})");
                    var measAssyPart = new FACTS.Model.meas_assy_part
                    {
                        part_idx = assyPart.Index,
                        part_model = assyPart.Model,
                        part_sn = assyPart.SerialNumber,
                        part_hw = assyPart.Hardware,
                        part_fw = assyPart.Firmware,
                        part_type = assyPart.Mode,
                        part_tilt_min = decimal.Parse(assyPart.TiltMin),
                        part_tilt_max = decimal.Parse(assyPart.TiltMax),
                        meas_phase_id = assyPart.MeasPhaseId.Value
                    };
                    AdjustDbConnString(results.DbConnString);
                    var helper = new FACTS.BLL.meas_assy_partManager();
                    helper.Add(measAssyPart);
                }
            }
        }

        internal void CheckAndInsertWorkOrder(TestResultTemplate results)
        {
            //prodct_wo table
            using (var conn = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand($"SELECT id FROM product_wo WHERE wo_descr='{results.Head.WorkOrder}'", conn);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        results.Head.WorkOrderId = reader.GetInt32(0);
                        Debug.WriteLine($"Get WorkOrderId as {results.Head.WorkOrderId.Value}");
                    }
                    else
                    {
                        var productWoTable = new FACTS.Model.product_wo
                        {
                            product_main_id = results.Head.ProductMainId,
                            wo_descr = results.Head.WorkOrder,
                            register_date = results.Head.MeasStartTime,
                            validation = true,
                            validity = true,
                            wo_status = 0
                        };
                        var helper = new FACTS.BLL.product_woManager();
                        AdjustDbConnString(results.DbConnString);
                        results.Head.WorkOrderId = helper.AddReturnId(productWoTable);
                    }
                }
            }
            //product_wo_sn table
            var productSnId = GetProductSnId(results.Head.SerialNumber);
            using (var conn = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand($"SELECT id FROM product_wo_sn WHERE product_wo_id={results.Head.WorkOrderId.Value} " +
                                             $"AND product_sn_id={productSnId}"
                                             , conn);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {

                    }
                    else
                    {
                        var productWoSnTable = new FACTS.Model.product_wo_sn
                        {
                            product_wo_id = results.Head.WorkOrderId.Value,
                            product_sn_id = productSnId,
                            validation_date = results.Head.MeasStartTime,
                            validity = true,
                            validation = true
                        };
                        var helper = new FACTS.BLL.product_wo_snManager();
                        AdjustDbConnString(results.DbConnString);
                        helper.Add(productWoSnTable);
                    }
                }
            }
        }

        internal void CheckAndInsertPhaseExtendCable(TestResultTemplate testResult)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand($"SELECT meas_phase_id FROM meas_phase_extend_cable " +
                    $"WHERE meas_phase_id={testResult.PhaseExtendCable.MeasPhaseId.Value}", conn);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        return;
                    }
                }
                LogManager.GetLogger("SQL").Info($"Step: Insert PhaseExtendCable.");
                var sp = new SqlCommand("proc_meas_phase_extend_cable_Add", conn);
                sp.Parameters.Add(new SqlParameter("@meas_phase_id", testResult.PhaseExtendCable.MeasPhaseId.Value));
                sp.Parameters.Add(new SqlParameter("@test_connector", testResult.PhaseExtendCable.TestConnector));
                sp.Parameters.Add(new SqlParameter("@test_length_m", testResult.PhaseExtendCable.TestLengthM));
                sp.Parameters.Add(new SqlParameter("@temperature_c", testResult.PhaseExtendCable.TemperatureC));
                sp.Parameters.Add(new SqlParameter("@notes", testResult.PhaseExtendCable.Notes));
                sp.Parameters.Add(new SqlParameter("@gen1", DBNull.Value));
                sp.Parameters.Add(new SqlParameter("@gen2", DBNull.Value));
                sp.Parameters.Add(new SqlParameter("@gen3", DBNull.Value));
                sp.Parameters.Add(new SqlParameter("@gen4", DBNull.Value));
                sp.Parameters.Add(new SqlParameter("@gen5", DBNull.Value));
                sp.CommandType = CommandType.StoredProcedure;
                sp.ExecuteNonQuery();
                conn.Close();
            }
        }

        internal void CheckAndInsertProductCable(TestResultTemplate testResult)
        {
            var productSnId = GetProductSnId(testResult.Head.SerialNumber);
            using (var conn = new SqlConnection(ConnectionString))
            {
                //Check if the record exists already
                var command = new SqlCommand($"SELECT * FROM product_cable " +
                    $"WHERE product_sn_id={productSnId} " +
                    $"AND core_number='{testResult.Head.CoreNumber}' " +
                    //TODO: original_length_ft to be changed
                    $"AND original_length_m={testResult.Head.Length}", conn);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        LogManager.GetLogger("SQL").Info($"Step: CoreNumber ({testResult.Head.CoreNumber}) exits already.");
                        return;
                    }
                }
                LogManager.GetLogger("SQL").Info($"Step: Insert CoreNumber ({testResult.Head.CoreNumber}).");
                var sp = new SqlCommand("proc_product_cable_Add", conn);
                sp.Parameters.Add(new SqlParameter("@core_number", testResult.Head.CoreNumber));
                sp.Parameters.Add(new SqlParameter("@product_sn_id", productSnId));
                sp.Parameters.Add(new SqlParameter("@original_length_m", testResult.Head.Length));
                sp.Parameters.Add(new SqlParameter("@gen1", DBNull.Value));
                sp.Parameters.Add(new SqlParameter("@gen2", DBNull.Value));
                sp.Parameters.Add(new SqlParameter("@gen3", DBNull.Value));
                sp.CommandType = CommandType.StoredProcedure;
                sp.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void AdjustDbConnString(string dbConnString)
        {
            var manager = new FACTS.BLL.CATSManager();
            manager.ActivateCATS(dbConnString);
        }

        public bool CheckMeasMainId(TestResultTemplate results)
        {
            if (results.Head.ProductModeId == 0)
            {
                throw new CatsSqlException($"Invalid PK id (product_mode_id={results.Head.ProductModeId})");
            }
            using (var conn = new SqlConnection(ConnectionString))
            {
                var productSnId = GetProductSnId(results.Head.SerialNumber);
                var command = new SqlCommand($"SELECT id,stop_datetime FROM meas_main WHERE product_sn_id={productSnId} " +
                                             $"AND product_mode_id={results.Head.ProductModeId}", conn);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        results.Head.MeasureMainId = reader.GetInt32(0);
                        Debug.WriteLine($"Get meas_main_id as {results.Head.MeasureMainId.Value}");
                        return true;
                    }
                }
            }
            return false;
        }

        public void UpdateMeasMain(TestResultTemplate results)
        {
            if (results.Head.ProductModeId == 0)
            {
                throw new CatsSqlException($"Invalid PK id (product_mode_id={results.Head.ProductModeId})");
            }
            using (var conn = new SqlConnection(ConnectionString))
            {
                var productSnId = GetProductSnId(results.Head.SerialNumber);
                var command = new SqlCommand($"SELECT id,stop_datetime FROM meas_main WHERE product_sn_id={productSnId} " +
                                             $"AND product_mode_id={results.Head.ProductModeId}", conn);
                conn.Open();
                DateTime lastEndTime = new DateTime();
                int? mainId = null;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        try
                        {
                            lastEndTime = reader.GetDateTime(1);
                        }
                        catch (System.Exception)
                        {
                            lastEndTime = DateTime.MinValue;
                        }
                        mainId = results.Head.MeasureMainId = reader.GetInt32(0);
                        Debug.WriteLine($"Get meas_main_id as {results.Head.MeasureMainId.Value}");
                    }
                }
                if (mainId.HasValue && lastEndTime < results.Head.MeasStopTime)
                {
                    var updateCommand = new SqlCommand($"UPDATE meas_main SET stop_datetime='{results.Head.MeasStopTime}' WHERE id={mainId}", conn);
                    updateCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// If id is default, then modified to null
        /// </summary>
        /// <param name="results"></param>
        private void UpdatePhaseStationMainId(TestResultTemplate results)
        {
            if (results.Head.PhaseStationMainId == null)
            {
                return;
            }
            using (var conn = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand($"SELECT default_validity FROM phase_station_main WHERE id={results.Head.PhaseStationMainId}", conn);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows && reader.Read() && reader.GetBoolean(0))
                    {
                        results.Head.PhaseStationMainId = null;
                    }
                }
            }
        }

        public bool CheckMeasPhaseId(TestResultTemplate results)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand($"SELECT id FROM meas_phase WHERE meas_main_id={results.Head.MeasureMainId} AND " +
                                             $"start_datetime='{results.Head.MeasStartTime}' AND stop_datetime='{results.Head.MeasStopTime}' AND " +
                                             (results.Head.PhaseStationMainId == null ? "gen1 is null" : $"gen1={results.Head.PhaseStationMainId}")
                                             , conn);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        var measurePhaseId = reader.GetInt32(0);
                        Debug.WriteLine($"Get meas_phase_id as {measurePhaseId}");
                        foreach (var assyPart in results.AssyParts)
                        {
                            assyPart.MeasPhaseId = measurePhaseId;
                        }
                        foreach (var testGroup in results.TestPhaseGroup)
                        {
                            testGroup.MeasPhaseId = measurePhaseId;
                            foreach (var testItem in testGroup.TestItems)
                            {
                                testItem.MeasPhaseId = measurePhaseId;
                            }
                        }
                        foreach (var instrument in results.TestInstruments)
                        {
                            instrument.MeasPhaseId = measurePhaseId;
                        }
                        if (results.PhaseExtendCable != null)
                        {
                            results.PhaseExtendCable.MeasPhaseId = measurePhaseId;
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        public void InsertMeasMain(TestResultTemplate results)
        {
            var measMain = new FACTS.Model.meas_main
            {
                product_sn_id = GetProductSnId(results.Head.SerialNumber),
                product_mode_id = results.Head.ProductModeId,
                mode = results.Head.ProductMode,
                start_datetime = results.Head.MeasStartTime,
                stop_datetime = results.Head.MeasStopTime
            };
            AdjustDbConnString(results.DbConnString);
            var helper = new FACTS.BLL.meas_mainManager();
            results.Head.MeasureMainId = helper.AddReturnId(measMain);
        }

        public void InsertMeasPhase(TestResultTemplate results)
        {
            Debug.Assert(results.Head.MeasureMainId != null, "results.Head.MeasureMainId != null");
            Debug.Assert(results.Head.ControllerId != null, "results.Head.ControllerId != null");
            Debug.Assert(results.Head.EmployeeId != null, "results.Head.EmployeeId != null");
            Debug.Assert(results.Head.FactoryId != null, "results.Head.FactoryId != null");
            var measPhase = new FACTS.Model.meas_phase
            {
                conn_time = int.Parse(results.Head.ConnectTime),
                meas_time = int.Parse(results.Head.MeasTime),
                setup_time = int.Parse(results.Head.SetupTime),
                total_time = int.Parse(results.Head.TotalTime),
                start_datetime = results.Head.MeasStartTime,
                stop_datetime = results.Head.MeasStopTime,
                phase = results.Head.PhaseName,
                software_rev = results.Head.SoftwareRev,
                spec_main_id = results.Head.SpecMainId,
                phase_main_id = results.Head.PhaseMainId,
                meas_main_id = results.Head.MeasureMainId.Value,
                phase_status = results.Head.MeasStatus,
                controller_id = results.Head.ControllerId.Value,
                employee_id = results.Head.EmployeeId.Value,
                factory_id = results.Head.FactoryId.Value,
                gen1 = results.Head.PhaseStationMainId
            };

            AdjustDbConnString(results.DbConnString);
            var helper = new FACTS.BLL.meas_phaseManager();
            var measurePhaseId = helper.AddReturnId(measPhase);
            foreach (var assyPart in results.AssyParts)
            {
                assyPart.MeasPhaseId = measurePhaseId;
            }
            foreach (var testGroup in results.TestPhaseGroup)
            {
                testGroup.MeasPhaseId = measurePhaseId;
                foreach (var testItem in testGroup.TestItems)
                {
                    testItem.MeasPhaseId = measurePhaseId;
                }
            }
            foreach (var instrument in results.TestInstruments)
            {
                instrument.MeasPhaseId = measurePhaseId;
            }
            if (results.PhaseExtendCable != null)
            {
                results.PhaseExtendCable.MeasPhaseId = measurePhaseId;
            }
        }

        public void CheckAndInsertMeasGroup(TestResultTemplate results)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                foreach (var testGroup in results.TestPhaseGroup)
                {
                    Debug.Assert(testGroup.MeasPhaseId != null, "testGroup.MeasPhaseId != null");
                    if (testGroup.GroupMainId == 0)
                    {
                        throw new CatsSqlException($"Invalid PK id (group_main_id={testGroup.GroupMainId})");
                    }

                    Debug.Assert(testGroup.TestIndex != null, "testGroup.TestIndex != null");
                    var command = new SqlCommand($"SELECT id FROM meas_group WHERE meas_phase_id={testGroup.MeasPhaseId.Value} " +
                                                 $"AND group_main_id={testGroup.GroupMainId}" +
                                                 $"AND test_idx={testGroup.TestIndex.Value}", conn);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            var readedMeasGroupId = reader.GetInt32(0);
                            Debug.WriteLine($"Get measure_group_id as {readedMeasGroupId}");
                            foreach (var testItem in testGroup.TestItems)
                            {
                                testItem.MeasGroupID = readedMeasGroupId;
                            }
                            continue;
                        }
                    }
                    LogManager.GetLogger("SQL").Info("Step: InsertMeasGroup");

                    Debug.Assert(testGroup.LastTestFlag != null, "testGroup.LastTestFlag != null");
                    var measGroup = new FACTS.Model.meas_group
                    {
                        meas_phase_id = testGroup.MeasPhaseId.Value,
                        group_main_id = testGroup.GroupMainId,
                        group_status = testGroup.GroupStatus,
                        test_idx = testGroup.TestIndex.Value,
                        last_test_flag = testGroup.LastTestFlag.Value
                    };
                    AdjustDbConnString(results.DbConnString);
                    var helper = new FACTS.BLL.meas_groupManager();
                    var measGroupId = helper.AddReturnId(measGroup);
                    foreach (var testItem in testGroup.TestItems)
                    {
                        testItem.MeasGroupID = measGroupId;
                    }
                }
            }
        }

        public void CheckAndInsertMeasDetail(TestResultTemplate results)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                foreach (var testGroup in results.TestPhaseGroup)
                {
                    foreach (var testItem in testGroup.TestItems)
                    {
                        Debug.Assert(testItem.MeasGroupID != null, "testItemTemplate.MeasGroupID != null");

                        Debug.Assert(testItem.TestIndex != null, "testItem.TestIndex != null");
                        var command = new SqlCommand($"SELECT id FROM meas_detail WHERE meas_group_id={testItem.MeasGroupID.Value} " +
                                                     $"AND spec_detail_id={testItem.SpecDetailId} " +
                                                     $"AND meas_value={testItem.MeasValue}" +
                                                     $"AND test_idx={testItem.TestIndex.Value}", conn);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                var readedMeasDetailId = reader.GetInt32(0);
                                Debug.WriteLine($"Get measure_group_id as {readedMeasDetailId}");
                                testItem.TestExtend.MeasDetailId = readedMeasDetailId;
                                foreach (var criterialItem in testItem.CriterialItems)
                                {
                                    criterialItem.MeasDetailId = readedMeasDetailId;
                                    criterialItem.SpeciDetailId = testItem.SpecDetailId;
                                }
                                foreach (var trace in testItem.Traces)
                                {
                                    trace.MeasDetailId = readedMeasDetailId;
                                }
                                continue;
                            }
                        }

                        LogManager.GetLogger("SQL").Info("Step: InsertMeasDetail");
                        Debug.Assert(testItem.LastTestFlag != null, "testItem.LastTestFlag != null");
                        Debug.Assert(testItem.MeasPhaseId != null, "testItem.MeasPhaseId != null");
                        var measDetail = new FACTS.Model.meas_detail
                        {
                            meas_status = testItem.MeasStatus,
                            meas_group_id = testItem.MeasGroupID.Value,
                            meas_string = testItem.MeasString,
                            meas_value = testItem.MeasValue,
                            order_idx = testItem.OrderIdx,
                            spec_detail_id = testItem.SpecDetailId,
                            plot_path = testItem.PlotPath,
                            trace_path = testItem.TracePath,
                            test_idx = testItem.TestIndex.Value,
                            last_test_flag = testItem.LastTestFlag.Value,
                            meas_phase_id = testItem.MeasPhaseId.Value,
                            gen1 = testItem.Gen1
                            
                        };
                        AdjustDbConnString(results.DbConnString);
                        var helper = new FACTS.BLL.meas_detailManager();
                        var measDetailId = helper.AddReturnId(measDetail);
                        testItem.TestExtend.MeasDetailId = measDetailId;
                        LogManager.GetLogger("SQL").Info("AAAAAAAAAAAAAAA MeasDetailID: "+ measDetailId.ToString());
                        foreach (var criterialItem in testItem.CriterialItems)
                        {
                            criterialItem.MeasDetailId = measDetailId;
                            criterialItem.SpeciDetailId = measDetail.spec_detail_id;
                        }
                        foreach (var trace in testItem.Traces)
                        {
                            trace.MeasDetailId = measDetailId;
                        }
                    }
                }
            }
        }

        //public void CheckAndInsertMeasCriteria(TestResultTemplate results)
        //{
        //    using (var conn = new SqlConnection(ConnectionString))
        //    {
        //        conn.Open();
        //        foreach (var testGroup in results.TestPhaseGroup)
        //        {
        //            foreach (var testItem in testGroup.TestItems)
        //            {
        //                foreach (var criterialItem in testItem.CriterialItems)
        //                {
        //                    Debug.Assert(criterialItem.MeasDetailId != null, "criterialItem.MeasDetailId != null");
        //                    Debug.Assert(criterialItem.SpeciDetailId != null, "criterialItem.SpeciDetailId != null");

        //                    var command = new SqlCommand($"SELECT id FROM meas_criteria WHERE meas_detail_id={criterialItem.MeasDetailId.Value} " +
        //                                                 $"AND spec_detail_id={criterialItem.SpeciDetailId} " +
        //                                                 $"AND criteria_detail_id={criterialItem.CriteriaDetailId} " +
        //                                                 $"AND meas_value={criterialItem.Value}", conn);
        //                    using (var reader = command.ExecuteReader())
        //                    {
        //                        if (reader.HasRows)
        //                        {
        //                            continue;
        //                        }
        //                    }

        //                    LogManager.GetLogger("SQL").Info($"Step: InsertCriteria ({criterialItem.Descr})");
        //                    var measCriteria = new FACTS.Model.meas_criteria
        //                    {
        //                        meas_status = criterialItem.Status,
        //                        criteria_detail_id = criterialItem.CriteriaDetailId,
        //                        meas_ll = decimal.Parse(criterialItem.LL),
        //                        meas_ul = decimal.Parse(criterialItem.UL),
        //                        meas_value = decimal.Parse(criterialItem.Value),
        //                        meas_item = criterialItem.Descr,
        //                        meas_detail_id = criterialItem.MeasDetailId.Value,
        //                        meas_unit = criterialItem.Unit,
        //                        spec_detail_id = criterialItem.SpeciDetailId.Value
        //                    };
        //                    AdjustDbConnString(results.DbConnString);
        //                    var helper = new FACTS.BLL.meas_criteriaManager();
        //                    helper.Add(measCriteria);
        //                }
        //            }
        //        }
        //    }
        //}

        //public void CheckAndInsertMeasTrace(TestResultTemplate testResult)
        //{
        //    using (var conn = new SqlConnection(ConnectionString))
        //    {
        //        conn.Open();
        //        foreach (var testGroup in testResult.TestPhaseGroup)
        //        {
        //            foreach (var testItem in testGroup.TestItems)
        //            {
        //                foreach (var trace in testItem.Traces)
        //                {
        //                    Debug.Assert(trace.MeasDetailId != null, "trace.MeasDetailId != null");

        //                    var command = new SqlCommand($"SELECT meas_detail_id FROM meas_trace WHERE meas_detail_id={trace.MeasDetailId.Value} " +
        //                                                 $"AND trace_idx={trace.Index}", conn);
        //                    using (var reader = command.ExecuteReader())
        //                    {
        //                        if (reader.HasRows)
        //                        {
        //                            continue;
        //                        }
        //                    }

        //                    LogManager.GetLogger("SQL").Info($"Step: InsertMeasTrace ({trace.TraceName})");
        //                    var traceModel = new CATS.Model.meas_trace
        //                    {
        //                        trace_idx = trace.Index,
        //                        trace_name = trace.TraceName,
        //                        x1_data = trace.X1,
        //                        x2_data = trace.X2,
        //                        x3_data = trace.X3,
        //                        x4_data = trace.X4,
        //                        y1_data = trace.Y1,
        //                        y2_data = trace.Y2,
        //                        y3_data = trace.Y3,
        //                        y4_data = trace.Y4,
        //                        meas_detail_id = trace.MeasDetailId.Value
        //                    };
        //                    AdjustDbConnString(testResult.DbConnString);
        //                    var helper = new CATS.BLL.meas_traceManager();
        //                    helper.Add(traceModel);
        //                }
        //            }
        //        }
        //    }
        //}

        //public void CheckAndInsertMeasExtend(TestResultTemplate testResult)
        //{
        //    using (var conn = new SqlConnection(ConnectionString))
        //    {
        //        conn.Open();
        //        foreach (var testGroup in testResult.TestPhaseGroup)
        //        {
        //            foreach (var testItem in testGroup.TestItems)
        //            {
        //                Debug.Assert(testItem.TestExtend.MeasDetailId != null, "testItem.TestExtend.MeasDetailId != null");

        //                var command = new SqlCommand($"SELECT meas_detail_id FROM meas_detail_extend WHERE meas_detail_id={testItem.TestExtend.MeasDetailId.Value} ", conn);
        //                using (var reader = command.ExecuteReader())
        //                {
        //                    if (reader.HasRows)
        //                    {
        //                        continue;
        //                    }
        //                }

        //                LogManager.GetLogger("SQL").Info("Step: InsertMeasExtend");
        //                var extendModel = new CATS.Model.meas_detail_extend
        //                {
        //                    meas_detail_id = testItem.TestExtend.MeasDetailId.Value,
        //                };
        //                var valueCount = testItem.TestExtend.MeasValues.Count;
        //                for (int i = 0; i < valueCount; i++)
        //                {
        //                    var propertyName = "m" + (i + 1);
        //                    var type = extendModel.GetType();
        //                    var propertyInfo = type.GetProperty(propertyName);
        //                    propertyInfo.SetValue(extendModel, testItem.TestExtend.MeasValues[i]);
        //                }
        //                AdjustDbConnString(testResult.DbConnString);
        //                var helper = new CATS.BLL.meas_detail_extendManager();
        //                helper.Add(extendModel);
        //            }
        //        }
        //    }
        //}

        public void CheckAndInsertMeasInstrument(TestResultTemplate testResult)
        {
            InsertOrGetInstrModelId(testResult);
            InsertOrGetInstrMainId(testResult);
            InsertMeasInstrumentTable(testResult);
        }

        private void InsertMeasInstrumentTable(TestResultTemplate testResult)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                foreach (var testInstrument in testResult.TestInstruments)
                {
                    Debug.Assert(testInstrument.InstrMainId != null, "testInstrument.InstrMainId != null");
                    Debug.Assert(testInstrument.MeasPhaseId != null, "testInstrument.MeasPhaseId != null");

                    var command = new SqlCommand($"SELECT meas_phase_id FROM meas_instr WHERE meas_phase_id={testInstrument.MeasPhaseId.Value} " +
                                                 $"AND instr_main_id={testInstrument.InstrMainId.Value}", conn);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            continue;
                        }
                    }

                    LogManager.GetLogger("SQL").Info("Step: InsertInstrumentTable");
                    var model = new FACTS.Model.meas_instr
                    {
                        meas_phase_id = testInstrument.MeasPhaseId.Value,
                        instr_main_id = testInstrument.InstrMainId.Value
                    };
                    AdjustDbConnString(testResult.DbConnString);
                    var helper = new FACTS.BLL.meas_instrManager();
                    helper.Add(model);
                }
            }
        }

        private void InsertOrGetInstrModelId(TestResultTemplate testResult)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                foreach (var instrument in testResult.TestInstruments)
                {
                    var modelName = instrument.Model;
                    var command = new SqlCommand($"SELECT id FROM instr_model WHERE name='{modelName}'", conn);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            var instrModelId = reader.GetInt32(0);
                            instrument.InstrModelId = instrModelId;
                            Debug.WriteLine($"Get instr_model_id as {instrModelId}");
                        }
                        else
                        {
                            LogManager.GetLogger("SQL").Info("Step: InsertInstrumentModel");
                            var instrModel = new FACTS.Model.instr_model
                            {
                                name = modelName
                            };
                            AdjustDbConnString(testResult.DbConnString);
                            var helper = new FACTS.BLL.instr_modelManager();
                            var instrModelId = helper.AddReturnId(instrModel);
                            instrument.InstrModelId = instrModelId;
                        }
                    }
                }
            }
        }

        private void InsertOrGetInstrMainId(TestResultTemplate testResult)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                foreach (var instrument in testResult.TestInstruments)
                {
                    var instrModelId = instrument.InstrModelId;
                    var sn = instrument.SerialNumber;
                    var command = new SqlCommand($"SELECT id FROM instr_main WHERE instr_model_id={instrModelId} " +
                                                 $"AND serial_num='{sn}'", conn);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            var instrMainId = reader.GetInt32(0);
                            instrument.InstrMainId = instrMainId;
                            Debug.WriteLine($"Get instr_main_id as {instrMainId}");
                        }
                        else
                        {
                            LogManager.GetLogger("SQL").Info($"Step: InsertInstrumentMain ({instrument.Idn})");
                            Debug.Assert(instrModelId != null, "instrModelId != null");
                            var instrMain = new FACTS.Model.instr_main
                            {
                                instr_model_id = instrModelId.Value,
                                serial_num = sn,
                                hw_version = instrument.Hardware,
                                fw_version = instrument.Firmware,
                                instr_idn = instrument.Idn,
                                entry_date = DateTime.Today
                            };
                            AdjustDbConnString(testResult.DbConnString);
                            var helper = new FACTS.BLL.instr_mainManager();
                            var instrMainId = helper.AddReturnId(instrMain);
                            instrument.InstrMainId = instrMainId;
                        }
                    }
                }
            }
        }

        public void CheckAndInsertMeasPhase(TestResultTemplate results)
        {
            //UpdatePhaseStationMainId(results);
            if (!CheckMeasPhaseId(results))
            {
                LogManager.GetLogger("SQL").Info("Step: InsertMeasPhase");
                InsertMeasPhase(results);
            }
        }

        public void CheckAndInsertMeasMain(TestResultTemplate results)
        {
            if (!CheckMeasMainId(results))
            {
                LogManager.GetLogger("SQL").Info("Step: InsertMeasMain");
                InsertMeasMain(results);
            }
            else
            {
                LogManager.GetLogger("SQL").Info("Step: UpdateMeasMain");
                UpdateMeasMain(results);
            }
        }

        public void CheckAndInsertTesterInfo(TestResultTemplate results)
        {
            if (!CheckFactory(results))
            {
                LogManager.GetLogger("SQL").Info("Step: InsertFactory");
                InsertFactory(results);
            }
            if (!CheckEmployee(results))
            {
                LogManager.GetLogger("SQL").Info("Step: InsertEmployee");
                InsertEmployee(results);
            }
            if (!CheckController(results))
            {
                LogManager.GetLogger("SQL").Info("Step: InsertController");
                InsertController(results);
            }
        }

        private void InsertFactory(TestResultTemplate results)
        {
            var model = new FACTS.Model.factory { name = results.Head.Factory };
            AdjustDbConnString(results.DbConnString);
            var helper = new FACTS.BLL.factoryManager();
            var id = helper.AddReturnId(model);
            results.Head.FactoryId = id;
        }

        private bool CheckFactory(TestResultTemplate results)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand($"SELECT id FROM factory WHERE name='{results.Head.Factory}'", conn);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        var factoryId = reader.GetInt32(0);
                        Debug.WriteLine($"Get factory_id as {factoryId}");
                        results.Head.FactoryId = factoryId;
                        return true;
                    }
                }
            }
            return false;
        }

        private void InsertController(TestResultTemplate results)
        {
            Debug.Assert(results.Head.EmployeeId != null, "results.Head.EmployeeId != null");
            Debug.Assert(results.Head.FactoryId != null, "results.Head.FactoryId != null");
            var model = new FACTS.Model.controller
            {
                name = results.Head.Controller,
                owner_id = results.Head.EmployeeId.Value,
                factory_id = results.Head.FactoryId.Value
            };
            AdjustDbConnString(results.DbConnString);
            var helper = new FACTS.BLL.controllerManager();
            var id = helper.AddReturnId(model);
            results.Head.ControllerId = id;
        }

        private bool CheckController(TestResultTemplate results)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand($"SELECT id FROM controller WHERE name='{results.Head.Controller}' AND factory_id='{results.Head.FactoryId}'", conn);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        var controllerId = reader.GetInt32(0);
                        Debug.WriteLine($"Get controller_id as {controllerId}");
                        results.Head.ControllerId = controllerId;
                        return true;
                    }
                }
            }
            return false;
        }

        private void InsertEmployee(TestResultTemplate results)
        {
            Debug.Assert(results.Head.FactoryId != null, "results.Head.FactoryId != null");
            var model = new FACTS.Model.employee
            {
                login_name = results.Head.UserName,
                factory_id = results.Head.FactoryId.Value
            };
            AdjustDbConnString(results.DbConnString);
            var helper = new FACTS.BLL.employeeManager();
            var id = helper.AddReturnId(model);
            results.Head.EmployeeId = id;
        }

        private bool CheckEmployee(TestResultTemplate results)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand($"SELECT id FROM employee WHERE login_name='{results.Head.UserName}'", conn);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        var employeeId = reader.GetInt32(0);
                        Debug.WriteLine($"Get employee_id as {employeeId}");
                        results.Head.EmployeeId = employeeId;
                        return true;
                    }
                }
            }
            return false;
        }

        public void CheckAndInsertSn(TestResultTemplate testResult)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand($"SELECT id,product_main_id FROM product_sn WHERE product_serial_num='{testResult.Head.SerialNumber}'", conn);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        var productMainId = reader.GetInt32(1);
                        if (testResult.Head.ProductMainId == productMainId)
                        {
                            LogManager.GetLogger("SQL").Info("SN already in DB. Skip to insert this one.");
                            return;
                        }
                        throw new SqlTransferExceptionWithoutRetry($"SN {testResult.Head.SerialNumber} to insert is already in DB with different  productMainId {productMainId}.");
                    }
                }
                LogManager.GetLogger("SQL").Info($"Step: InsertSn ({ testResult.Head.SerialNumber})");
                var model = new FACTS.Model.product_sn
                {
                    product_serial_num = testResult.Head.SerialNumber,
                    product_main_id = testResult.Head.ProductMainId,
                    register_date = testResult.Head.MeasStartTime,
                    sn_status_id = 1,
                    validity = true
                };
                AdjustDbConnString(testResult.DbConnString);
                var helper = new FACTS.BLL.product_snManager();
                helper.Add(model);
            }
        }

        public int[] GetSpecsMainIds(string sn, int productMainId, string phasePrefix, string mode)
        {
            var specMainIds = new List<int>();
            var queryString = "SELECT " +
                              "product_sn.product_main_id,product_sn.product_serial_num,product_sn.register_date," +
                              "mode_spec.validity," +
                              "product_main.product_name," +
                              "spec_main.id AS spec_main_id " +
                              "FROM product_sn " +
                              "JOIN product_main ON product_sn.product_main_id=product_main.id " +
                              "JOIN product_mode ON product_mode.product_main_id=product_main.id " +
                              "JOIN mode_spec ON mode_spec.product_mode_id=product_mode.id " +
                              "JOIN spec_main ON spec_main.id=mode_spec.spec_main_id " +
                              "JOIN phase_main ON phase_main.id=spec_main.phase_main_id " +
                              "JOIN mode ON mode.id=product_mode.mode_id " +
                              $"WHERE product_sn.product_serial_num='{sn}' " +
                              $"AND mode_spec.validity=1 " +
                              $"AND product_main.id={productMainId} " +
                              $"AND mode.mode='{mode}' " +
                              $"AND phase_main.phase like '{phasePrefix}%'";
            var adapter = new SqlDataAdapter(queryString, ConnectionString);
            var table = new DataTable();
            adapter.Fill(table);
            foreach (DataRow row in table.Rows)
            {
                specMainIds.Add(int.Parse(row["spec_main_id"].ToString()));
            }
            return specMainIds.ToArray();
        }

        public string GetProductName(string sn)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var queryString = "SELECT product_main.product_name " +
                                  "FROM product_sn " +
                                  "JOIN product_main ON product_sn.product_main_id=product_main.id " +
                                  "JOIN meas_main ON meas_main.product_sn_id=product_sn.id " +
                                  $"WHERE product_sn.product_serial_num='{sn}'";
                var command = new SqlCommand(queryString, conn);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        var name = reader.GetString(0);
                        return name;
                    }
                    throw new CatsSqlException("Nothing found");
                }
            }
        }

        public DataTable GetTestPhaseStatus(string sn, int specMainId)
        {
            var queryString = "SELECT " +
                              "product_sn.product_main_id,product_sn.product_serial_num,product_sn.register_date," +
                              "product_main.product_name," +
                              "meas_phase.id AS meas_phase_id,meas_phase.spec_main_id," +
                              "meas_phase.phase_status,meas_phase.start_datetime,meas_phase.phase AS meas_phase," +
                              "meas_detail.meas_value,meas_detail.plot_path " +
                              "FROM product_sn " +
                              "JOIN product_main ON product_sn.product_main_id=product_main.id " +
                              "JOIN meas_main ON meas_main.product_sn_id=product_sn.id " +
                              "JOIN meas_phase ON meas_phase.meas_main_id=meas_main.id " +
                              "JOIN meas_detail ON meas_detail.meas_phase_id=meas_phase.id " +
                              $"WHERE product_sn.product_serial_num='{sn}' AND meas_phase.spec_main_id={specMainId} AND meas_detail.last_test_flag=1";
            var adapter = new SqlDataAdapter(queryString, ConnectionString);
            var table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
