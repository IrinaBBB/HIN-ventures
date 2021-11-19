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
    public class CodeFileRepository : ICodeFileRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CodeFileRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateCodeFile(CodeFileDto codeFileDto)
        {
            var assignment = _mapper.Map<CodeFileDto, CodeFile>(codeFileDto);
            await _context.CodeFiles.AddAsync(assignment);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteCodeFileById(int id)
        {
            var assignment = await _context.CodeFiles.FindAsync(id);
            _context.Remove(assignment);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteCodeFileByAssignmentId(int assignmentId)
        {
            var assignments = await _context.CodeFiles.Where(x => x.Id == assignmentId).ToListAsync();
            _context.RemoveRange(assignments);

            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CodeFileDto>> GetCodeFiles(int assignmentId)
        {
            return _mapper.Map<IEnumerable<CodeFile>, IEnumerable<CodeFileDto>>(await _context.CodeFiles
                .Where(x => x.AssignmentId == assignmentId).ToListAsync());
        }
    }
}