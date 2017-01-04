using Newtonsoft.Json;
using SuperZapatos_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace SuperZapatos_Client.Http_Helpers
{
    public class Store_HttpHelper
    {
        private readonly string baseUri = "http://localhost:56671/services/stores";

        public async Task<List<StoreModel>> GetStoresAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, baseUri);
            request.Headers.Authorization = CreateBasicCredentials("my_user", "my_password");

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.SendAsync(request);
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<StoreModel>>(result);
            }
        }

        public async Task<StoreModel> GetStoreAsync(int? id)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, baseUri + "/" + id);
            request.Headers.Authorization = CreateBasicCredentials("my_user", "my_password");

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.SendAsync(request);
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<StoreModel>(result);
            }
        }

        public async Task<StoreModel> CreateStoresAsync(StoreModel storeModel)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, baseUri);
            request.Headers.Authorization = CreateBasicCredentials("my_user", "my_password");

            var json = new JavaScriptSerializer().Serialize(storeModel);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.SendAsync(request);
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<StoreModel>(result);
            }
        }

        public async Task<StoreModel> DeleteStoreAsync(int? id)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, baseUri + "/" + id);
            request.Headers.Authorization = CreateBasicCredentials("my_user", "my_password");
            
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.SendAsync(request);
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<StoreModel>(result);
            }
        }

        public async Task<StoreModel> EditStoreAsync(StoreModel storeModel)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, baseUri + "/" + storeModel.Id);
            request.Headers.Authorization = CreateBasicCredentials("my_user", "my_password");

            var json = new JavaScriptSerializer().Serialize(storeModel);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.SendAsync(request);
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<StoreModel>(result);
            }
        }

        private AuthenticationHeaderValue CreateBasicCredentials(string userName, string password)
        {
            string toEncode = userName + ":" + password;
            // The current HTTP specification says characters here are ISO-8859-1.
            // However, the draft specification for the next version of HTTP indicates this encoding is infrequently
            // used in practice and defines behavior only for ASCII.
            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            byte[] toBase64 = encoding.GetBytes(toEncode);
            string parameter = Convert.ToBase64String(toBase64);

            return new AuthenticationHeaderValue("Basic", parameter);
        }
    }
}