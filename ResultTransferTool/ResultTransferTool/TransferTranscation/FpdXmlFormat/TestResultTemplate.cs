using ResultTransferTool.TransferTranscation.CatsTableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultTransferTool.TransferTranscation.FpdXmlFormat
{
    class TestResultTemplate : CatsTestResult, IProductSnTable, IMeasMainTable, IControllerTable, IFactoryTable, IEmployeeTable
        , IMeasPhaseTable, IMeasDetailSwiftTable, IMeasTraceSwift
    {
        #region Data Struct
        public int Type;
        public HeadTemplate Head = new HeadTemplate();
        public AntennaTemplate Antenna = new AntennaTemplate();
        #endregion

        public ControllerTable GetControllerTable()
        {
            if (!Head.FactoryId.HasValue)
            {
                throw new ArgumentNullException("Head.FactoryId");
            }
            if (!Head.EmployeeId.HasValue)
            {
                throw new ArgumentNullException("Head.EmployeeId");
            }
            return new ControllerTable
            {
                FactoryId = Head.FactoryId.Value,
                OwnerId = Head.EmployeeId.Value,
                Name = Head.Controller
            };
        }

        public EmployeeTable GetEmployeeTable()
        {
            if (!Head.FactoryId.HasValue)
            {
                throw new ArgumentNullException("Head.FactoryId");
            }
            return new EmployeeTable
            {
                FactoryId = Head.FactoryId.Value,
                LoginName = Head.UserName,
            };
        }

        public FactoryTable GetFactoryTable()
        {
            return new FactoryTable
            {
                Name = Head.Factory
            };
        }

        public List<MeasDetailSwiftTable> GetMeasDetailSwiftTable()
        {
            if (!Head.MeasPhaseId.HasValue)
            {
                throw new ArgumentNullException("Head.MeasPhaseId");
            }
            var resp = new List<MeasDetailSwiftTable>();
            foreach (var item in Antenna.TestItems)
            {
                var spec = Antenna.SpecItems.FirstOrDefault(x => x.BandIndex == item.SpecBandIndex);
                if (spec == null)
                {
                    throw new ArgumentNullException($"Can't find spec with band index{item.SpecBandIndex}");
                }
                resp.Add(new MeasDetailSwiftTable
                {
                    MeasPhaseId = Head.MeasPhaseId.Value,
                    BandName = item.Band,
                    PortName = item.Port,
                    FrequencyInMHz = Convert.ToDecimal(item.Frequency),
                    TiltLowerLimit = Convert.ToDecimal(spec.TiltLowerLimit),
                    TiltUpperLimit = Convert.ToDecimal(spec.TiltUpperLimit),
                    TiltMeasure = Convert.ToDecimal(item.Tilt),
                    BwLowerLimit = Convert.ToDecimal(spec.BwLowerLimit),
                    BwUpperLimit = Convert.ToDecimal(spec.BwUpperLimit),
                    BwMeasure = Convert.ToDecimal(item.BW),
                    SllLowerLimit = Convert.ToDecimal(spec.SLLLowerLimit),
                    SllUpperLimit = Convert.ToDecimal(spec.SLLUpperLimit),
                    SllMeasure = Convert.ToDecimal(item.SLL),
                    DLowerLimit = Convert.ToDecimal(spec.DLowerLimit),
                    DUpperLimit = Convert.ToDecimal(spec.DUpperLimit),
                    DMeasure = Convert.ToDecimal(item.D),
                    LslLowerLimit = Convert.ToDecimal(spec.LSLLowerLimit),
                    LslUpperLimit = Convert.ToDecimal(spec.LSLUpperLimit),
                    LslMeasure = Convert.ToDecimal(item.LSL),
                    NullFillLowerLimit = Convert.ToDecimal(spec.NullFillLowerLimit),
                    NullFillUpperLimit = Convert.ToDecimal(spec.NullFillUpperLimit),
                    NullFillMeasure = Convert.ToDecimal(item.NullFill),
                    TestItemId = item.id
                });
            }
            return resp;
        }

        public MeasMainTable GetMeasMainTable()
        {
            if (!Head.ProductMainId.HasValue)
            {
                Head.ProductMainId = GetPorductMainId(Head.ProductName);
            }
            if (!Head.ProductSnId.HasValue)
            {
                Head.ProductSnId = GetProductSnId(Head.SerialNumber);
            }
            if (!Head.ProductModeId.HasValue)
            {
                Head.ProductModeId = GetProductModeId(Head.ProductMainId.Value, Head.Mode);
            }
            return new MeasMainTable
            {
                ProductSnId = Head.ProductSnId.Value,
                ProductModeId = Head.ProductModeId.Value,
                Mode = Head.Mode,
                StartDateTime = Head.MeasStartTime,
                StopDateTime = Head.MeasStopTime,
                MeasStatus = Head.MeasStatus.First()
            };
        }

        public MeasPhaseTable GetMeasPhaseTable()
        {
            if (!Head.FactoryId.HasValue)
            {
                throw new ArgumentNullException("Head.FactoryId");
            }
            if (!Head.EmployeeId.HasValue)
            {
                throw new ArgumentNullException("Head.EmployeeId");
            }
            if (!Head.ControllerId.HasValue)
            {
                throw new ArgumentNullException("Head.ControllerId");
            }
            if (!Head.MeasMainId.HasValue)
            {
                throw new ArgumentNullException("Head.MeasMainId");
            }
            if (!Head.PhaseMainId.HasValue)
            {
                Head.PhaseMainId = GetPhaseMainId(Head.PhaseName);
            }
            if (!Head.SpecMainId.HasValue)
            {
                Head.SpecMainId = GetSpecMainId(Head.ProductName, Head.PhaseName, Head.Mode);
            }
            return new MeasPhaseTable
            {
                MeasMainId = Head.MeasMainId.Value,
                PhaseMainId = Head.PhaseMainId.Value,
                Phase = Head.PhaseName,
                PhaseStatus = Head.MeasStatus.First(),
                StartDateTime = Head.MeasStartTime,
                StopDateTime = Head.MeasStopTime,
                SoftwareRev = Head.SoftwareRev,
                EmployeeId = Head.EmployeeId.Value,
                FactoryId = Head.FactoryId.Value,
                ControllerId = Head.ControllerId.Value,
                TotalTime = Head.TotalTime,
                SpecMainId = Head.SpecMainId.Value
            };
        }

        public List<MeasTraceSwift> GetMeasTraceSwift()
        {
            var resp = new List<MeasTraceSwift>();
            foreach (var item in Antenna.TestItems)
            {
                if (!item.MeasDetailSwiftId.HasValue)
                {
                    throw new ArgumentNullException("Test item MeasDetail SwiftId");
                }
                resp.Add(new MeasTraceSwift
                {
                    MeasDetailSwiftId = item.MeasDetailSwiftId.Value,
                    TraceIdx = 1,
                    TraceName = "Pattern",
                    YData = item.Curve,
                    PointsNum = item.Curve.Split(',').Length
                });
            }
            return resp;
        }

        public ProductSnTable GetProductSnTable()
        {
            if (!Head.ProductMainId.HasValue)
            {
                Head.ProductMainId = GetPorductMainId(Head.ProductName);
            }
            return new ProductSnTable
            {
                ProductSerialNumber = Head.SerialNumber,
                ProductMainId = Head.ProductMainId.Value,
                validity = true,
                SnStatusId = 1,
                RegisterDate = Head.MeasStartTime
            };
        }

        public void SetControllerId(int controllerId)
        {
            Head.ControllerId = controllerId;
        }

        public void SetEmployeeId(int id)
        {
            Head.EmployeeId = id;
        }

        public void SetFactoryId(int id)
        {
            Head.FactoryId = id;
        }

        public void SetMeasDetailSwiftId(int id, int itemId)
        {
            var item = Antenna.TestItems.FirstOrDefault(x => x.id == itemId);
            if (item == null)
            {
                throw new ArgumentOutOfRangeException($"Item id{item} is not found.");
            }
            item.MeasDetailSwiftId = id;
        }

        public void SetMeasMainId(int id)
        {
            Head.MeasMainId = id;
        }

        public void SetMeasPhaseId(int id)
        {
            Head.MeasPhaseId = id;
        }
    }
}
