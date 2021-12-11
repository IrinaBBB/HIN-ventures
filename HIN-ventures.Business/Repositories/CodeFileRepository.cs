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
            var codeFile = _mapper.Map<CodeFileDto, CodeFile>(codeFileDto);
            await _context.CodeFiles.AddAsync(codeFile);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteCodeFileById(int id)
        {
            var codeFile = await _context.CodeFiles.FindAsync(id);
            _context.Remove(codeFile);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteCodeFileByAssignmentId(int assignmentId)
        {
            var codeFile = await _context.CodeFiles.Where(x => x.Id == assignmentId).ToListAsync();
            _context.RemoveRange(codeFile);

            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CodeFileDto>> GetCodeFilesFromAssignment(int Id)
        {
            var result = _mapper.Map<IEnumerable<CodeFile>, IEnumerable<CodeFileDto>>(await _context.CodeFiles
                .Where(x => x.AssignmentId == Id).ToListAsync());
            return result;
        }

        public async Task<IEnumerable<CodeFileDto>> GetCodeFiles(int assignmentId)
        {
            return _mapper.Map<IEnumerable<CodeFile>, IEnumerable<CodeFileDto>>(await _context.CodeFiles
                .Where(x => x.AssignmentId == assignmentId).ToListAsync());
        }

        public async Task<CodeFileDto> UpdateCodeFile(int codeFileId, CodeFileDto codeFileDto)
        {
            if (codeFileId != codeFileDto.Id) return null;

            var codeFileDetails = await _context.CodeFiles.FindAsync(codeFileId);
            var codeFile = _mapper.Map(codeFileDto, codeFileDetails);

            var updatedCodeFile = _context.CodeFiles.Update(codeFile);
            var result = _context.SaveChangesAsync().Result;
            if (result == 1)
            {
                return _mapper.Map<CodeFile, CodeFileDto>(updatedCodeFile.Entity);
            }
            else
            {
                return null;
            }
        }

        public async Task<CodeFileDto> GetCodeFile(int codeFileId)
        {
            try
            {
                CodeFileDto codeFileDto = _mapper.Map<CodeFile, CodeFileDto>(
                    await _context.CodeFiles.FirstOrDefaultAsync(x => x.Id == codeFileId));

                return codeFileDto;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return null;
            }
        }
    }
}