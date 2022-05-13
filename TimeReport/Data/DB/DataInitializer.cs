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
