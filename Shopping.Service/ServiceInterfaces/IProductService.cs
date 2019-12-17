using Shopping.Core.BO;
using Shopping.Core.Domain.Product;
using System.Collections.Generic;

namespace Shopping.Service.ServiceInterfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        void UpdateProductQuantityInStock(List<OrderItemBO> orderItems);

    }
}
