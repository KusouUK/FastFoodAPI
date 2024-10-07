using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<Food>? Foods { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
    }
}