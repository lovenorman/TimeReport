namespace TimeReport.DTO.TimeRegistrationsDTO
{
    public class AllTimeRegistrationsDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Minutes { get; set; }
        public string Description { get; set; }

        public int ProjectId { get; set; }
    }
}
