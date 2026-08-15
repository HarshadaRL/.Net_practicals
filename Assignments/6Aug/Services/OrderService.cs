using _06Aug_2026.Data;
using _06Aug_2026.Models;
using _06Aug_2026.Repository;

namespace _06Aug_2026.Services
{
    //implement logic for CRUD method of Order entity
    //service - business logic
    //dbcontext - add, savechanges, find, tolist, update, remove

    public class OrderService : IOrderService
    {
        private readonly AppDbContext context;

        public OrderService(AppDbContext context)
        {
            this.context = context;
        }

        public void AddOrder(Order order)
        {
            context.orders.Add(order); //implementation of adding new Order with help of add
            context.SaveChanges(); //saving new added order in table
        }

        public void DeleteOrder(int id)
        {
            var order = context.orders.Find(id);

            if (order != null)
            {
                context.orders.Remove(order); //implementation of remove existing order
                context.SaveChanges(); //saving changes after deleting order
            }
        }

        public Order? GetOrderById(int id)
        {
            return context.orders.Find(id); //implementation of getOrder By ID with help of find
        }

        public List<Order> GetOrders()
        {
            return context.orders.ToList(); //implementation of getOrder with help of toList
        }

        public void UpdateOrder(Order order)
        {
            context.orders.Update(order); //implementation of updating existing Order with help of update
            context.SaveChanges(); //saving existing updated order in table
        }
    }
}
