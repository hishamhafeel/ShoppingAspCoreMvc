using Shopping.Core.BO;
using Shopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Core.ServiceInterfaces
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
