using System.ComponentModel.DataAnnotations;

namespace TimeReport.DTO.CustomerDTO
{
    public class UpdateCustomerDTO
    {
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
