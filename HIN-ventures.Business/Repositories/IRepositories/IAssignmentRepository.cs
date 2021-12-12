using System.Collections.Generic;
using System.Threading.Tasks;
using HIN_ventures.Models;

namespace HIN_ventures.Business.Repositories.IRepositories
{
    public interface IAssignmentRepository
    {
        public Task<AssignmentDto> CreateAssignment(AssignmentDto assignmentDto);
        public Task<AssignmentDto> UpdateAssignment(int assignmentId, AssignmentDto assignmentDto);
        public Task<int> DeleteAssignment(int assignmentId);
        public Task<AssignmentDto> GetAssignment(int? assignmentId);
        public Task<AssignmentDto> GetOnlyAssignment(int? assignmentId);
        public IEnumerable<AssignmentDto> GetAllAssignments();
        public IEnumerable<AssignmentDto> GetAllAssignmentsForFreelancer(int? FreelancerId); 
        public IEnumerable<AssignmentDto> GetAllAssignmentsForCustomer(int? CustomerId);
    }
}