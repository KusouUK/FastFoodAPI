using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FastFoodAPI.DataObjects.Order;
using Microsoft.EntityFrameworkCore;

namespace FastFoodAPI.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public OrderService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }



        public async Task<ServiceResponse<List<AddOrderResponse>>> AddOrder(int userId, List<int> foodIds)
        {
            var response = new ServiceResponse<List<AddOrderResponse>>();

            try
            {
                var foods = await _context.Foods
                    .Where(f => foodIds.Contains(f.Id))
                    .ToListAsync();

                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Id == userId);
                
                if (foods.Count == 0 || user is null)
                {
                    response.Ok = false;
                    response.Message = $"Food/user not found.";
                    return response;
                }

                var order = await _context.Orders
                    .Include(o => o.Foods)
                    .Include(o => o.User)
                    .FirstOrDefaultAsync(o => o.UserId == userId);

                if (order is null)
                {
                    var newOrder = new Order
                    {
                        UserId = userId,
                        Foods = foods
                    };

                    _context.Orders.Add(newOrder);
                    await _context.SaveChangesAsync();

                    response.Data = newOrder.Foods.Select(o => _mapper.Map<AddOrderResponse>(o)).ToList();
                    return response;
                }

                foreach (var food in foods)
                {
                    order.Foods!.Add(food);
                }

                await _context.SaveChangesAsync();
                response.Data = order.Foods!.Select(o => _mapper.Map<AddOrderResponse>(o)).ToList();
            }
            catch (Exception e)
            {
                response.Ok = false;
                response.Message = e.Message;
            }

            return response;
        }
    }
}