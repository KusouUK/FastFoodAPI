using FastFoodAPI.DataObjects.Food;
using FastFoodAPI.Models;

namespace FastFoodAPI.Services.FoodService
{
    public interface IFoodService
    {
        Task<ServiceResponse<List<GetFoodResponse>>> GetFoods();
        Task<ServiceResponse<GetFoodResponse>> GetFoodById(int id);
        Task<ServiceResponse<List<AddFoodResponse>>> AddFood(AddFoodRequest newFood);
        Task<ServiceResponse<List<RemoveFoodResponse>>> RemoveFood(int id);
        Task<ServiceResponse<UpdateFoodResponse>> UpdateFood(int id, UpdateFoodRequest updatedFood);
    }
}