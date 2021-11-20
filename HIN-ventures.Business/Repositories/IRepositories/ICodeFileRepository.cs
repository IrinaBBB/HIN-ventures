﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HIN_ventures.Models;

namespace HIN_ventures.Business.Repositories.IRepositories
{
    public interface ICodeFileRepository
    {
        public Task<int> CreateCodeFile(CodeFileDto codeFileDto);
        public Task<int> DeleteCodeFileById(int id);
        public Task<int> DeleteCodeFileByAssignmentId(int assignmentId);
        public Task<IEnumerable<CodeFileDto>> GetCodeFiles(int assignmentId);
    }
}