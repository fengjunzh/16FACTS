using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace ResultTransferTool.MTS
{
    public class MTSProxy : IMTSProxy
    {
        private string _targetUrl = "http://aszpwbitdcs01/RFPATestServices/TestServices.asmx/UpdateTest";
        //private string _targetUrl = "http://aszweb/RFPATestServices/TestServices.asmx/UpdateTest";
        //private string _targetUrl = "http://homeappsdev.commscope.com/RFPATestServices/TestServices.asmx/UpdateTest";

        public bool UpdateTestResult(MTSTestResultTemplate result)
        {
            var url =
                $"{_targetUrl}?WorkStationName={result.WorkStationName}" +
                $"&UUTType={result.UUTType}" +
                $"&SN={result.SN}" +
                $"&TestResult={result.TestResult}" +
                $"&DateTime={result.DateTime}" +
                $"&OperatorID={result.OperatorID}" +
                $"&TesterID={result.TesterID}" +
                $"&TestProgramRev={result.TestProgramRev}" +
                $"&FailReason={result.FailReason}" +
                $"&FailValue={result.FailReason}" +
                $"&Description={result.Description}";
            try
            {
                var httpResponse = HttpGetRequest(url);
                var xDoc = XDocument.Parse(httpResponse);
                return bool.Parse(xDoc.Elements().First().Value);
            }
            catch
            {
                return false;
            }
        }

        private string HttpGetRequest(string url)
        {
            var retryCount = 0;
            while (retryCount < 6)
            {
                try
                {
                    var httpRequest = WebRequest.Create(url);
                    var httpResponse = httpRequest.GetResponse();
                    var responseString = new StreamReader(httpResponse.GetResponseStream()).ReadToEnd();
                    return responseString;
                }
                catch (System.Exception)
                {
                    retryCount++;
                }
            }
            return "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<boolean xmlns=\"http://tempuri.org/\">false</boolean>";
        }
    }
}
