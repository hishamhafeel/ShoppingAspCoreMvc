using Shopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data.Interfaces
{
    public interface IUnitOfWork
    {
        GenericRepository<Customer> CustomerRepository { get; }
        GenericRepository<Product> ProductRepository { get; }
        GenericRepository<Order> OrderRepository { get; }
        GenericRepository<OrderItem> OrderItemRepository { get; }
        AppDbContext Context { get; }
        void Save();

    }
}
