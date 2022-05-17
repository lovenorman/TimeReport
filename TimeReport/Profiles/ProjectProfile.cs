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
            CreateMap<AllProjectsDTO, Project>()
                .ReverseMap();

            CreateMap<OneProjectDTO, Project>()
                .ReverseMap();

            CreateMap<CreateProject, Project>()
                .ReverseMap();

            CreateMap<UpdateProjectDTO, Project>()
                .ReverseMap();
        }
    }
}
