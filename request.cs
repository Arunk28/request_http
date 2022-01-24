using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace request
{

    /// <summary>
    /// http properties
    /// </summary>
    public class HttpProperties
    {
        /// <summary>
        /// dictinoary object
        /// </summary>
        public Dictionary<string, string> dictObject { get; set; }
        /// <summary>
        /// url of request
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// json object string 
        /// </summary>
        public string jsonObjectString { get; set; }
        /// <summary>
        /// content type
        /// </summary>
        public string contentType { get; set; }
        /// <summary>
        /// synchronous or not
        /// </summary>
        public bool sync { get; set; }
        /// <summary>
        /// type of method GET or POST
        /// </summary>
        public string methodType { get; set; }
        /// <summary>
        /// token if it is required
        /// </summary>
        public string token { get; set; }
    }

    public class Http
    {
        public static object HttpRequest(HttpProperties http)
        {
            var result = new object();
            try
            {
                var httpWebRequest = WebRequest.Create(http.url) as HttpWebRequest;

                if (!string.IsNullOrEmpty(http.contentType))
                    httpWebRequest.ContentType = http.contentType;

                httpWebRequest.Method = http.methodType;

                if (http.token != string.Empty)
                    httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + http.token);

                if (http.dictObject != null)
                {
                    StringBuilder postData = new StringBuilder();
                    int i = 0;
                    foreach (KeyValuePair<string, string> kvpRequest
                        in http.dictObject)
                    {
                        postData.AppendFormat(((i == 0) ? string.Empty : "&") + "{0}={1}", kvpRequest.Key, kvpRequest.Value);
                        i++;
                    }

                    if (http.methodType != "GET")
                    {
                        byte[] byteArray = Encoding.UTF8.GetBytes(postData.ToString());
                        httpWebRequest.ContentLength = byteArray.Length;

                        using (Stream dataStream = httpWebRequest.GetRequestStream())
                        {
                            dataStream.Write(byteArray, 0, byteArray.Length);
                            dataStream.Close();
                        }
                    }

                }

                if (!string.IsNullOrEmpty(http.jsonObjectString))
                {
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(http.jsonObjectString);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }

                if (http.sync)
                {
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
