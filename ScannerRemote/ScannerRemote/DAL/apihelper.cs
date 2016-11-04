using Newtonsoft.Json;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using ScannerRemote.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ScannerRemote.DAL
{
    internal class apihelper
    {
        internal string APIURL
        {
            get
            {
                string url = String.Format("http://{0}:{1}/", Settings.ServerAddress, Settings.ServerPort);
                return url;
            }
        }
        internal async Task<bool> scanToPDF(bool unpaper, bool merge)
        {
            bool bret = false;
            using (var client = new HttpClient())
            {
                string url = String.Format("http://{0}:{1}/scanner/scanpdf?merge={2}&unpaper={3}",
                        Settings.ServerAddress, Settings.ServerPort, merge, unpaper
                    );
                var result = await client.GetAsync(url);

                if (result.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    bret = true;
                }
            }
            return bret;
        }
        internal async Task<bool> scanToPIC()
        {
            bool bret = false;
            using (var client = new HttpClient())
            {

                var result = await client.GetAsync(
                    String.Format("http://{0}:{1}/scanner/scanpic?resolution={2}&format={3}",
                        Settings.ServerAddress, Settings.ServerPort, Settings.Resolution, Settings.Format
                    )
                );
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    bret = true;
                }
            }
            return bret;
        }
        internal async Task<List<DocumentItem>> GetFiles()
        {
            var Items = new List<DocumentItem>();
            using (var client = new RestClient(new Uri(APIURL)))
            {
                // Create cancellation token source for timeout
                var cancellationTokenSource = new System.Threading.CancellationTokenSource();
                cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(15));

                try
                {
                    var request = new RestRequest("documents", Method.GET);
                    var result = await client.Execute<List<DocumentItem>>(request, cancellationTokenSource.Token);
                    Items = result.Data;
                }
                catch (TaskCanceledException) 
                {
                    if (cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        // Timed Out
                    }

                    Items = null;
                }
            }

            return Items;
        }
        internal async Task UpdateKeyWord(string fileName, string keyword)
        {
            
            using (var client = new RestClient(new Uri(APIURL)))
            {
                var request = new RestRequest(String.Format("documents/{0}", fileName), Method.POST);
                request.AddParameter("keywords", keyword);
                //client.Timeout = TimeSpan.FromSeconds(1);
                await client.Execute(request);
                
            }
        }
        internal async Task<string> GetPDFContent(string fileName)
        {
            string text = String.Empty;
            using (var client = new RestClient(new Uri(APIURL)))
            {
                var request = new RestRequest(String.Format("documents/{0}/details", fileName), Method.GET);
                var result  = await client.Execute(request);
                text= result.Content;
            }
            return text;
        }

        internal async Task<byte[]> DownloadFile(string fileName)
        {
            
            using (var client = new RestClient(APIURL))
            {
                try
                {
                    var request = new RestRequest(String.Format("documents/{0}/file",fileName) , Method.GET);
                  
                    var result = await client.Execute<dynamic>(request);
                    
                    return result.RawBytes;

                }
                catch (Exception ex)
                {
                    var foo = ex;
                }
            }
            return null;
            
        }
    
    }
}
