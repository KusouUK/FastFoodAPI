using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace FastFoodAPI.Services.FoodService
{
    public class FoodService
    {
        private readonly IMapper _mapper;
        public FoodService(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}