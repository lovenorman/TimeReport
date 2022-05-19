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
            CreateMap<TimeRegister, AllTimeRegistrationsDTO>()
                .ReverseMap();

            CreateMap<TimeRegister, OneTimeRegistrationDTO>()
                .ReverseMap();

            CreateMap<TimeRegister, CreateTimeRegistrationDTO>().ForMember(src => src.ProjectId, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<TimeRegister, UpdateTimeRegistrationDTO>()
                .ReverseMap();
        }

    }

}
