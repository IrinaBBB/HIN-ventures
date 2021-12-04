using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIN_ventures.Models;

namespace HIN_ventures_Client.Service.IService
{
    public interface IFreelancerService
    {
        public Task<IEnumerable<FreelancerDto>> GetFreelancers();

        public Task<FreelancerDto> GetFreelancer(int freelancerId); 

        public Task<FreelancerDto> CreateFreelancer(FreelancerDto freelancer);

        public Task<FreelancerDto> UpdateFreelancer(int freelancerId, FreelancerDto freelancer);
    }
}