using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FastFoodAPI.DataObjects;
using FastFoodAPI.Models;

namespace FastFoodAPI.Services.FoodService
{
    public class FoodService : IFoodService
    {
        private readonly IMapper _mapper;
        public FoodService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<Food> FoodList = new List<Food>()
        {
            new Food() { Id = 0, Name = "Burguer", Price = 15 }
        };


        public async Task<ServiceResponse<List<GetFoodResponse>>> GetFoods()
        {
            var response = new ServiceResponse<List<GetFoodResponse>>();

            response.Data = FoodList.Select(_mapper.Map<GetFoodResponse>).ToList();

            return response;
        }

        public async Task<ServiceResponse<GetFoodResponse>> GetFoodById(int id)
        {
            var response = new ServiceResponse<GetFoodResponse>();
            var food = FoodList.FirstOrDefault(food => food.Id == id);

            if (food is null)
            {
                response.Ok = false;
                response.Message = "The food item was not found.";
                return response;
            }

            response.Data = _mapper.Map<GetFoodResponse>(food);
            response.Message = $"Here is the item of id {food.Id}, {food.Name}.";
            return response;
        }
    }
}