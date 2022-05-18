using TimeReport.DTO.TimeRegistrationsDTO;

namespace TimeReport.DTO.ProjectDTO
{
    public class OneProjectDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int CustomerId { get; set; }
        
        public List<OneTimeRegistrationDTO> TimeRegistrations { get; set; } = new List<OneTimeRegistrationDTO>();
    }
}
