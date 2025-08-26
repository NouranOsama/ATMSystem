using Microsoft.AspNetCore.Mvc;
using ATMSystem.DTOs.Customer;
using ATMSystem.Services.Interfaces;

namespace ATMSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController(ICustomerService _customerService) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreateDto dto)
        {
            if (dto == null)
                return BadRequest("Customer data is required.");

            var id = await _customerService.CreateCustomerAsync(dto);
            var customer = await _customerService.GetCustomerByIdAsync(id);

            return CreatedAtAction(nameof(GetCustomerById), new { id }, customer);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }
    }
}
