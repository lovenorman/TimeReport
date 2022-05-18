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
            //Hämta customer som heter Telia
            var cust = _context.Customers.First(c => c.Name == "Telia");
            //Om inget Proejct heter WebApp...
            if (!_context.Projects.Any(a => a.Title == "WebApp"))
            {
                //Adda nytt project till Projectslistan i den customern vi hämtade
                cust.Projects.Add(new Project
                {
                    Title = "WebbApp",
                    Description = "Razor pages, Code First"    
                });
            }

            var cust2 = _context.Customers.First(c => c.Name == "Telia");
            if (!_context.Projects.Any(a => a.Title == "MobileApp"))
            {
                cust2.Projects.Add(new Project
                {
                    Title = "MobileApp",
                    Description = "React"
                });
            }

            _context.SaveChanges();
        }

        private void SeedCustomers()
        {
            if (!_context.Customers.Any(a => a.Name == "Tre"))
            {
                _context.Customers.Add(new Customer
                {
                    Name = "Tre",
                    Address = "Bergsgatan 1"
                });
            }

            if (!_context.Customers.Any(a => a.Name == "Telia"))
            {
                _context.Customers.Add(new Customer
                {
                    Name = "Telia",
                    Address = "Solgatan 1"
                });
            }

            if (!_context.Customers.Any(a => a.Name == "Comviq"))
            {
                _context.Customers.Add(new Customer
                {
                    Name = "Comviq",
                    Address = "Snögatan 1"
                });
            }
            _context.SaveChanges();
        }
    }
    
}
