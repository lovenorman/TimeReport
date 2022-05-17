namespace TimeReport.DTO.TimeRegistrationsDTO
{
    public class UpdateTimeRegistrationDTO
    {
        public DateTime Date { get; set; }
        public int Minutes { get; set; }
        public string Description { get; set; }

        public int ProjectId { get; set; }
    }
}
