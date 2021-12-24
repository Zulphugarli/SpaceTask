using System;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Text;

namespace SpaceTask.Helper
{
    public class Request
    {
        public static string HttpRequest(string address)
        {
            var request = (HttpWebRequest)WebRequest.Create(address);          
            request.Timeout = 60000;
            request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.BypassCache);

            string output = string.Empty;
            try
            {
                using (var response = request.GetResponse())
                {
                    using (var stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        output = stream.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    using (var stream = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        output = stream.ReadToEnd();
                    }
                }
                else if (ex.Status == WebExceptionStatus.Timeout)
                {
                    output = "Request timeout is expired.";
                }
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }

            return output;
        }
    }
}
