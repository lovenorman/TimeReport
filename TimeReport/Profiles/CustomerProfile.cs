using AutoMapper;
using TimeReport.Data;
using TimeReport.DTO;
using TimeReport.DTO.CustomerDTO;

namespace TimeReport.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<AllCustomersDTO, Customer>()
                //.ForMember(m => m.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<OneCustomerDTO, Customer>()
               //.ForMember(m => m.Name, opt => opt.MapFrom(src => src.Name))
               .ReverseMap();

            CreateMap<CreateCustomerDTO, Customer>()
               //.ForMember(m => m.Name, opt => opt.MapFrom(src => src.Name))
               .ReverseMap();

            CreateMap<UpdateCustomerDTO, Customer>()
               //.ForMember(m => m.Name, opt => opt.MapFrom(src => src.Name))
               .ReverseMap();


        }
    }
}
