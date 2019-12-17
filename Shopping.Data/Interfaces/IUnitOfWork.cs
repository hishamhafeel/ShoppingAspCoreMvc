using Shopping.Core.Domain.Customer;
using Shopping.Core.Domain.Order;
using Shopping.Core.Domain.Product;
using Shopping.Data;

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
