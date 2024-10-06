using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFoodAPI.Models;

namespace FastFoodAPI.DataObjects
{
    public class GetFoodResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; } = "Description was not set.";
        public FoodTypes Type { get; set; }
    }
}