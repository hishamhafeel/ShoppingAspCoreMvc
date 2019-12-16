using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopping.Core.BO;
using Shopping.Core.Exceptions;
using Shopping.Core.ServiceInterfaces;
using Shopping.Data.Interfaces;
using Shopping.Data.Models;
using Shopping.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductService productService;
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;

        public OrderService(IUnitOfWork unitOfWork, IProductService productService,
                            ICustomerService customerService, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.productService = productService;
            this.customerService = customerService;
            this.mapper = mapper;
        }

        //Get all orders
        public List<OrderBO> GetAllOrders()
        {
            var orders = unitOfWork.OrderRepository.GetAll().OrderByDescending(d => d.OrderId).ToList();
            return mapper.Map<List<OrderBO>>(orders);
        }

        //Add order to db
        public void AddOrder(OrderBO order)
        {
            if (order == null)
            {
                throw new OrderNotFoundException();
            }
            order.Customer = customerService.GetCustomerById(order.CustomerId);
            foreach (var item in order.OrderItems)
            {
                var product = productService.GetProductById(item.ProductId);
                item.Product = product;
                item.UnitPrice = product.ProductUnitPrice;
            }
            var mappedOrder = mapper.Map<Order>(order);

            using (var transaction = unitOfWork.Context.Database.BeginTransaction())
            {
                try
                {
                    unitOfWork.OrderRepository.Create(mappedOrder);
                    unitOfWork.Save();
                    var orderItemList = mappedOrder.OrderItems.ToList();
                    productService.UpdateProductQuantityInStock(mapper.Map<List<OrderItemBO>>(orderItemList));

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);

                }
            }
        }

        //Add order item to db
        public void AddOrderItem(OrderItemBO orderItem)
        {
            if (orderItem == null)
            {
                throw new OrderItemNotFoundException();
            }
            unitOfWork.OrderItemRepository.Create(mapper.Map<OrderItem>(orderItem));
            //productService.ReduceProductQuantityInStock(orderItem.Product.ProductId, orderItem.Quantity);
        }

        //Get order for a given order ID
        public OrderBO GetOrderById(int id)
        {
            var order = unitOfWork.Context.Orders.Include(p => p.OrderItems).ThenInclude(i => i.Product).FirstOrDefault(f => f.OrderId == id);
            return mapper.Map<OrderBO>(order);
        }

        //Get order item for a given order item ID
        public OrderItemBO GetOrderItemById(int id)
        {
            var orderItem = unitOfWork.Context.OrderItems.Include(p => p.Product).Include(i => i.Order).FirstOrDefault(f => f.Id == id);
            return mapper.Map<OrderItemBO>(orderItem);
        }

        //Get all orders for a given customer ID
        public List<OrderBO> GetAllOrderByCustomer(int id)
        {
            var orders = unitOfWork.OrderRepository.GetAll().Where(r => r.CustomerId == id).OrderByDescending(d => d.OrderId).ToList();
            return mapper.Map<List<OrderBO>>(orders);
        }

        //Update order item
        public void UpdateOrderItem(OrderItemBO orderItem)
        {
            var existingOrderItem = unitOfWork.Context.OrderItems.AsNoTracking().Include(i => i.Order).FirstOrDefault(f => f.Id == orderItem.Id);

            //Validate the orderItem
            if (orderItem == null)
            {
                throw new OrderItemNotFoundException();

            }
            else if (orderItem.Quantity == existingOrderItem.Quantity)
            {
                throw new SameQuantityUpdateException();
            }

            using (var transaction = unitOfWork.Context.Database.BeginTransaction())
            {
                try
                {
                    var orderItems = new List<OrderItemBO> { orderItem };
                    //var existingOrderItem = unitOfWork.Context.OrderItems.Include(o => o.Order).FirstOrDefault(f => f.Id == orderItem.Id);
                    productService.UpdateProductQuantityInStock(orderItems);
                    var subTotal = existingOrderItem.UnitPrice * orderItem.Quantity;
                    existingOrderItem.Order.OrderTotal -= existingOrderItem.SubTotal;
                    existingOrderItem.Order.OrderTotal += subTotal;
                    existingOrderItem.SubTotal = subTotal;
                    existingOrderItem.Quantity = orderItem.Quantity;
                    unitOfWork.OrderItemRepository.Update(existingOrderItem);
                    unitOfWork.OrderRepository.Update(existingOrderItem.Order);


                    unitOfWork.Save();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }

            }


        }

        //Delete order item 
        public void DeleteOrderItem(int orderItemId)
        {
            var existingOrderItem = unitOfWork.Context.OrderItems.AsNoTracking().Include(i => i.Order)
                                                                                .Include(p => p.Product)
                                                                                .FirstOrDefault(f => f.Id == orderItemId);
            if (existingOrderItem == null)
            {
                throw new OrderItemNotFoundException();
            }
            using (var transaction = unitOfWork.Context.Database.BeginTransaction())
            {
                try
                {
                    ////Remove order item from order
                    existingOrderItem.Order.OrderTotal -= existingOrderItem.SubTotal;
                    existingOrderItem.Order.OrderItems.Remove(existingOrderItem);
                    unitOfWork.OrderRepository.Update(mapper.Map<Order>(existingOrderItem.Order));
                    //Delete order item
                    unitOfWork.OrderItemRepository.Delete(existingOrderItem);
                    var orderItems = new List<OrderItemBO> { mapper.Map<OrderItemBO>(existingOrderItem) };
                    //update quantity in stock of deleted product
                    productService.UpdateProductQuantityInStock(orderItems);
                    unitOfWork.Save();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
