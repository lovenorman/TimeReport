using System.ComponentModel.DataAnnotations;

namespace TimeReport.DTO
{
    public class CreateProject
    {
        [MaxLength(30)]
        public string Title { get; set; }

        [MaxLength(80)]
        public string Description { get; set; }
        
        [Required]
        public int CustomerId { get; set; }
    }
}
