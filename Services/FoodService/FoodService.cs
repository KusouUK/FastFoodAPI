using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FastFoodAPI.DataObjects.Food;
using FastFoodAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFoodAPI.Services.FoodService
{
    public class FoodService : IFoodService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public FoodService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetFoodResponse>>> GetFoods()
        {
            var response = new ServiceResponse<List<GetFoodResponse>>();

            try
            {
                response.Data = await _context.Foods.Select(f => _mapper.Map<GetFoodResponse>(f)).ToListAsync();
            }
            catch (Exception e)
            {
                response.Ok = false;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetFoodResponse>> GetFoodById(int id)
        {
            var response = new ServiceResponse<GetFoodResponse>();

            try
            {
                var food = await _context.Foods.FirstOrDefaultAsync(food => food.Id == id);

                if (food is null)
                {
                    response.Ok = false;
                    response.Message = "The food item was not found.";
                    return response;
                }

                response.Data = _mapper.Map<GetFoodResponse>(food);
                response.Message = $"Here is the item of id {food.Id}, {food.Name}.";

            }
            catch (Exception e)
            {
                response.Ok = false;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<AddFoodResponse>>> AddFood(AddFoodRequest newFood)
        {
            var response = new ServiceResponse<List<AddFoodResponse>>();

            try
            {
                _context.Foods.Add(_mapper.Map<Food>(newFood));
                await _context.SaveChangesAsync();

                response.Data = await _context.Foods.Select(f => _mapper.Map<AddFoodResponse>(f)).ToListAsync();
            }
            catch (Exception e)
            {
                response.Ok = false;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<RemoveFoodResponse>>> RemoveFood(int id)
        {
            var response = new ServiceResponse<List<RemoveFoodResponse>>();

            try
            {
                var food = await _context.Foods.FirstOrDefaultAsync(f => f.Id == id);

                if (food is null)
                {
                    response.Ok = false;
                    response.Message = "The food with the provided id was not found.";
                    return response;
                }

                _context.Foods.Remove(food);
                await _context.SaveChangesAsync();

                response.Data = await _context.Foods.Select(f => _mapper.Map<RemoveFoodResponse>(f)).ToListAsync();
            }
            catch (Exception e)
            {
                response.Ok = false;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<UpdateFoodResponse>> UpdateFood(int id, UpdateFoodRequest updatedFood)
        {
            var response = new ServiceResponse<UpdateFoodResponse>();

            try
            {
                var food = await _context.Foods.FirstOrDefaultAsync(f => f.Id == id);

                if (food is null)
                {
                    response.Ok = false;
                    response.Message = "The food with the provided id was not found.";
                    return response;
                }

                if (updatedFood.Name != null)
                {
                    food.Name = updatedFood.Name;
                }
                
                if (updatedFood.Price != null)
                {
                    food.Price = updatedFood.Price.Value;
                }
                
                if (updatedFood.Description != null)
                {
                    food.Description = updatedFood.Description;
                }
                
                if (updatedFood.Type != null)
                {
                    food.Type = updatedFood.Type.Value;
                }
                
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<UpdateFoodResponse>(food);
            }
            catch (Exception e)
            {
                response.Ok = false;
                response.Message = e.Message;
            }

            return response;
        }
    }
}