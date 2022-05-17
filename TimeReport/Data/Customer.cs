using System.ComponentModel.DataAnnotations;

namespace TimeReport.Data
{
    public class Customer
    {
        public int Id { set; get; }
        
        public string Name { set; get; }

        public string Address { set; get; }

        public List<Project>? Projects { get; set; } = new List<Project>();
    }
}
