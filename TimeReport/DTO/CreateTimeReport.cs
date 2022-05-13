namespace TimeReport.DTO
{
    public class CreateTimeReport
    {
        public string Customer { get; set; }
        public string Project  { get; set; }
        public DateTime Date { get; set; }
        public int Minutes { get; set; }
        public string Description { get; set; }
    }
}
