using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodAPI.DataObjects.Food
{
    public class AddFoodResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required double Price { get; set; }
        public string Description { get; set; } = "Description was not set";
        public FoodTypes Type { get; set; } = FoodTypes.Burguer;

    }
}