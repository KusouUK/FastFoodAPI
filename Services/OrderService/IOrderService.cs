using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFoodAPI.DataObjects.Order;

namespace FastFoodAPI.Services.OrderService
{
    public interface IOrderService
    {
        Task<ServiceResponse<List<AddOrderResponse>>> AddOrder(int userId, List<int> foodIds);
    }
}