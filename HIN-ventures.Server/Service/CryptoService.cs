using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HIN_ventures.Models;
using HIN_ventures.Server.Service.IService;
using Newtonsoft.Json;

namespace HIN_ventures.Server.Service
{
    public class CryptoService : ICrytoService
    {
        private readonly HttpClient _client;

        public CryptoService(HttpClient client)
        {
            _client = client;
        }

 

        public async Task<CryptoDto> CreateTransaction(CryptoDto transaction)
        {
            var content = JsonConvert.SerializeObject(transaction);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("https://block.io/api/v2/prepare_transaction/", bodyContent);
            string res = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CryptoDto>(contentTemp);
                return result;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(contentTemp);
                throw new Exception(errorModel.ErrorMessage);
            }
        }
    }
}
