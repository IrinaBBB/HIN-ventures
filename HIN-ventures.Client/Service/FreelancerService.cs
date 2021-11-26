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

        public Task<IEnumerable<FreelancerDto>> GetFreelancerDetails(int freelancerId)
        {
            throw new NotImplementedException();
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