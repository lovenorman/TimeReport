using System.ComponentModel.DataAnnotations;

namespace TimeReportApp.Models
{
    public class NewCustomerViewModel
    {
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string Address { get; set; }
    }
}
