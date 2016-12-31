using Newtonsoft.Json;
using SuperZapatos_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SuperZapatos_Client.Http_Helpers
{
    public class Article_HttpHelper
    {
        private readonly string baseUri = "http://localhost:56671/services/articles";

        public async Task<List<ArticleModel>> GetArticlesAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, baseUri);
            request.Headers.Authorization = CreateBasicCredentials("my_user","my_password");

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.SendAsync(request);
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<ArticleModel>>(result);
            }
        }

        public async Task<List<ArticleModel>> GetArticlesByStoreAsync(int? storeId)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, baseUri + "/stores/" + storeId);
            request.Headers.Authorization = CreateBasicCredentials("my_user", "my_password");

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.SendAsync(request);
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<ArticleModel>>(result);
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