﻿using Microsoft.EntityFrameworkCore;

namespace TimeReport.Data.DB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<TimeReport> TimeReports { get; set; }
    }
}
