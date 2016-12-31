using Newtonsoft.Json;
using SuperZapatos_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace SuperZapatos_Client.Http_Helpers
{
    public class Store_HttpHelper
    {
        private readonly string baseUri = "http://localhost:56671/services/stores";

        public async Task<List<StoreModel>> GetStoresAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                return JsonConvert.DeserializeObject<List<StoreModel>>(
                    await httpClient.GetStringAsync(baseUri)
                );
            }
        }
    }
}