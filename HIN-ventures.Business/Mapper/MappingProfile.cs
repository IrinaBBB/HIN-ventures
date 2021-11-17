using AutoMapper;
using HIN_ventures.DataAccess.Entities;
using HIN_ventures.Models;

namespace HIN_ventures.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AssignmentDto, Assignment>().ReverseMap();
            CreateMap<CodeFileDto, CodeFile>().ReverseMap();
        }
    }
}