using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaNet.Contract.Contracts;
using PruebaTecnicaNet.Contract.Models;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnicaNet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        // GET: api/<OrderController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var lst = _orderService.GetAll();

                return Ok(lst);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }



        // POST api/<OrderController>
        [HttpPost]
        public IActionResult Post([FromBody] OrderDto order)
        {
            try
            {
                var newOrder = _orderService.Create(order);

                return Ok(newOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);

            }
        }
    }
}
