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
                .ReverseMap();

            CreateMap<OneCustomerDTO, Customer>()
               .ReverseMap();

            CreateMap<CreateCustomerDTO, Customer>()
               .ReverseMap();

            CreateMap<UpdateCustomerDTO, Customer>()
               .ReverseMap();


        }
    }
}
