using System.ComponentModel.DataAnnotations;
using TimeReport.Data;

namespace TimeReport.DTO
{
    public class CreateCustomerDTO
    {
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string Address { get; set; }
    }
}
