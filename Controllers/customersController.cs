using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CustomerApi.Models;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private static List<Customer> customers = new List<Customer>();

        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return customers;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User,Admin")]
        public ActionResult<Customer> Get(int id)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            customers.Add(customer);
            return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "User,Admin")]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {
            var existingCustomer = customers.FirstOrDefault(c => c.Id == id);
            if (existingCustomer == null)
            {
                return NotFound();
            }
            existingCustomer.Name = customer.Name;
            existingCustomer.Birthday = customer.Birthday;
            existingCustomer.Gender = customer.Gender;
            existingCustomer.Address = customer.Address;
            existingCustomer.Phone = customer.Phone;
            existingCustomer.Note1 = customer.Note1;
            existingCustomer.Note2 = customer.Note2;

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            customers.Remove(customer);
            return NoContent();
        }
    }
}
