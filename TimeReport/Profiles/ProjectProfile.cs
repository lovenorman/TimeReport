using AutoMapper;
using TimeReport.Data;
using TimeReport.DTO.ProjectDTO;

namespace TimeReport.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<AllProjectsDTO, Project>();
        }
    }
}
