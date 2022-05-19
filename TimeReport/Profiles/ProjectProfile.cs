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
            CreateMap<Project, AllProjectsDTO>()/*.ForMember(c => c.CustomerId, act => act.MapFrom(src => src.Customer.Id))*/
                .ReverseMap();

            CreateMap<Project, OneProjectDTO>()
                .ReverseMap();

            CreateMap<Project, CreateProject>().ForMember(src => src.CustomerId, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Project, UpdateProjectDTO>()
                .ReverseMap();
        }
    }
}
