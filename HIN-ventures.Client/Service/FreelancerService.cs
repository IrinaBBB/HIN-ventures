using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HIN_ventures;
using HIN_ventures.Models;
using HIN_ventures_Client.Service.IService;
using Newtonsoft.Json;

namespace HIN_ventures_Client.Service
{
    public class FreelancerService : IFreelancerService
    {
        private readonly HttpClient _client;

        public FreelancerService(HttpClient client)
        {
            _client = client;
        }

        public async Task<FreelancerDto> GetFreelancer(int freelancerId)
        {
            var response = await _client.GetAsync($"api/freelancer/{freelancerId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var freelancer = JsonConvert.DeserializeObject<FreelancerDto>(content);
                return freelancer;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }

        }

        public async Task<IEnumerable<FreelancerDto>> GetFreelancers()
        {
            var response = await _client.GetAsync($"api/freelancer");
            var content = await response.Content.ReadAsStringAsync();
            var freelancers = JsonConvert.DeserializeObject<IEnumerable<FreelancerDto>>(content);
            return freelancers;
        }
    }
}