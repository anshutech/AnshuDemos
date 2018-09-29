using System;
using System.Net;
using System.IO;
using System.Text;
namespace HASH
 {
    public static class callrestapi
     {
 public static string CallRestMethod(string url)
        {
            HttpWebRequest webrequest;//?/??/???/
            string result = string.Empty;
            try
            {
                webrequest = (HttpWebRequest)WebRequest.Create(url);
                webrequest.Method = "GET";
                webrequest.ContentType = "application/x-www-form-urlencoded";

                HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
                Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
                StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);

                result = responseStream.ReadToEnd();
                webresponse.Close();


            }
            catch (Exception ex)
            {

                webrequest = null;
                result = null;
                throw ex;
            }
            finally
            {

                webrequest = null;
            }
            return result;
        }
 }
 }