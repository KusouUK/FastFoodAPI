using FastFoodAPI.DataObjects;
using FastFoodAPI.Models;

namespace FastFoodAPI.Services.FoodService
{
    public interface IFoodService
    {
        Task<ServiceResponse<List<GetFoodResponse>>> GetFoods(GetFoodRequest foodRequest);
    }
}