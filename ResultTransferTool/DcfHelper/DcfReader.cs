using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DcfHelper.DataModel;

namespace DcfHelper
{
    class DcfReader
    {
        public List<DcfDataModel> Parser(string filePath)
        {
            var results = new List<DcfDataModel>();
            var content = System.IO.File.ReadAllLines(filePath);
            var measurements = SplitMeasurement(content);
            foreach (var item in measurements)
            {
                results.Add(SubParser(item));
            }
            return results;
        }

        private List<string[]> SplitMeasurement(string[] content)
        {
            var results = new List<string[]>();
            var startIndex = 0;
            var stopIndex = 0;
            var startFlag = true;
            for (int i = 0; i < content.Count(); i++)
            {
                var cells = content[i].Split('|');
                if (startFlag && cells[0] == "EVENTSTART")
                {
                    startIndex = i;
                    startFlag = false;
                    continue;
                }
                if (!startFlag && cells[0] == "EVENTSTOP")
                {
                    stopIndex = i;
                    startFlag = true;
                    results.Add(content.Skip(startIndex).Take(stopIndex - startIndex + 1).ToArray());
                }
            }
            return results;
        }


        private DcfDataModel SubParser(string[] rows)
        {
            var result = new DcfDataModel();
            result.StartRow = ParseEventStartRow(rows.First());
            result.StopRow = ParseEventStopRow(rows.Last());
            result.MeasurementRows = ParseMeasurement(rows);
            return result;
        }

        private EventStartRecordModel ParseEventStartRow(string row)
        {
            var result = new EventStartRecordModel();
            var cells = row.Split('|');
            result.RecordType = cells[0];
            if (result.RecordType != "EVENTSTART")
            {
                throw new ArgumentException("EVENTSTART row is not valid.");
            }
            result.DcfRevision = cells[1];
            result.EventDateTime = DateTime.ParseExact(cells[2].Substring(0, 14), "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
            result.EventType = cells[3];
            result.ProductionSite = cells[4];
            result.ProcessStep = cells[6];
            result.Controller = cells[7];
            result.Program = cells[12];
            result.Resource = cells[14];
            result.AssemblyType = cells[17];
            result.SerialNumber = cells[19];
            result.Operator = cells[27];
            return result;
        }

        private EventStopRecordModel ParseEventStopRow(string row)
        {
            var result = new EventStopRecordModel();
            var cells = row.Split('|');
            result.RecordType = cells[0];
            if (result.RecordType != "EVENTSTOP")
            {
                throw new ArgumentException("EVENTSTOP row is not valid.");
            }
            result.DcfRevision = cells[1];
            result.EventStatus = cells[2];
            result.EventDuration = int.Parse(cells[3]);
            result.TestSoftwareVersion = cells[5];
            result.ProductFirmwareVersion = cells[6];
            result.ContractSerialNumber = cells[7];
            return result;
        }

        private List<ProductMeasureRecordModel> ParseMeasurement(string[] rows)
        {
            var results = new List<ProductMeasureRecordModel>();
            var index = -1;
            foreach (var row in rows)
            {
                index++;
                var cells = row.Split('|');
                if (cells[0] != "PRODUCTMEASURE")
                {
                    continue;
                }
                results.Add(new ProductMeasureRecordModel
                {
                    RecordType = cells[0],
                    DcfRevision = cells[1],
                    TestDesignator = cells[2],
                    TestStatus = cells[4],
                    NonNumericValue = cells[6],
                    NumericValue = double.Parse(cells[7]),
                    Units = cells[8],
                    LowerLimit = cells[21],
                    UpperLimit = cells[22],
                    GroupName = cells[23],
                    ElapsedTime = cells[25] == "" ? 0 : int.Parse(cells[25]),
                    Index = index
                });
            }
            return results;
        }
    }
}
