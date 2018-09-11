using System;
using System.Net;
using System.Text;

namespace OnPS.Other
{
    class Network
    {
        public const String AuthorizationKey = "Basic YmE0OTVhMjQtODE4Yy00NzJiLWIxMmQtZmYyMzFjMWI1NzQ1Om12YWlaa1JzQXNJMUlCa1k="; //Authorization key for psn.
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static string HTTP_GET(string Url, string Data, String Authorization = AuthorizationKey)
        {
            string Out = null;
            System.Net.WebRequest request = System.Net.WebRequest.Create(Url + (string.IsNullOrEmpty(Data) ? "" : "?" + Data));
            if (Authorization != null)
                request.Headers["Authorization"] = Authorization;
            try
            {
                System.Net.WebResponse resp = request.GetResponse();
                using (System.IO.Stream stream = resp.GetResponseStream())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(stream))
                    {
                        Out = sr.ReadToEnd();
                        sr.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Get fail.");
            }

            return Out;
        }

        public static string HTTP_POST(string Url, string data, String Authorization = AuthorizationKey)
        {
            string Out = null;
            var PostData = Encoding.UTF8.GetBytes(data);
            System.Net.WebRequest request = System.Net.WebRequest.Create(Url);
            if(Authorization != null)
                request.Headers["Authorization"] = Authorization;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = PostData.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(PostData, 0, PostData.Length);
            }
            try
            {
                System.Net.WebResponse resp = request.GetResponse();
                using (System.IO.Stream stream = resp.GetResponseStream())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(stream))
                    {
                        Out = sr.ReadToEnd();
                        sr.Close();
                    }
                }
            }
            catch (ArgumentException ex)
            {
                Out = string.Format("HTTP_ERROR :: The second HttpWebRequest object has raised an Argument Exception as 'Connection' Property is set to 'Close' :: {0}", ex.Message);
            }
            catch (WebException ex)
            {
                Out = string.Format("HTTP_ERROR :: WebException raised! :: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Out = string.Format("HTTP_ERROR :: Exception raised! :: {0}", ex.Message);
            }

            return Out;
        }

        public static void SessionCall()
        {
            try
            {

                HTTP_POST("https://www.onpsapp.com/session.php", Program.ClientID, null); //for analyse online user count.
            }
            catch(Exception)
            {
                Console.WriteLine("Session Call Error!");
            }
            
        }
    }
}
