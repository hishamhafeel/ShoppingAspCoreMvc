using Microsoft.AspNetCore.Builder;
using Shopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Shopping.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return;
            }

            var products = new List<Product>
            {
                new Product {/* ProductId=001,*/ ProductName="Soap", ProductDescription="This is a soap.", ProductQtyInStock=100.0M, ProductUnitPrice=50M},
                new Product {/* ProductId=002,*/ ProductName="Cream", ProductDescription="This is a cream.", ProductQtyInStock=200.0M, ProductUnitPrice=250M},
                new Product {/* ProductId=003,*/ ProductName="Shampoo", ProductDescription="This is a shampoo.", ProductQtyInStock=300.0M, ProductUnitPrice=200M},
                new Product {/* ProductId=004,*/ ProductName="Perfume", ProductDescription="This is a perfume.", ProductQtyInStock=50.0M, ProductUnitPrice=500M}
            };

            
            var customers = new List<Customer>
            {
                new Customer { CustomerName="Hisham Hafeel", AddressLine1="No.33, Marukona Watta, Ukuwela, Matale", AddressLine2="", Email="hisham_89@live.com", Phone="0771233625", CreditCard="4111 1111 1111 1111"},
                new Customer { CustomerName="Raes Samman", AddressLine1="No.176, Arthurs Place, Nugegoda, Colombo", AddressLine2="", Email="raess@gmail.com", Phone="0770987654", CreditCard="4123 1671 1441 1775"},
                new Customer { CustomerName="Roshan Ahmed", AddressLine1="No.44, Hill Street, Dehiwela, Colombo", AddressLine2="", Email="roshan@gmail.com", Phone="0765552221", CreditCard="0075 1997 1098 1998"}
            };


            context.Products.AddRange(products);
            context.Customers.AddRange(customers);
            context.SaveChanges();
        }
    }
}
