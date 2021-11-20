using AutoMapper;
using HIN_ventures.DataAccess.Entities;
using HIN_ventures.Models;

namespace HIN_ventures.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AssignmentDto, Assignment>();
            CreateMap<Assignment, AssignmentDto>();

            CreateMap<FreelancerDto, Freelancer>();
            CreateMap<Freelancer, FreelancerDto>();
            CreateMap<CodeFileDto, CodeFile>().ReverseMap();

            CreateMap<CustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>();
        }
    }
}