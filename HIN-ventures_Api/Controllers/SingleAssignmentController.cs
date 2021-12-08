using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIN_ventures.Business.Repositories.IRepositories;
using HIN_ventures.Models;

namespace HIN_ventures_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SingleAssignmentController : Controller
    {
        private readonly IAssignmentRepository _repository;

        public SingleAssignmentController(IAssignmentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{assignmentId:int}")]
        public async Task<IActionResult> GetAssignmentById(int? assignmentId)
        {
            if (assignmentId == null)
            {
                return BadRequest(new ErrorModel()
                {
                    Title = "",
                    ErrorMessage = "Invalid Assignment Id",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

            var assigmentDetails = await _repository.GetAssignment(assignmentId);
            if (assigmentDetails == null)
            {
                return BadRequest(new ErrorModel()
                {
                    Title = "",
                    ErrorMessage = "Invalid Assignment Id",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }

            return Ok(assigmentDetails);

        }

    }

}

