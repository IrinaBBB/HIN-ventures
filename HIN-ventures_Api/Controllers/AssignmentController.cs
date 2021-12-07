using System.Threading.Tasks;
using HIN_ventures.Business.Repositories.IRepositories;
using HIN_ventures.Models;
using Microsoft.AspNetCore.Mvc;

namespace HIN_ventures_Api.Controllers
{
    [Route("api/[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentController(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        [HttpGet]
        public IActionResult GetAssignments()
        {
            var assignments =  _assignmentRepository.GetAllAssignments();
            return Ok(assignments);
        }

        [HttpGet("{assignmentId}")]
        public IActionResult GetAssignmentById(int assignmentId)
        {
            var assignment = _assignmentRepository.GetAssignment(assignmentId);
            return Ok(assignment);
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AssignmentDto assignment)
        {
            if (ModelState.IsValid)
            {
                var result = await _assignmentRepository.CreateAssignment(assignment);
                return Ok(result);
            }
            else
            {
                return BadRequest(new ErrorModel()
                {
                    ErrorMessage = "Error while creating new Assignment"
                });
            }
        }

        [Route("Update/{id:int}")]
        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] AssignmentDto assignmentDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _assignmentRepository.UpdateAssignment(id, assignmentDto);
                return Ok(result);
            }
            else
            {
                return BadRequest(new ErrorModel()
                {
                    ErrorMessage = "Error while Updating Assignment"
                });
            }
        }
    }
}