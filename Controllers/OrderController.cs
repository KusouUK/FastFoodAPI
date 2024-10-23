using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFoodAPI.DataObjects.Order;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult<ServiceResponse<List<AddOrderResponse>>>> AddOrder(int userId, [FromBody] AddOrderRequest addOrder)
        {
            if (addOrder.FoodIds == null || !addOrder.FoodIds.Any())
            {
                return BadRequest("No food items provided.");
            }

            var response = await _orderService.AddOrder(userId, addOrder.FoodIds);

            if (!response.Ok)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}