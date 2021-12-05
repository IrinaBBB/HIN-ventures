using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HIN_ventures.Client.Service.IService;
using HIN_ventures.Models;
using Newtonsoft.Json;

namespace HIN_ventures.Client.Service
{
    public class AssignmentService : IAssignmentService
    {
        private readonly HttpClient _client;

        public AssignmentService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<AssignmentDto>> GetAssignments()
        {
            var response = await _client.GetAsync($"api/assignment");
            var content = await response.Content.ReadAsStringAsync();
            var assignments = JsonConvert.DeserializeObject<IEnumerable<AssignmentDto>>(content);
            return assignments;
        }

        public async Task<AssignmentDto> GetAssignment(int assignmentId)
        {
            var response = await _client.GetAsync($"api/assignment/{assignmentId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var assignment = JsonConvert.DeserializeObject<AssignmentDto>(content);
                return assignment;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<AssignmentDto> CreateAssignment(AssignmentDto assignment)
        {
            var content = JsonConvert.SerializeObject(assignment);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/assignment/create", bodyContent);
            string res = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<AssignmentDto>(contentTemp);
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