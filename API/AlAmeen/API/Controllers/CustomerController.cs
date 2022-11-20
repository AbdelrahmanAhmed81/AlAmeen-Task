using Application.Repositories.Interfaces;
using Domain.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await customerRepository.GetAll());
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Customer customer)
        {
            return Ok(await customerRepository.Create(customer));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromForm] Customer customer)
        {
            return Ok(await customerRepository.Update(customer));
        }
    }
}
