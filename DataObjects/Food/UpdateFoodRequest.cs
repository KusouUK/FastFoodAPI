using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodAPI.DataObjects.Food
{
    public class UpdateFoodRequest
    {
        public required string Name { get; set; }
        public required int Price { get; set; }
        public string Description { get; set; } = "Description was not set";
        public FoodTypes Type { get; set; } = FoodTypes.Burguer;
    }
}