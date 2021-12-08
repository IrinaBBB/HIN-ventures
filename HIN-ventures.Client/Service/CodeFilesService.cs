using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HIN_ventures;
using HIN_ventures.Models;
using HIN_ventures_Client.Service.IService;
using Newtonsoft.Json;

namespace HIN_ventures_Client.Service
{
    public class CodeFilesService : ICodeFileService
    {
        private readonly HttpClient _client;

        public CodeFilesService(HttpClient client)
        {
            _client = client;
        }

        public async Task<CodeFileDto> CreateCodeFile(CodeFileDto codeFile)
        {
            var content = JsonConvert.SerializeObject(codeFile);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/codeFile/create", bodyContent);
            string res = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CodeFileDto>(contentTemp);
                return result;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(contentTemp);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<CodeFileDto> UpdateCodeFile(int codeFileId, CodeFileDto codeFile)
        {
            var content = JsonConvert.SerializeObject(codeFile);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"api/codeFile/update/{codeFileId}", bodyContent);
            string res = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CodeFileDto>(contentTemp);
                return result;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(contentTemp);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<CodeFileDto> GetCodeFileFromAssignment(int Id)
        {
            var response = await _client.GetAsync($"api/codeFile/getCodeFileFromAssignment/{Id}");
            var content = "";
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();

                if (!String.IsNullOrEmpty(content))
                { 
                    return null;
                }
                else
                {
                    var codeFile = JsonConvert.DeserializeObject<CodeFileDto>(content);
                    return codeFile;
                }
            } 
            else
            {
                content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        //bruker den over i steden halil
        public async Task<CodeFileDto> GetCodeFile(int assignmentId)
        {
            var response = await _client.GetAsync($"api/codeFile/getCodeFile/{assignmentId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var codeFile = JsonConvert.DeserializeObject<CodeFileDto>(content);
                return codeFile;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }

        }

        public async Task<IEnumerable<CodeFileDto>> GetCodeFiles()
        {
            var response = await _client.GetAsync("api/codeFile/getCodeFiles");
            var content = await response.Content.ReadAsStringAsync();
            var codeFiles = JsonConvert.DeserializeObject<IEnumerable<CodeFileDto>>(content);
            return codeFiles;
        }

     
    }
}