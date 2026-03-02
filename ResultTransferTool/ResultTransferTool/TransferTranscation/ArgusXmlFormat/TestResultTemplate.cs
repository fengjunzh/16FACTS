using ResultTransferTool.TransferTranscation.CatsTableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultTransferTool.TransferTranscation.ArgusXmlFormat
{
    class TestResultTemplate : CatsTestResult, IProductSnTable, IMeasMainTable, IControllerTable, IFactoryTable, IEmployeeTable
        , IMeasPhaseTable, IMeasGroupDcfTables, IMeasDetailDcfTables
    {
        public int Type;
        public HeadTemplate Head = new HeadTemplate();
        public ArgusGroupTemplate ArgusGroup = new ArgusGroupTemplate();

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

        public List<MeasDetailDcfTable> GetMeasDetailDcfTables()
        {
            if (!Head.MeasPhaseId.HasValue)
            {
                throw new ArgumentNullException("Head.MeasPhaseId");
            }
            var results = new List<MeasDetailDcfTable>();
            if (!ArgusGroup.MeasGroudDcfId.HasValue)
            {
                throw new ArgumentNullException($"Testgroups.MeasGroupDcfId with name {ArgusGroup.GroupName}");
            }
            var items = ArgusGroup.RetConfigurations.GetType().GetFields();
            foreach (var item in items)
            {
                results.Add(new MeasDetailDcfTable
                {
                    MeasPhaseId = Head.MeasPhaseId.Value,
                    MeasGroupDcfId = ArgusGroup.MeasGroudDcfId.Value,
                    MeasItem = item.Name,
                    MeasString = GetValue(item.Name)
                });
            }
            return results;
        }

        private string GetValue(string fieldName)
        {
            switch (fieldName)
            {
                case "SwitchToSRETforConfiguration":
                    return ArgusGroup.RetConfigurations.SwitchToSRETforConfiguration;
                case "Configuration":
                    return ArgusGroup.RetConfigurations.Configuration;
                case "ConfirmI2CFunction":
                    return ArgusGroup.RetConfigurations.ConfirmI2CFunction;
                case "RETMode":
                    return ArgusGroup.RetConfigurations.RETMode;
                case "ConfirmConfirguration":
                    return ArgusGroup.RetConfigurations.ConfirmConfirguration;
                case "CycleTestFunction":
                    return ArgusGroup.RetConfigurations.CycleTestFunction;
                case "FinalTestResult":
                    return ArgusGroup.RetConfigurations.FinalTestResult;
                default:
                    throw new ArgumentNullException($"RetConfigurations with unsupported name {fieldName}");
            }
        }

        public List<MeasGroupDcfTable> GetMeasGroupDcfTables()
        {
            if (!Head.MeasPhaseId.HasValue)
            {
                throw new ArgumentNullException("Head.MeasPhaseId");
            }
            var results = new List<MeasGroupDcfTable>();
            results.Add(new MeasGroupDcfTable
            {
                MeasPhaseId = Head.MeasPhaseId.Value,
                GroupStatus = ArgusGroup.GroupStatus.First(),
                TestIdx = ArgusGroup.TestIdx,
                LastTestFlag = true,
                MeasGroupName = ArgusGroup.GroupName,
            });
            return results;
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
                SpecMainId = Head.SpecMainId.Value,
                PhaseMainId = Head.PhaseMainId.Value,
                Phase = Head.PhaseName,
                PhaseStatus = Head.MeasStatus.First(),
                StartDateTime = Head.MeasStartTime,
                StopDateTime = Head.MeasStopTime,
                EmployeeId = Head.EmployeeId.Value,
                FactoryId = Head.FactoryId.Value,
                ControllerId = Head.ControllerId.Value,
                TotalTime = Head.TotalTime,
            };
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

        public void SetMeasGroupDcfId(int id, string GroupName, int testIndex)
        {
            ArgusGroup.MeasGroudDcfId = id;
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
