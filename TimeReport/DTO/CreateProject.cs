namespace TimeReport.DTO
{
    public class CreateProject
    {

        [MaxLength(30)]
        public string Title { get; set; }
    }
}
