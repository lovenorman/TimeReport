using System.ComponentModel.DataAnnotations;

namespace TimeReport.DTO.CustomerDTO
{
    public class UpdateCustomerDTO
    {
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string Address { get; set; }
    }
}
