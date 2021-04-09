using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsoleApp
{
    public class APIClient  : HttpClient
    {
        const string MediaType = "application/json";
        internal HttpClient Client { get; set; }
        public APIClient(string url)
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));
            Client.BaseAddress = new Uri(url);
        }

        public Task<HttpResponseMessage> PostPreparedContentAsync(string requestUri, Object content)
        {
            return Client.PostAsync(requestUri, PrepareContent(content));
        }

        public StringContent PrepareContent(object entity)
        {
            return new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, MediaType);
        }
    }
}
