﻿using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Order> GetOrder()
        {
            return _context.Orders.Include(i => i.User).OrderByDescending(o => o.Price * o.Quantity).FirstOrDefaultAsync();
        }

        public Task<List<Order>> GetOrders()
        {
            return _context.Orders.Where(x => x.Quantity > 10).ToListAsync();
        }
    }
}
