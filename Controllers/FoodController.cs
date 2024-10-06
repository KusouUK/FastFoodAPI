using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFoodAPI.DataObjects;
using FastFoodAPI.Services.FoodService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;
        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetFoodResponse>>>> GetFoods()
        {
            var response = await _foodService.GetFoods();

            if (!response.Ok)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetFoodResponse>>> GetFoodById(int id)
        {
            var response = await _foodService.GetFoodById(id);

            if (!response.Ok)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}