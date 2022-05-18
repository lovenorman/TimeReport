using AutoMapper;
using TimeReport.Data;
using TimeReport.DTO;
using TimeReport.DTO.ProjectDTO;

namespace TimeReport.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, AllProjectsDTO>().ForMember(c => c.CustomerId, act => act.MapFrom(src => src.Customer.Id))
                .ReverseMap();

            CreateMap<Project, OneProjectDTO>().ForMember(c => c.CustomerId, act => act.MapFrom(src => src.Customer.Id))
                .ReverseMap();

            CreateMap<Project, CreateProject>().ForMember(c => c.CustomerId, act => act.MapFrom(src => src.Customer.Id))
                .ReverseMap();

            CreateMap<Project, UpdateProjectDTO>()
                .ReverseMap();
        }
    }
}
