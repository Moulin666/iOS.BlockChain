using System;
using System.IO;
using System.Net;
using System.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace iOS.BlockChain.ServerApi
{
    public static class ServerApi
    {
        public static async Task<T> FetchObject<T>(string url) where T : class
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    JsonValue json = await Task.Run(() => JsonValue.Load(stream));

                    return JsonConvert.DeserializeObject<T>(json.ToString());
                }
            }
        }
    }
}

//WebClient webClient = new WebClient();
//var jsonString = webClient.DownloadString(url);

//return JsonConvert.DeserializeObject<T>(jsonString);