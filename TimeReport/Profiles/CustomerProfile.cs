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
            CreateMap<Customer, AllCustomersDTO>()
                .ReverseMap();

            CreateMap<Customer, OneCustomerDTO>()
               .ReverseMap();

            CreateMap<Customer, CreateCustomerDTO>()
               .ReverseMap();

            CreateMap<Customer, UpdateCustomerDTO>()
               .ReverseMap();


        }
    }
}
