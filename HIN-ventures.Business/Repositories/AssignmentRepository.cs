using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HIN_ventures.Business.Repositories.IRepositories;
using HIN_ventures.DataAccess.Data;
using HIN_ventures.DataAccess.Entities;
using HIN_ventures.Models;
using Microsoft.EntityFrameworkCore;

namespace HIN_ventures.Business.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AssignmentRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AssignmentDto> CreateAssignment(AssignmentDto assignmentDto)
        {
            var assignment = _mapper.Map<AssignmentDto, Assignment>(assignmentDto);
            assignment.CreatedDate = System.DateTime.Now;
            assignment.CreatedBy = "";
            var addedAssignment = await _context.Assignments.AddAsync(assignment);
            await _context.SaveChangesAsync();
            return _mapper.Map<Assignment, AssignmentDto>(addedAssignment.Entity);
        }

        public async Task<AssignmentDto> UpdateAssignment(int assignmentId, AssignmentDto assignmentDto)
        {
            if (assignmentId != assignmentDto.Id) return null;
            var assignmentDetails = await _context.Assignments.FindAsync(assignmentId);
            var assignment = _mapper.Map(assignmentDto, assignmentDetails);
            assignment.UpdatedDate = System.DateTime.Now;
            assignment.UpdatedBy = "";
            
            var updatedAssignment = _context.Assignments.Update(assignment);
            var result = _context.SaveChangesAsync().Result;
            if (result == 1)
            {
                return _mapper.Map<Assignment, AssignmentDto>(updatedAssignment.Entity);
            }
            else
            {
                return null;
            }
        }

        public async Task<int> DeleteAssignment(int assignmentId)
        {
            var assignmentDetails = await _context.Assignments.FindAsync(assignmentId);
            if (assignmentDetails == null) return 0;
            _context.Assignments.Remove(assignmentDetails);
            return await _context.SaveChangesAsync();

        }

        public async Task<AssignmentDto> GetAssignment(int? assignmentId)
        {
            var assignment = _mapper.Map<Assignment, AssignmentDto>
                (await _context.Assignments.Include(x=>x.CodeFiles).FirstOrDefaultAsync(x => x.Id == assignmentId));
            return assignment;
        }

        public async Task<AssignmentDto> GetOnlyAssignment(int? assignmentId)
        {
            var assignment = _mapper.Map<Assignment, AssignmentDto>
                (await _context.Assignments.FirstOrDefaultAsync(x => x.Id == assignmentId));
            return assignment;
        }

        public IEnumerable<AssignmentDto> GetAllAssignments()
        {
            return _mapper.Map<IEnumerable<Assignment>, IEnumerable<AssignmentDto>>( _context.Assignments);
        }

        public IEnumerable<AssignmentDto> GetAllAssignmentsForFreelancer(int? FreelancerId)
        {
            var assignmenList = _mapper.Map<IEnumerable<Assignment>, IEnumerable<AssignmentDto>>( _context.Assignments);
            List<AssignmentDto> assignmenListTemp = new List<AssignmentDto>();
            foreach (var ass in assignmenList)
            {
                if (ass.FreelancerId == FreelancerId)
                {
                    assignmenListTemp.Add(ass);
                }
            }
            return assignmenListTemp;
        }

        public IEnumerable<AssignmentDto> GetAllAssignmentsForCustomer(int? CustomerId)
        {
            var assignmenList = _mapper.Map<IEnumerable<Assignment>, IEnumerable<AssignmentDto>>(_context.Assignments);
            List<AssignmentDto> assignmenListTemp = new List<AssignmentDto>();
            foreach (var ass in assignmenList)
            {
                if (ass.FreelancerId == CustomerId)
                {
                    assignmenListTemp.Add(ass);
                }
            }
            return assignmenListTemp;
        }


        //public async Task<AssignmentDto> GetAssignment(int assignmentId)
        //{
        //    try
        //    {
        //        //forandre tilbake etter å ha funnet feil
        //        var exists = await _context.CodeFiles.Where(c => c.AssignmentId == assignmentId).AnyAsync();

        //        var assignment = _mapper.Map<Assignment, AssignmentDto>
        //            (await _context.Assignments.FirstOrDefaultAsync(x => x.Id == assignmentId));

        //        if (exists)
        //        {
        //            assignment = _mapper.Map<Assignment, AssignmentDto>
        //            (await _context.Assignments.Include(x => x.CodeFiles)
        //                .FirstOrDefaultAsync(x => x.Id == assignmentId));
        //        }

        //        return assignment;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.Write(e.Message);
        //        return null;
        //    }

        //}
    }
}