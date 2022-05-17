using System.ComponentModel.DataAnnotations;

namespace TimeReport.DTO.TimeRegistrationsDTO
{
    public class CreateTimeRegistrationDTO
    {
        public DateTime Date { get; set; }
        public int Minutes { get; set; }
        public string Description { get; set; }

        [Required]
        public int ProjectId { get; set; }
    }
}
