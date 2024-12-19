using vtechassessment.Database.DataProviders;
using vtechassessment.Models;

namespace vtechassessment.Services
{
    public class CustomerService : ICustomerService
    {
        private AppDbContext _context;
        public CustomerService(AppDbContext context) 
        {
            _context = context;
        }

        public Customer AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public bool DeleteCustomerById(Guid id)
        {
            var customerDelete= _context.Customers.FirstOrDefault(c => c.CustomerId == id);
            _context.Customers.Remove(customerDelete);
            _context.SaveChanges();
            return true;
        }

        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(Guid id)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerId == id);
        }
    }
}
