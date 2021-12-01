using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIN_ventures.Business.Repositories.IRepositories;
using HIN_ventures.Common;
using HIN_ventures.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace HIN_ventures_Api.Controllers
{
    [Route("api/[controller]")]
    public class FreelancerController : Controller
    {
        private readonly IFreelancerRepository _freelancerRepository;

        public FreelancerController(IFreelancerRepository hotelRoomRepository)
        {
            _freelancerRepository = hotelRoomRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetFreelancers() //bool IsActive?
        {
            var freelancers = await _freelancerRepository.GetAllFreelancers();
            return Ok(freelancers);
        }

        [HttpGet("{freelancerId}")]
        public async Task<IActionResult> GetFreelancer(int? freelancerId) //bool IsActive?
        {
            if (freelancerId == null)
            {
                return BadRequest(new ErrorModel()
                {
                    Title = "",
                    ErrorMessage = "Invalid Freelancer Id",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

            var frelancerDetails = await _freelancerRepository.GetFreelancer(freelancerId);
            if (frelancerDetails == null)
            {
                return BadRequest(new ErrorModel()
                {
                    Title = "",
                    ErrorMessage = "Invalid Freelancer Id",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }

            return Ok(frelancerDetails);

        }
    }
}
