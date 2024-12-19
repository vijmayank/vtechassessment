using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vtechassessment.Database.DataProviders;
using vtechassessment.Models;
using vtechassessment.Services;

namespace vtechassessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
            
        }

        [HttpGet("customers", Name ="Get Customers")]
        public IActionResult GetAllCustomers()
        {
            // Asynchronously fetch the list of customers from the database
            var result = _customerService.GetAll();

            return Ok(result); // Return 200 OK with the customer data
        }

        [HttpGet("customersById", Name = "Get Customers by Id")]
        [Route("{id}")]
        public IActionResult GetCustomerById(Guid id)
        {
            // Asynchronously fetch the list of customers from the database
            var result = _customerService.GetCustomerById(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result); // Return 200 OK with the customer data
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            var result = _customerService.AddCustomer(customer);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(new {message="Customer successfully created !"});
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCustomer([FromRoute] Guid id)
        {
            if (!_customerService.DeleteCustomerById(id))
            {
                return NotFound();
            }
            return Ok(new
            {
                message="Customer deleted successfully!"
            });
        }


    }
}
