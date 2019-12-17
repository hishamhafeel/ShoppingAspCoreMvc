using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.Core.BO;
using Shopping.ListModels;
using Shopping.Service.ServiceInterfaces;
using Shopping.ViewModels;

namespace Shopping.Controllers
{

    public class OrderController : Controller
    {
        private readonly ICustomerService customerService;
        private readonly IOrderService orderService;
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public OrderController(ICustomerService customerService, IOrderService orderService, 
                                    IProductService productService, IMapper mapper)
        {
            this.customerService = customerService;
            this.orderService = orderService;
            this.productService = productService;
            this.mapper = mapper;
        }

       


        //Home View with customer drop down
        [HttpGet]
        public IActionResult Index()
        {
            var customerNameResult = customerService.GetAllCustomers()
                .Select(s => new CustomerListModel { Text = s.CustomerName, Value = s.CustomerId }).ToList();
            
            PlaceOrderViewModel model = new PlaceOrderViewModel
            {
                CustomerNameList = new List<SelectListItem>()
            };

            foreach (var item in customerNameResult)
            {
                model.CustomerNameList.Add(new SelectListItem { Text = item.Text, Value = item.Value.ToString() });
            }

            model.OrderDate = DateTime.Now;

            return View(model);
        }

        
        //Place order with order items before saving 
        [HttpGet]
        public IActionResult PlaceOrder(PlaceOrderViewModel placeOrderModel)
        {
            if (ModelState.IsValid)
            {
                //product drop down for selecting product
                var productNameResult = productService.GetAllProducts()
                    .Select(s => new ProductListModel { Text = s.ProductName, Value = s.ProductId }).ToList(); ;
                var customer = customerService.
                    GetCustomerById(placeOrderModel.SelectedCustomerId);

                OrderViewModel model = new OrderViewModel()
                {
                    ProductNameList = new List<SelectListItem>(),
                    OrderDate = placeOrderModel.OrderDate,
                    CustomerId = placeOrderModel.SelectedCustomerId,
                    Customer = customer
                };

                foreach (var item in productNameResult)
                {
                    model.ProductNameList.
                        Add(new SelectListItem { Text = item.Text,
                            Value = item.Value.ToString() });
                }

                return View(model);
            }

            return NotFound();

        }

        //Get order for a given customer
        [HttpGet]
        public JsonResult GetOrdersByCustomer(int customerId)
        {
            var ordersList = orderService.GetAllOrderByCustomer(customerId);
            return Json(ordersList);
        }

        //Get all orders
        [HttpGet]
        public JsonResult GetAllOrders()
        {
            var ordersList = orderService.GetAllOrders();
            return Json(ordersList);
        }

        //Get order item details for given order item ID
        [HttpGet]
        public IActionResult ViewOrderItem(int orderItemId)
        {
            var orderItem = orderService.GetOrderItemById(orderItemId);
            var model = new UpdateOrderItemViewModel()
            {
                Id = orderItemId,
                Quantity = orderItem.Quantity,
                UnitPrice = orderItem.UnitPrice,
                SubTotal = orderItem.SubTotal,
                Order = orderItem.Order,
                ProductId = orderItem.Product.ProductId
            };
            return View(model);
        }

        //View order details 
        [HttpGet]
        public IActionResult ViewDetails(int orderId)
        {
            if (orderId != 0)
            {
                var order = orderService.GetOrderById(orderId);
                var customer = customerService.GetCustomerById(order.CustomerId);
               
                var model = new OrderDetailsViewModel()
                {
                    OrderId = order.OrderId,
                    OrderDate = order.OrderDate,
                    OrderTotal = order.OrderTotal,
                    OrderItems = order.OrderItems.ToList(),
                    CustomerId = order.CustomerId,
                    CustomerName = customer.CustomerName

                };

                return View(model);
            }

            return NotFound();
        }


        //Create order with order items
        [HttpPost]
        public IActionResult AddOrder(AddOrderItemsViewModel addOrderItemsViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ////create new order 
                    orderService.AddOrder(mapper.Map<OrderBO>(addOrderItemsViewModel));

                    return Json(new
                    {
                        success = true,
                        redirectUrl = Url.Action("Index", "Order")
                    });

                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    errors = new { ex.Message }
                });
            }

            return NotFound();
        }


        //Update Order Item for given order item ID
        [HttpPost]
        public IActionResult UpdateOrderItem(UpdateOrderItemViewModel updateOrderItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var product = productService.GetProductById(updateOrderItem.ProductId);
                    updateOrderItem.Product = product;

                    orderService.UpdateOrderItem(mapper.Map<OrderItemBO>(updateOrderItem));

                    var id = updateOrderItem.Order.OrderId;
                    return RedirectToAction("ViewDetails", "Order", new { orderId = id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
                
            
            return NotFound();
        }


        //Delete order item for a given order item ID
        [HttpPost]
        public IActionResult DeleteOrderItem(int orderItemId)
        {
            try
            {
                if (orderItemId != 0)
                {
                    //var orderItem = orderService.GetOrderItemById(orderItemId);

                    orderService.DeleteOrderItem(orderItemId);

                    return Json(new
                    {
                        success = true,
                        redirectUrl = Url.Action("Index", "Order")
                    });

                }
            }
            catch (Exception ex)
            {

                return Json(new
                {
                    success = false,
                    errors = new { ex.Message }
                });
            }

            return NotFound();
        }

        
    }
}