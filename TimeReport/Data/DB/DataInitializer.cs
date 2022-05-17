using Microsoft.EntityFrameworkCore;

namespace TimeReport.Data.DB
{
    public class DataInitializer
    {
        private ApplicationDbContext _context;

        public DataInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            _context.Database.Migrate();
            SeedCustomers();
            SeedProjects();
        }

        private void SeedProjects()
        {
            if (!_context.Projects.Any(a => a.Title == "WebApp"))
            {
                _context.Projects.Add(new Project
                {
                    Title = "WebbApp"
                });
            }

            if (!_context.Projects.Any(a => a.Title == "MobileApp"))
            {
                _context.Projects.Add(new Project
                {
                    Title = "MobileApp"
                });
            }
        }

        private void SeedCustomers()
        {
            if (!_context.Customers.Any(a => a.Name == "Tre"))
            {
                _context.Customers.Add(new Customer
                {
                    Name = "Tre"
                });
            }

            if (!_context.Customers.Any(a => a.Name == "Telia"))
            {
                _context.Customers.Add(new Customer
                {
                    Name = "Telia"
                });
            }

            if (!_context.Customers.Any(a => a.Name == "Comviq"))
            {
                _context.Customers.Add(new Customer
                {
                    Name = "Comviq"
                });
            }

            _context.SaveChanges();
        }
    }
    
}
