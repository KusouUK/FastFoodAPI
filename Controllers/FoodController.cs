using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFoodAPI.DataObjects.Food;
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

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<AddFoodResponse>>>> AddFood(AddFoodRequest newFood)
        {
            var response = await _foodService.AddFood(newFood);

            if (!response.Ok)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<RemoveFoodResponse>>>> RemoveFood(int id)
        {
            var response = await _foodService.RemoveFood(id);

            if (!response.Ok)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}