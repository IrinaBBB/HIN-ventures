using HIN_ventures.Business.Repositories.IRepositories;
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
    }
}