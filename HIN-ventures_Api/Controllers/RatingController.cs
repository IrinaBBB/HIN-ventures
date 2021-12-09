using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIN_ventures.Business.Repositories.IRepositories;
using HIN_ventures.Models;
using Microsoft.AspNetCore.Mvc;

namespace HIN_ventures_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingRepository _ratingRepository; //husk å registere i program.cs og på serveren i startup.cs mappingen mellom Irepo og repo

        public RatingController(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RatingDto rating)
        {
            if (ModelState.IsValid)
            {
                var result = await _ratingRepository.Create(rating);
                return Ok(result);
            }
            else
            {
                return BadRequest(new ErrorModel()
                {
                    ErrorMessage = "Error while creating new Rating"
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetRatings()
        {
            var ratings = await _ratingRepository.GetAllRatings();
            return Ok(ratings);
        }
    }
}
