using TimeReport.DTO.ProjectDTO;

namespace TimeReport.DTO
{
    public class OneCustomerDTO
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public List<OneProjectDTO> Projects { get; set; } = new List<OneProjectDTO>();  
    }
}
