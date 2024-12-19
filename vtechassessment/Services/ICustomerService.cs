using vtechassessment.Models;

namespace vtechassessment.Services
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        Customer GetCustomerById(Guid id);
        Customer AddCustomer(Customer customer);
        bool DeleteCustomerById(Guid id);
    }
}
