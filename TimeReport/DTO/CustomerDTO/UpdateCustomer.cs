using System.ComponentModel.DataAnnotations;

namespace TimeReport.DTO.CustomerDTO
{
    public class UpdateCustomer
    {
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
