﻿using System.ComponentModel.DataAnnotations;

namespace TimeReport.Data
{
    public class Project
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Title { get; set; }

        List<TimeReport> TimeReports { get; set; }
        
    }
}
