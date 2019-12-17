using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shopping.Core.Domain.Customer;
using Shopping.Core.Domain.Order;
using Shopping.Core.Domain.Product;
using Shopping.Core.Domain.User;

namespace Shopping.Data
{
    public class AppDbContext : IdentityDbContext<StoreUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
