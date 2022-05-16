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
            CreateMap<AllTimeRegistrationsDTO, TimeRegister>().ReverseMap();

            CreateMap<OneTimeRegistrationDTO, TimeRegister>().ReverseMap();

            CreateMap<CreateTimeRegistrationDTO, TimeRegister>().ReverseMap();

            CreateMap<UpdateTimeRegistrationDTO, TimeRegister>().ReverseMap();
        }

    }

}
