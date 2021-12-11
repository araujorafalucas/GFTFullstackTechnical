using GFTTechnicalTest.Application.Interfaces;
using GFTTechnicalTest.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFTTechnicalTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService OrdersService;
        public OrdersController(IOrdersService ordersService)
        {
            OrdersService = ordersService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponseModel>>> GetOrdersAsync()
        {
            return Ok(await OrdersService.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult<OrderResponseModel>> AddOrderAsync([FromBody]OrderInputModel orderInputModel)
        {
            return Ok(await OrdersService.AddOrderAsync(orderInputModel));
        }

    }
}
