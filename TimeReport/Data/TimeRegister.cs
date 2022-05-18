namespace TimeReport.Data
{
    public class TimeRegister
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Minutes { get; set; }
        public string Description { get; set; }

        public Project Project { get; set; }
        
    }
}
