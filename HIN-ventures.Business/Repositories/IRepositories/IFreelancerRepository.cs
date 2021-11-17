using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIN_ventures.Models;

namespace HIN_ventures.Business.Repositories.IRepositories
{
    public interface IFreelancerRepository
    {
        public Task<FreelancerDto> GetFreelancer(int? freelancerId);
        public Task<IEnumerable<AssignmentDto>> GetAllAssignmentsOnFreelancer(int freelancerId);
        public Task<FreelancerDto> CreateFreelancer(FreelancerDto freelancerDto);
        public Task<int> DeleteFreelancer(int freelancerId);
        public Task<IEnumerable<FreelancerDto>> GetAllFreelancers();
    }
}
