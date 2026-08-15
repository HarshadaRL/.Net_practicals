using _7_Aug.Models;

namespace _7_Aug.Repository
{
    public interface IOrderService
    {
        List<Orders> GetOrders();

        //Orders? GetOrderById(int id);

        //Orders AddOrder(Orders order);
    }
}
