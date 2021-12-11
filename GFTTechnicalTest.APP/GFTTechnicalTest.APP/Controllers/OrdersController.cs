using System.Threading.Tasks;
using GFTTechnicalTestAPP.Application.Interfaces;
using GFTTechnicalTestAPP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GFTTechnicalTest.APP.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService OrdersService = null;
        public OrdersController(IOrdersService ordersService)
        {
            OrdersService = ordersService;
        }
        public async Task<IActionResult> Index()
        {
            var orderViewModel = await OrdersService.GetOrdersAsync();
            return View(orderViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> AddOrder(string input)
        {
            return Json(await OrdersService.AddOrderAsync(input));
        }
    }
}
