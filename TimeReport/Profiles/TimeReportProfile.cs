using AutoMapper;
using TimeReport.Data;
using TimeReport.DTO;
using TimeReport.DTO.TimeRegistrationsDTO;

namespace TimeReport.Profiles
{
    public class TimeReportProfile : Profile
    {
        public TimeReportProfile()
        {
            CreateMap<TimeRegister, AllTimeRegistrationsDTO>().ForMember(p => p.ProjectId, act => act.MapFrom(src => src.Project.Id))
                .ReverseMap();

            CreateMap<TimeRegister, OneTimeRegistrationDTO>().ForMember(p => p.ProjectId, act => act.MapFrom(src => src.Project.Id))
                .ReverseMap();

            CreateMap<TimeRegister, CreateTimeRegistrationDTO>().ForMember(p => p.ProjectId, act => act.MapFrom(src => src.Project.Id))
                .ReverseMap();

            CreateMap<TimeRegister, UpdateTimeRegistrationDTO>()
                .ReverseMap();
        }

    }

}
