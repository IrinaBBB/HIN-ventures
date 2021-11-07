using System.Collections.Generic;
using System.Threading.Tasks;
using HIN_ventures.Models;

namespace HIN_ventures.Business.Repositories.IRepositories
{
    public interface IAssignmentRepository
    {
        public Task<AssignmentDto> CreateAssignment(AssignmentDto assignmentDto);
        public Task<AssignmentDto> UpdateAssignment(int assignmentId, AssignmentDto assignmentDto);
        public Task<AssignmentDto> GetAssignment(int assignmentId);
        public Task<IEnumerable<AssignmentDto>> GetAllAssignments();
    }
}