using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaNet.Contract.Contracts;
using PruebaTecnicaNet.Contract.Models;
using System;

namespace PruebaTecnicaNet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var lst = _customerService.GetAll();

                return Ok(lst);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            try
            {
                return Ok(_customerService.GetByName(name));
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomerDto customer)
        {
            try
            {
                return Ok(_customerService.Create(customer));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
