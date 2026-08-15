using _7_Aug.Data;
using _7_Aug.Models;
using _7_Aug.Repository;
using Microsoft.EntityFrameworkCore;

namespace _7_Aug.Services
{

    public class OrderService : IOrderService
    {
        private readonly AppDbContext context;

        public OrderService(AppDbContext context)
        {
            this.context = context;
        }

        public List<Orders> GetOrders()
        {
            // Load OrderItems for each Order
            // Load Product details for each OrderItem
            return context.Orders.Include(o => o.OrderItems!).ThenInclude(i => i.Product).ToList();
        }
    }
}

