using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodAPI.DataObjects.Food
{
    public class UpdateFoodRequest
    {
        public string? Name { get; set; }
        public int? Price { get; set; }
        public string? Description { get; set; }
        public FoodTypes? Type { get; set; }
    }
}