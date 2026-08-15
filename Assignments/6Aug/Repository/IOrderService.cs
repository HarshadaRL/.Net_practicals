using _06Aug_2026.Models;

namespace _06Aug_2026.Repository
{
    //define all CRUD(create,read,update,delete) method for performing on Order entity
    public interface IOrderService
    {
        List<Order> GetOrders(); //fetch all order from order table

        Order? GetOrderById(int id); //fetch order detail from order table based on OrderId

        void AddOrder(Order order); //add new order record in order table

        void UpdateOrder(Order order); //modify order details from order table based on OrderId

        void DeleteOrder(int id); //remove order record from order table based on OrderId
    }
}
