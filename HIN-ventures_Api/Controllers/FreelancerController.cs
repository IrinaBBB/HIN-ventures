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
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HIN_ventures_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FreelancerController : Controller
    {
        private readonly IFreelancerRepository _freelancerRepository;

        public FreelancerController(IFreelancerRepository freelancerRepository)
        {
            _freelancerRepository = freelancerRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FreelancerDto freelancer)
        {
            if (ModelState.IsValid)
            {
                var result = await _freelancerRepository.CreateFreelancer(freelancer);
                return Ok(result);
            }
            else
            {
                return BadRequest(new ErrorModel()
                {
                    ErrorMessage = "Error while creating new Freelancer"
                });
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetFreelancers()
        {
            var freelancers = await _freelancerRepository.GetAllFreelancers();
            return Ok(freelancers);
        }

        [HttpGet("{freelancerId:int}")]
        public async Task<IActionResult> GetFreelancer(int? freelancerId)
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

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] FreelancerDto freelancer)
        {
            if (ModelState.IsValid)
            {
                var result = await _freelancerRepository.UpdateFreelancer(id, freelancer);
                return Ok(result);
            }
            else
            {
                return BadRequest(new ErrorModel()
                {
                    ErrorMessage = "Error while Updating Freelancer"
                });
            }
        }
    }
}
