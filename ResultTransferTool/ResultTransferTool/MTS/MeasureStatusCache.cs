using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ResultTransferTool.Exception;

namespace ResultTransferTool.MTS
{
    public class MeasureStatusCache
    {
        private static XDocument _cache;

        public MeasureStatusCache()
        {
            if (_cache == null)
            {
                InitializeCache();
            }
        }

        private void InitializeCache()
        {
            _cache = new XDocument();
            var root = new XElement("root");
            _cache.Add(root);
        }

        public bool RefreshCache(string productMainId)
        {
            var id = _cache.Root.Element("ProductMainId")?.Value;
            if (id != null && id == productMainId)
            {
                return false;
            }
            InitializeCache();
            var productMainIdElement = new XElement("ProductMainId");
            _cache.Root.Add(productMainIdElement);
            _cache.Root.Element("ProductMainId").Value = productMainId;
            return true;
        }

        public void CacheProductName(string productName)
        {
            var element = _cache.Root.Element("ProductName");
            if (element == null)
            {
                var newElement = new XElement("ProductName", productName);
                _cache.Root.Add(newElement);
            }
            _cache.Root.Element("ProductName").Value = productName;
        }

        public string GetProductName()
        {
            var name = _cache.Root.Element("ProductName")?.Value;
            if (name == null)
            {
                throw new MeasureStatusCacheException("ProductName doesn't cache");
            }
            return name;
        }

        public int[] GetSpecMainIds(string sn)
        {
            var idsElement = _cache.Root.Elements("SpecMainIds").ToList();
            if (idsElement.Count == 0)
            {
                throw new MeasureStatusCacheException("Nothing found");
            }
            var idsElementsWithSn = idsElement.Where(x => x.Attribute("SerialNumber").Value == sn).ToList();
            if (idsElementsWithSn.Count == 0)
            {
                throw new MeasureStatusCacheException($"Nothing found with SN: {sn}");
            }
            var idsElementWithSn = idsElementsWithSn.First();
            var totalHours = DateTime.Now.Subtract(DateTime.Parse(idsElementWithSn.Attribute("fetchTime").Value)).TotalHours;
            if (totalHours > 2)
            {
                throw new MeasureStatusCacheException("Buffer is out of date");
            }
            var ids = idsElementWithSn.Elements("id");
            var result = new List<int>();
            foreach (var id in ids)
            {
                result.Add(int.Parse(id.Value));
            }
            return result.ToArray();
        }

        public void CacheSpecMainIds(string sn, int[] ids)
        {
            CacheSpecMainIds(sn, ids, DateTime.Now);
        }

        public void CacheSpecMainIds(string sn, int[] ids, DateTime fettchTime)
        {

            var idsElement = _cache.Root.Elements("SpecMainIds").ToList();
            if (idsElement.Count == 0)
            {
                InsertSpecMainIdsElement(sn, ids, fettchTime);
                return;
            }
            var idsElementWithSn = idsElement.Where(x => x.Attribute("SerialNumber").Value == sn).ToList();
            if (idsElementWithSn.Count == 0)
            {
                InsertSpecMainIdsElement(sn, ids, fettchTime);
                return;
            }
            idsElementWithSn.Remove();
            InsertSpecMainIdsElement(sn, ids, fettchTime);
        }

        private void InsertSpecMainIdsElement(string sn, int[] ids, DateTime fettchTime)
        {
            var specMainIdsElement = new XElement("SpecMainIds",
                new XAttribute("fetchTime", fettchTime.ToString()),
                new XAttribute("SerialNumber", sn));
            foreach (var id in ids)
            {
                var idElement = new XElement("id") { Value = id.ToString() };
                specMainIdsElement.Add(idElement);
            }
            _cache.Root.Add(specMainIdsElement);
        }

        public CacheTestDataModel GetTestStatus(string sn, int specMainId)
        {
            var testsElements = _cache.Root.Elements("Tests").ToList();
            if (testsElements.Count == 0)
            {
                return null;
            }
            var testsElementWithSn = testsElements.Where(x => x.Attribute("SerialNumber").Value == sn).ToList();
            if (testsElementWithSn.Count == 0)
            {
                return null;
            }
            var subTestElements = testsElementWithSn.First().Elements("Test").ToList();
            if (subTestElements.Count == 0)
            {
                return null;
            }
            var subTestElementWithSpecMainId =
                subTestElements.Where(x => x.Attribute("specMainId").Value == specMainId.ToString()).ToList();
            if (subTestElementWithSpecMainId.Count == 0)
            {
                return null;
            }
            var result = new CacheTestDataModel
            {
                SerialNumber = sn,
                SpecMainId = specMainId,
                MeasStartTime = subTestElementWithSpecMainId.First().Element("MeasStartTime").Value,
                MeasStatus = subTestElementWithSpecMainId.First().Element("MeasStatus").Value,
                MeasValue = subTestElementWithSpecMainId.First().Element("MeasValue").Value,
                PlotPath = subTestElementWithSpecMainId.First().Element("PlotPath").Value,
            };
            return result;
        }

        public void CacheTestStatus(CacheTestDataModel testStatus)
        {
            var testsElements = _cache.Root.Elements("Tests").ToList();
            if (testsElements.Count == 0)
            {
                InsertTestsStatusElement(testStatus);
                return;
            }
            var testsElementWithSn = testsElements.Where(x => x.Attribute("SerialNumber").Value == testStatus.SerialNumber).ToList();
            if (testsElementWithSn.Count == 0)
            {
                InsertTestsStatusElement(testStatus);
                return;
            }
            var subTestElements = testsElementWithSn.First().Elements("Test").ToList();
            var subTestElementWithSpecMainId =
                subTestElements.Where(x => x.Attribute("specMainId").Value == testStatus.SpecMainId.ToString()).ToList();
            if (subTestElementWithSpecMainId.Count == 0)
            {
                testsElementWithSn.First().Add(BuildSubTestStatusElement(testStatus));
                return;
            }
            var cacheStatus = subTestElementWithSpecMainId.First();
            if (DateTime.Parse(cacheStatus.Element("MeasStartTime").Value) < DateTime.Parse(testStatus.MeasStartTime))
            {
                cacheStatus.Remove();
                testsElementWithSn.First().Add(BuildSubTestStatusElement(testStatus));
            }
        }

        private void InsertTestsStatusElement(CacheTestDataModel testStatus)
        {
            var newTestElement = new XElement("Tests", new XAttribute("SerialNumber", testStatus.SerialNumber));
            newTestElement.Add(BuildSubTestStatusElement(testStatus));
            _cache.Root.Add(newTestElement);
        }

        private XElement BuildSubTestStatusElement(CacheTestDataModel testStatus)
        {
            var subTestElement = new XElement("Test", new XAttribute("specMainId", testStatus.SpecMainId));
            subTestElement.Add(new XElement("MeasStartTime", testStatus.MeasStartTime));
            subTestElement.Add(new XElement("MeasStatus", testStatus.MeasStatus));
            subTestElement.Add(new XElement("MeasValue", testStatus.MeasValue));
            subTestElement.Add(new XElement("PlotPath", testStatus.PlotPath));
            return subTestElement;
        }
    }
}
