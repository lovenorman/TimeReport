using System.ComponentModel.DataAnnotations;

namespace TimeReport.DTO.ProjectDTO
{
    public class UpdateProjectDTO
    {
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
