using System.ComponentModel.DataAnnotations;

namespace TimeReportApp.Models
{
    public class EditCustomerViewModel
    {
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string Address { get; set; }
    }
}
