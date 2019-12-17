using Shopping.Core.BO;
using System.Collections.Generic;

namespace Shopping.Service.ServiceInterfaces
{
    public interface IOrderService
    {
        void AddOrder(OrderBO order);
        OrderBO GetOrderById(int id);
        OrderItemBO GetOrderItemById(int id);
        List<OrderBO> GetAllOrderByCustomer(int id);
        List<OrderBO> GetAllOrders();
        void AddOrderItem(OrderItemBO orderItem);
        void UpdateOrderItem(OrderItemBO orderItem);
        void DeleteOrderItem(int orderItemId);
    }
}
