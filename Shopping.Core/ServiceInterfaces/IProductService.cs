using Shopping.Core.BO;
using Shopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Core.ServiceInterfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        void UpdateProductQuantityInStock(List<OrderItemBO> orderItems);

    }
}
