using System.ComponentModel.DataAnnotations;

namespace TimeReport.DTO.ProjectDTO
{
    public class UpdateProjectDTO
    {
        [MaxLength(30)]
        public string Title { get; set; }

        [MaxLength(80)]
        public string Description { get; set; }
    }
}
