using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodAPI.DataObjects.Order
{
    public class AddOrderRequest
    {
        public List<int> FoodIds { get; set; } = new List<int>();
    }
}