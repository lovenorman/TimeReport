using AutoMapper;
using TimeReport.Data;
using TimeReport.DTO;

namespace TimeReport.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<AllCustomersDTO, Customer>()
                .ForMember(m => m.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}
