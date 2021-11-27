using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
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
            throw new System.NotImplementedException();
        }
    }
}