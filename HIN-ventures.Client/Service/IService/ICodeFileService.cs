using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIN_ventures.Models;

namespace HIN_ventures_Client.Service.IService
{
    public interface ICodeFileService
    {
        public Task<IEnumerable<CodeFileDto>> GetCodeFiles();

        public Task<CodeFileDto> GetCodeFile(int codeFileId); 

        public Task<CodeFileDto> CreateCodeFile(CodeFileDto codeFile);

        public Task<CodeFileDto> UpdateCodeFile(int codeFileId, CodeFileDto codeFile);
        public Task<CodeFileDto> GetCodeFileFromAssignment(int Id);
    }
}