using System.ComponentModel.DataAnnotations;

namespace TimeReport.Data
{
    public class Project
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Title { get; set; }

        [MaxLength(80)]
        public string Description { get; set; }

        public Customer Customer { get; set; }

        public List<TimeRegister> TimeRegistrations { get; set; } = new List<TimeRegister>();

        
        
    }
}
