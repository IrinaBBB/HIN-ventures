using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HIN_ventures;
using HIN_ventures.Models;
using HIN_ventures_Client.Service.IService;
using Newtonsoft.Json;

namespace HIN_ventures_Client.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _client;

        public CustomerService(HttpClient client)
        {
            _client = client;
        }

        public async Task<CustomerDto> CreateCustomer(CustomerDto customer)
        {
            var content = JsonConvert.SerializeObject(customer);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/customers/create", bodyContent);
            string res = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CustomerDto>(contentTemp);
                return result;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(contentTemp);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<CustomerDto> UpdateCustomer(int customerId, CustomerDto customers)
        {
            var content = JsonConvert.SerializeObject(customers);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"api/customer/update/{customerId}", bodyContent);
            string res = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CustomerDto>(contentTemp);
                return result;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(contentTemp);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<CustomerDto> GetCustomer(int customerId)
        {
            var response = await _client.GetAsync($"api/customer/{customerId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var customer = JsonConvert.DeserializeObject<CustomerDto>(content);
                return customer;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }

        }

        public async Task<IEnumerable<CustomerDto>> GetCustomers()
        {
            var response = await _client.GetAsync($"api/customer");
            var content = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<IEnumerable<CustomerDto>>(content);
            return customers;
        }
    }
}