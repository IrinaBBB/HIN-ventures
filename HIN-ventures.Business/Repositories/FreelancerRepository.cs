using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HIN_ventures.Business.Repositories.IRepositories;
using HIN_ventures.DataAccess.Data;
using HIN_ventures.DataAccess.Entities;
using HIN_ventures.Models;
using Microsoft.EntityFrameworkCore;

namespace HIN_ventures.Business.Repositories
{
    public class FreelancerRepository : IFreelancerRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public FreelancerRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AssignmentDto>> GetAllAssignmentsOnFreelancer(int freelancerId)
        {
            IEnumerable<AssignmentDto> assignmentDtos =
                _mapper.Map<IEnumerable<Assignment>, IEnumerable<AssignmentDto>>(
                    _db.Assignments.Where(x => x.FreelancerId == freelancerId));
            return await Task.FromResult(assignmentDtos);

        }

        public async Task<FreelancerDto> GetFreelancer(int? freelancerId)
        {
            try
            {
                FreelancerDto freelancer = _mapper.Map<Freelancer, FreelancerDto>(
                    await _db.Freelancers.FirstOrDefaultAsync(x=>x.FreelancerId ==freelancerId));

                return freelancer;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return null;
            }
        }

        public async Task<FreelancerDto> CreateFreelancer(FreelancerDto freelancerDto)
        {
            var freelancer = _mapper.Map<FreelancerDto, Freelancer>(freelancerDto);

            var addedFreelancer = await _db.Freelancers.AddAsync(freelancer);
            await _db.SaveChangesAsync();
            return _mapper.Map<Freelancer, FreelancerDto>(addedFreelancer.Entity);
        }

        public async Task<int> DeleteFreelancer(int freelancerId)
        {
            var freelancer = await _db.Freelancers.FindAsync(freelancerId);
            if (freelancer != null)
            {
                _db.Freelancers.Remove(freelancer);
                return await _db.SaveChangesAsync();
            }

            //if problems
            return 0;
        }

        public async Task<IEnumerable<FreelancerDto>> GetAllFreelancers()
        {
            try
            {
                IEnumerable<FreelancerDto> freelancerDtos = _mapper.Map<IEnumerable<Freelancer>, IEnumerable<FreelancerDto>>
                        (_db.Freelancers
                            .Include(x => x.Assignments)
                            .OrderBy(x => x.TotalLinesOfCode));
                return await Task.FromResult(freelancerDtos);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }

        public async Task<FreelancerDto> UpdateFreelancer(int freelancerId, FreelancerDto freelancerDto)
        {
            if (freelancerId != freelancerDto.FreelancerId) return null;
           
            var freelancerDetails = await _db.Freelancers.FindAsync(freelancerId);
            var freelancer = _mapper.Map(freelancerDto, freelancerDetails);
            
            var updatedFreelancer = _db.Freelancers.Update(freelancer);
            var result = _db.SaveChangesAsync().Result;
            if (result == 1)
            {
                return _mapper.Map<Freelancer, FreelancerDto>(updatedFreelancer.Entity);
            }
            else
            {
                return null;
            }
        }

    }
}
