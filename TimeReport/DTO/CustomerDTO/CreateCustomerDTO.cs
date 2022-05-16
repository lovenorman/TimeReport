using System.ComponentModel.DataAnnotations;
using TimeReport.Data;

namespace TimeReport.DTO
{
    public class CreateCustomerDTO
    {
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
