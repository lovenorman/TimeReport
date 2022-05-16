namespace TimeReport.DTO.TimeRegistrationsDTO
{
    public class CreateTimeRegistrationDTO
    {
        public DateTime Date { get; set; }
        public int Minutes { get; set; }
        public string Description { get; set; }
    }
}
