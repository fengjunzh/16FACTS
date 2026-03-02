using ResultTransferTool.Exception;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResultTransferTool.TransferTranscation.CatsTableModel;
using Nlogger;
using System.Diagnostics;

namespace ResultTransferTool.TransferTranscation
{
    class CatsSqlManager
    {
        private string _connString;

        public CatsSqlManager(string connStr)
        {
            _connString = connStr;
        }

        public int GetProductMainId(string productName)
        {
            using (var conn = new SqlConnection(_connString))
            {
                var command = new SqlCommand(@"SELECT id
                                FROM product_main
                                WHERE product_name = @ProductName
                                ");
                command.Connection = conn;
                command.Parameters.AddWithValue("@ProductName", productName);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader.GetInt32(0);
                    }
                    throw new SqlTransferExceptionWithoutRetry($"Product Name {productName} is not existed in DB");
                }
            }
        }

        internal int GetSpecMainId(string productName, string phaseName, string mode)
        {
            using (var conn = new SqlConnection(_connString))
            {
                var command = new SqlCommand(@"
                                    SELECT spec_main.id
                                    FROM spec_main
                                    JOIN mode_spec ON mode_spec.spec_main_id = spec_main.id
                                    JOIN product_mode ON product_mode.id = mode_spec.product_mode_id
                                    JOIN product_main ON product_main.id = product_mode.product_main_id
                                    JOIN phase_main ON phase_main.id = spec_main.phase_main_id
                                    JOIN mode ON mode.id = product_mode.mode_id
                                    WHERE product_main.product_name = @ProductName
                                    AND phase_main.phase = @PhaseName
                                    AND mode.mode = @Mode
                                ");
                command.Connection = conn;
                command.Parameters.AddWithValue("@ProductName", productName);
                command.Parameters.AddWithValue("@PhaseName", phaseName);
                command.Parameters.AddWithValue("@Mode", mode);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader.GetInt32(0);
                    }
                    throw new SqlTransferExceptionWithoutRetry($"Spec is not existed in DB for {productName}, mode {mode}");
                }
            }
        }

        internal int GetPhaseMainId(string phaseName)
        {
            using (var conn = new SqlConnection(_connString))
            {
                var command = new SqlCommand(@"SELECT id
                                FROM phase_main
                                WHERE phase = @PhaseName
                                ");
                command.Connection = conn;
                command.Parameters.AddWithValue("@PhaseName", phaseName);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader.GetInt32(0);
                    }
                    throw new SqlTransferExceptionWithoutRetry($"Phase Name {phaseName} is not existed in DB");
                }
            }
        }

        //public void CheckAndInsertMeasDetailDcf(IMeasDetailDcfTables results)
        //{
        //    var tables = results.GetMeasDetailDcfTables();
        //    using (var conn = new SqlConnection(_connString))
        //    {
        //        conn.Open();
        //        foreach (var table in tables)
        //        {
        //            var command = new SqlCommand(@"SELECT id
        //                            FROM meas_detail_dcf
        //                            WHERE meas_phase_id=@meas_phase_id
        //                            AND meas_group_dcf_id=@meas_group_dcf_id
        //                            AND meas_item=@meas_item
        //                            AND test_idx=@test_idx
        //                        ");
        //            command.Parameters.AddWithValue("@meas_phase_id", table.MeasPhaseId);
        //            command.Parameters.AddWithValue("@meas_group_dcf_id", table.MeasGroupDcfId);
        //            command.Parameters.AddWithValue("@meas_item", table.MeasItem);
        //            command.Parameters.AddWithValue("@test_idx", table.TestIdx);
        //            command.Connection = conn;
        //            using (var reader = command.ExecuteReader())
        //            {
        //                if (reader.HasRows)
        //                {
        //                    reader.Read();
        //                    var measureDetailDcfId = reader.GetInt32(0);
        //                    Debug.WriteLine($"Get meas_detail_dcf_id as {measureDetailDcfId}");
        //                    continue;
        //                }
        //            }
        //            LogManager.GetLogger("SQL").Info($"Step: MeasDetailDcf {table.MeasItem}");
        //            var measDetailDcf = new FACTS.Model.meas_detail_dcf
        //            {
        //                meas_phase_id = table.MeasPhaseId,
        //                meas_group_dcf_id = table.MeasGroupDcfId,
        //                meas_item = table.MeasItem,
        //                test_idx = table.TestIdx,
        //                limit_low = Math.Round(table.LimitLow, 3),
        //                limit_up = Math.Round(table.LimitUp, 3),
        //                last_test_flag = table.LastTestFlag,
        //                limit_unit = table.LimitUnit,
        //                elapsed_sec = table.ElapsedSec,
        //                meas_status = table.MeasStatus.ToString(),
        //                meas_value = Math.Round(table.MeasValue, 3),
        //                meas_string = table.MeasString
        //            };
        //            AdjustDbConnString(_connString);
        //            var helper = new CATS.BLL.meas_detail_dcfManager();
        //            var id = helper.AddReturnId(measDetailDcf);
        //        }
        //    }
        //}

        //internal void CheckAndInsertMeasTraceSwiftTable(IMeasTraceSwift results)
        //{
        //    var tables = results.GetMeasTraceSwift();
        //    using (var conn = new SqlConnection(_connString))
        //    {
        //        conn.Open();
        //        foreach (var table in tables)
        //        {
        //            var command = new SqlCommand(@"SELECT trace_name
        //                        FROM meas_trace_swift
        //                        wHERE meas_detail_swift_id=@meas_detail_swift_id
        //                        AND trace_name=@trace_name
        //                    ");
        //            command.Parameters.AddWithValue("@meas_detail_swift_id", table.MeasDetailSwiftId);
        //            command.Parameters.AddWithValue("@trace_name", table.TraceName);
        //            command.Connection = conn;
        //            using (var reader = command.ExecuteReader())
        //            {
        //                if (reader.HasRows)
        //                {
        //                    continue;
        //                }
        //            }
        //            LogManager.GetLogger("SQL").Info($"Step: Insert MeasTraceSwift {table.MeasDetailSwiftId}");
        //            var trace = new CATS.Model.meas_trace_swift
        //            {
        //                meas_detail_swift_id = table.MeasDetailSwiftId,
        //                trace_idx = table.TraceIdx,
        //                trace_name = table.TraceName,
        //                points_num = table.PointsNum,
        //                y_data = table.YData
        //            };
        //            AdjustDbConnString(_connString);
        //            var helper = new CATS.BLL.meas_trace_swiftManager();
        //            helper.Add(trace);
        //        }
        //    }
        //}

        //internal void CheckAndInsertMeasDetailSwiftTable(IMeasDetailSwiftTable results)
        //{
        //    var tables = results.GetMeasDetailSwiftTable();
        //    using (var conn = new SqlConnection(_connString))
        //    {
        //        conn.Open();
        //        foreach (var table in tables)
        //        {
        //            var command = new SqlCommand(@"SELECT id
        //                        FROM meas_detail_swift
        //                        WHERE meas_phase_id=@meas_phase_id
        //                        AND band_name=@band_name
        //                        AND port_name=@port_name
        //                        AND freq_mhz=@freq_mhz
        //                        AND tilt_meas=@tilt_meas
        //                        AND d_meas=@d_meas
        //                        AND sll_meas=@sll_meas
        //                    ");
        //            command.Parameters.AddWithValue("@meas_phase_id", table.MeasPhaseId);
        //            command.Parameters.AddWithValue("@band_name", table.BandName);
        //            command.Parameters.AddWithValue("@port_name", table.PortName);
        //            command.Parameters.AddWithValue("@freq_mhz", table.FrequencyInMHz);
        //            command.Parameters.AddWithValue("@tilt_meas", table.TiltMeasure);
        //            command.Parameters.AddWithValue("@d_meas", table.DMeasure);
        //            command.Parameters.AddWithValue("@sll_meas", table.SllMeasure);
        //            command.Connection = conn;
        //            using (var reader = command.ExecuteReader())
        //            {
        //                if (reader.HasRows)
        //                {
        //                    reader.Read();
        //                    var measDetailSwiftId = reader.GetInt32(0);
        //                    results.SetMeasDetailSwiftId(measDetailSwiftId, table.TestItemId.Value);
        //                    continue;
        //                }
        //            }
        //            LogManager.GetLogger("SQL").Info($"Step: Insert meas_detail_swift {table.BandName}-{table.PortName}-{table.FrequencyInMHz}");
        //            var measDetailSwift = new CATS.Model.meas_detail_swift
        //            {
        //                meas_phase_id = table.MeasPhaseId,
        //                test_idx = 1,
        //                band_name = table.BandName,
        //                port_name = table.PortName,
        //                freq_mhz = table.FrequencyInMHz,
        //                tilt_ll = table.TiltLowerLimit,
        //                tilt_meas = table.TiltMeasure,
        //                tilt_ul = table.TiltUpperLimit,
        //                d_ll = table.DLowerLimit,
        //                d_ul = table.DUpperLimit,
        //                d_meas = table.DMeasure,
        //                bw_ll = table.BwLowerLimit,
        //                bw_meas = table.BwMeasure,
        //                bw_ul = table.BwUpperLimit,
        //                sll_ll = table.SllLowerLimit,
        //                sll_meas = table.SllMeasure,
        //                sll_ul = table.SllUpperLimit,
        //                lsl_ll = table.LslLowerLimit,
        //                lsl_meas = table.LslMeasure,
        //                lsl_ul = table.LslUpperLimit,
        //                nullfill_ll = table.NullFillLowerLimit,
        //                nullfill_meas = table.NullFillMeasure,
        //                nullfill_ul = table.NullFillUpperLimit,
        //            };
        //            AdjustDbConnString(_connString);
        //            var helper = new CATS.BLL.meas_detail_swiftManager();
        //            var id = helper.AddReturnId(measDetailSwift);
        //            results.SetMeasDetailSwiftId(id, table.TestItemId.Value);
        //        }
        //    }
        //}

        //public void CheckAndInsertMeasGroupDcf(IMeasGroupDcfTables results)
        //{
        //    var tables = results.GetMeasGroupDcfTables();
        //    using (var conn = new SqlConnection(_connString))
        //    {
        //        conn.Open();
        //        foreach (var table in tables)
        //        {
        //            var command = new SqlCommand(@"SELECT id
        //                            FROM meas_group_dcf
        //                            WHERE meas_phase_id=@meas_phase_id
        //                            AND meas_group=@meas_group
        //                            AND test_idx=@test_idx
        //                        ");
        //            command.Parameters.AddWithValue("@meas_phase_id", table.MeasPhaseId);
        //            command.Parameters.AddWithValue("@meas_group", table.MeasGroupName);
        //            command.Parameters.AddWithValue("@test_idx", table.TestIdx);
        //            command.Connection = conn;
        //            using (var reader = command.ExecuteReader())
        //            {
        //                if (reader.HasRows)
        //                {
        //                    reader.Read();
        //                    var measureGroupDcfId = reader.GetInt32(0);
        //                    Debug.WriteLine($"Get meas_group_dcf_id as {measureGroupDcfId}");
        //                    results.SetMeasGroupDcfId(measureGroupDcfId, table.MeasGroupName, table.TestIdx);
        //                    continue;
        //                }
        //            }
        //            LogManager.GetLogger("SQL").Info($"Step: Insert MeasGroupDcf {table.MeasGroupName}");
        //            var measGroupDcf = new CATS.Model.meas_group_dcf
        //            {
        //                meas_phase_id = table.MeasPhaseId,
        //                group_status = table.GroupStatus.ToString(),
        //                test_idx = table.TestIdx,
        //                last_test_flag = table.LastTestFlag,
        //                meas_group = table.MeasGroupName
        //            };
        //            AdjustDbConnString(_connString);
        //            var helper = new CATS.BLL.meas_group_dcfManager();
        //            var id = helper.AddReturnId(measGroupDcf);
        //            results.SetMeasGroupDcfId(id, table.MeasGroupName, table.TestIdx);
        //        }
        //    }
        //}

        public void CheckAndInsertMeasPhase(IMeasPhaseTable results)
        {
            if (!CheckMeasPhaseId(results))
            {
                LogManager.GetLogger("SQL").Info("Step: InsertMeasPhase");
                InsertMeasPhase(results);
            }
        }

        public void InsertMeasPhase(IMeasPhaseTable results)
        {
            var table = results.GetMeasPhaseTable();
            var measPhase = new FACTS.Model.meas_phase
            {
                total_time = table.TotalTime,
                start_datetime = table.StartDateTime,
                stop_datetime = table.StopDateTime,
                phase = table.Phase,
                software_rev = table.SoftwareRev,
                spec_main_id = table.SpecMainId,
                phase_main_id = table.PhaseMainId,
                meas_main_id = table.MeasMainId,
                phase_status = table.PhaseStatus.ToString(),
                controller_id = table.ControllerId,
                employee_id = table.EmployeeId,
                factory_id = table.FactoryId,
            };

            AdjustDbConnString(_connString);
            var helper = new FACTS.BLL.meas_phaseManager();
            var measurePhaseId = helper.AddReturnId(measPhase);
            results.SetMeasPhaseId(measurePhaseId);
        }

        public bool CheckMeasPhaseId(IMeasPhaseTable results)
        {
            var table = results.GetMeasPhaseTable();
            using (var conn = new SqlConnection(_connString))
            {
                var command = new SqlCommand($"SELECT id FROM meas_phase WHERE meas_main_id={table.MeasMainId} AND " +
                                             $"start_datetime='{table.StartDateTime}' AND stop_datetime='{table.StopDateTime}'"
                                             , conn);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        var measurePhaseId = reader.GetInt32(0);
                        Debug.WriteLine($"Get meas_phase_id as {measurePhaseId}");
                        results.SetMeasPhaseId(measurePhaseId);
                        return true;
                    }
                }
            }
            return false;
        }

        public void CheckAndInsertSn(IProductSnTable results)
        {
            var snTable = results.GetProductSnTable();
            using (var conn = new SqlConnection(_connString))
            {
                var command = new SqlCommand($"SELECT id,product_main_id FROM product_sn WHERE product_serial_num='{snTable.ProductSerialNumber}'", conn);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        var productMainId = reader.GetInt32(1);
                        if (snTable.ProductMainId == productMainId)
                        {
                            LogManager.GetLogger("SQL").Info("SN already in DB. Skip to insert this one.");
                            return;
                        }
                        throw new SqlTransferExceptionWithoutRetry($"SN {snTable.ProductSerialNumber} to insert is already in DB with different productMainId {productMainId}.");
                    }
                }
                LogManager.GetLogger("SQL").Info($"Step: InsertSn ({ snTable.ProductSerialNumber})");
                var model = new FACTS.Model.product_sn
                {
                    product_serial_num = snTable.ProductSerialNumber,
                    product_main_id = snTable.ProductMainId,
                    register_date = snTable.RegisterDate,
                    sn_status_id = snTable.SnStatusId,
                    validity = snTable.validity
                };
                AdjustDbConnString(_connString);
                var helper = new FACTS.BLL.product_snManager();
                helper.Add(model);
            }
        }

        public void CheckAndInsertFactory(IFactoryTable testResult)
        {
            if (!CheckFactory(testResult))
            {
                LogManager.GetLogger("SQL").Info("Step: InsertFactory");
                InsertFactory(testResult);
            }
        }

        private void InsertFactory(IFactoryTable results)
        {
            var table = results.GetFactoryTable();
            var model = new FACTS.Model.factory { name = table.Name };
            AdjustDbConnString(_connString);
            var helper = new FACTS.BLL.factoryManager();
            var id = helper.AddReturnId(model);
            results.SetFactoryId(id);
        }

        private bool CheckFactory(IFactoryTable results)
        {
            var table = results.GetFactoryTable();
            using (var conn = new SqlConnection(_connString))
            {
                var command = new SqlCommand($"SELECT id FROM factory WHERE name='{table.Name}'", conn);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        var factoryId = reader.GetInt32(0);
                        Debug.WriteLine($"Get factory_id as {factoryId}");
                        results.SetFactoryId(factoryId);
                        return true;
                    }
                }
            }
            return false;
        }

        public void CheckAndInsertEmployee(IEmployeeTable testResult)
        {
            if (!CheckEmployee(testResult))
            {
                LogManager.GetLogger("SQL").Info("Step: InsertEmployee");
                InsertEmployee(testResult);
            }
        }

        private void InsertEmployee(IEmployeeTable results)
        {
            var table = results.GetEmployeeTable();
            var model = new FACTS.Model.employee
            {
                login_name = table.LoginName,
                factory_id = table.FactoryId
            };
            AdjustDbConnString(_connString);
            var helper = new FACTS.BLL.employeeManager();
            var id = helper.AddReturnId(model);
            results.SetEmployeeId(id);
        }

        private bool CheckEmployee(IEmployeeTable results)
        {
            var table = results.GetEmployeeTable();
            using (var conn = new SqlConnection(_connString))
            {
                var command = new SqlCommand($"SELECT id FROM employee WHERE login_name='{table.LoginName}'", conn);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        var employeeId = reader.GetInt32(0);
                        Debug.WriteLine($"Get employee_id as {employeeId}");
                        results.SetEmployeeId(employeeId);
                        return true;
                    }
                }
            }
            return false;
        }

        public void CheckAndInsertController(IControllerTable testResult)
        {
            if (!CheckController(testResult))
            {
                LogManager.GetLogger("SQL").Info("Step: InsertController");
                InsertController(testResult);
            }
        }

        private void InsertController(IControllerTable results)
        {
            var table = results.GetControllerTable();
            var model = new FACTS.Model.controller
            {
                name = table.Name,
                owner_id = table.OwnerId,
                factory_id = table.FactoryId
            };
            AdjustDbConnString(_connString);
            var helper = new FACTS.BLL.controllerManager();
            var id = helper.AddReturnId(model);
            results.SetControllerId(id);
        }

        private bool CheckController(IControllerTable results)
        {
            var table = results.GetControllerTable();
            using (var conn = new SqlConnection(_connString))
            {
                var command = new SqlCommand($"SELECT id FROM controller WHERE name='{table.Name}' AND factory_id='{table.FactoryId}'", conn);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        var controllerId = reader.GetInt32(0);
                        Debug.WriteLine($"Get controller_id as {controllerId}");
                        results.SetControllerId(controllerId);
                        return true;
                    }
                }
            }
            return false;
        }

        public void CheckAndInsertMeasMain(IMeasMainTable results)
        {
            if (!CheckMeasMainIdExisted(results))
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

        private void UpdateMeasMain(IMeasMainTable results)
        {
            var table = results.GetMeasMainTable();
            if (table.ProductModeId == 0)
            {
                throw new CatsSqlException($"Invalid PK id (product_mode_id={table.ProductModeId})");
            }
            using (var conn = new SqlConnection(_connString))
            {
                var command = new SqlCommand($"SELECT id,stop_datetime FROM meas_main WHERE product_sn_id={table.ProductSnId} " +
                                             $"AND product_mode_id={table.ProductModeId}", conn);
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
                        mainId = reader.GetInt32(0);
                        Debug.WriteLine($"Get meas_main_id as {mainId}");
                    }
                }
                if (mainId.HasValue && lastEndTime < table.StopDateTime)
                {
                    var updateCommand = new SqlCommand($"UPDATE meas_main SET stop_datetime='{table.StopDateTime}' WHERE id={mainId}", conn);
                    updateCommand.ExecuteNonQuery();
                }
            }
        }

        private void InsertMeasMain(IMeasMainTable results)
        {
            var table = results.GetMeasMainTable();
            var measMain = new FACTS.Model.meas_main
            {
                product_sn_id = table.ProductSnId,
                product_mode_id = table.ProductModeId,
                mode = table.Mode,
                start_datetime = table.StartDateTime,
                stop_datetime = table.StopDateTime
            };
            AdjustDbConnString(_connString);
            var helper = new FACTS.BLL.meas_mainManager();
            var id = helper.AddReturnId(measMain);
            results.SetMeasMainId(id);
        }

        private bool CheckMeasMainIdExisted(IMeasMainTable results)
        {
            var table = results.GetMeasMainTable();
            if (table.ProductModeId == 0)
            {
                throw new CatsSqlException($"Invalid PK id (product_mode_id={table.ProductModeId})");
            }
            using (var conn = new SqlConnection(_connString))
            {
                var command = new SqlCommand($"SELECT id,stop_datetime FROM meas_main WHERE product_sn_id={table.ProductSnId} " +
                                             $"AND product_mode_id={table.ProductModeId}", conn);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        var id = reader.GetInt32(0);
                        results.SetMeasMainId(id);
                        return true;
                    }
                }
            }
            return false;
        }

        public int GetProductSnId(string serialNumber)
        {
            using (var conn = new SqlConnection(_connString))
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
            throw new SqlTransferExceptionWithoutRetry($"Can't find SN ({serialNumber}).");
        }

        public int GetProductModeId(int produtMainId, string mode)
        {
            using (var conn = new SqlConnection(_connString))
            {
                var command = new SqlCommand(@"SELECT product_mode.id
                                FROM product_mode
                                JOIN mode on mode.id = product_mode.mode_id
                                WHERE mode.mode = @mode
                                AND product_main_id = @product_main_id
                                ");
                command.Connection = conn;
                command.Parameters.AddWithValue("@product_main_id", produtMainId);
                command.Parameters.AddWithValue("@mode", mode);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader.GetInt32(0);
                    }
                    throw new SqlTransferExceptionWithoutRetry($"There is no available mode_id for PROD {produtMainId} with {mode} Setting.");
                }
            }
        }

        private void AdjustDbConnString(string dbConnString)
        {
            var manager = new FACTS.BLL.CATSManager();
            manager.ActivateCATS(dbConnString);
        }
    }
}
