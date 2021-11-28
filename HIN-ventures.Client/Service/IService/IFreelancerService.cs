using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIN_ventures.Models;

namespace HIN_ventures_Client.Service.IService
{
    public interface IFreelancerService
    {
        public Task<IEnumerable<FreelancerDto>> GetFreelancers(); //no checkin and checkout date as in video 139

        public Task<FreelancerDto> GetFreelancer(int freelancerId); //no checkin and checkout date as in video 139
    }
}