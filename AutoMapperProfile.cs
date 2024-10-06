using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FastFoodAPI.DataObjects.Food;
using FastFoodAPI.Models;

namespace FastFoodAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Food, GetFoodResponse>();
            CreateMap<GetFoodResponse, Food>();
            CreateMap<AddFoodRequest, Food>();
            CreateMap<Food, AddFoodResponse>();
            CreateMap<Food, RemoveFoodResponse>();
        }
    }
}