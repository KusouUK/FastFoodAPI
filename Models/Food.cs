using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodAPI.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Description { get; set; } = "Description was not set.";
        public FoodTypes Type { get; set; } = FoodTypes.Burguer;
    }
}