using Shopping.Core.Domain.Customer;
using Shopping.Core.Domain.Order;
using Shopping.Core.Domain.Product;
using Shopping.Data.Interfaces;
using System;

namespace Shopping.Data.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly AppDbContext db;
        private GenericRepository<Customer> customerRepository;
        private GenericRepository<Product> productRepository;
        private GenericRepository<Order> orderRepository;
        private GenericRepository<OrderItem> orderItemRepository;
        public AppDbContext Context => db as AppDbContext;

        public UnitOfWork(AppDbContext db)
        {
            this.db = db;
        }
        public GenericRepository<Customer> CustomerRepository
        {
            get
            {
                if (this.customerRepository == null)
                {
                    this.customerRepository = new GenericRepository<Customer>(db);
                }
                return customerRepository;
            }

        }

        public GenericRepository<Product> ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new GenericRepository<Product>(db);
                }
                return productRepository;
            }
        }
        public GenericRepository<Order> OrderRepository
        {
            get
            {
                if (this.orderRepository == null)
                {
                    this.orderRepository = new GenericRepository<Order>(db);
                }
                return orderRepository;
            }
        }
        public GenericRepository<OrderItem> OrderItemRepository
        {
            get
            {
                if (this.orderItemRepository == null)
                {
                    this.orderItemRepository = new GenericRepository<OrderItem>(db);
                }
                return orderItemRepository;
            }
        }


        public void Save()
        {
            db.SaveChanges();
        }



        private bool disposed = false;
       

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
