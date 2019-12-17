using Microsoft.EntityFrameworkCore;
using Shopping.Core.BO;
using Shopping.Core.Domain.Product;
using Shopping.Core.Exceptions;
using Shopping.Data.Interfaces;
using Shopping.Service.ServiceInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shopping.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var result = unitOfWork.ProductRepository.GetAll();
            return result;
        }

        public Product GetProductById(int id)
        {
            return unitOfWork.ProductRepository.GetById(id);

        }

        //Reduce qty in stock for a given product
        public void UpdateProductQuantityInStock(List<OrderItemBO> orderItems)
        {

            foreach (var item in orderItems)
            {
                var product = unitOfWork.ProductRepository.GetById(item.Product.ProductId);
                var existingOrderItem = unitOfWork.Context.OrderItems.AsNoTracking().FirstOrDefault(f => f.Id == item.Id);
                var existingQty = existingOrderItem.Quantity;
                var placedQty = item.Quantity;
                var currentQtyInStock = product.ProductQtyInStock;
                var qtyToBeUpdated = 0;
                decimal newQty = 0;

                //check if qty is to be added or reduced
                if (placedQty < existingQty)
                {
                    //check qty to be added to stock
                    qtyToBeUpdated = existingQty - placedQty;
                    //add the qty to stock for relevant product
                    newQty = currentQtyInStock + qtyToBeUpdated;
                    

                }
                else if (placedQty > existingQty)
                {
                    qtyToBeUpdated = placedQty - existingQty;
                    //reduce the qty to stock for relevant product
                    newQty = currentQtyInStock - qtyToBeUpdated;
                    
                }
                else if(placedQty == existingQty)
                {

                    newQty = currentQtyInStock - placedQty;
                }

                //check if product is available in stock
                if (currentQtyInStock <= 0)
                {
                    throw new NoItemInStockException();
                }

                product.ProductQtyInStock = newQty;
                unitOfWork.ProductRepository.Update(product);
                unitOfWork.Save();
            }

           
        }

        

        
    }
}
