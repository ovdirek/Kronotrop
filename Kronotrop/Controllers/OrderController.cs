using Kronotrop.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kronotrop.Controllers
{
    [ApiController]
    [Route("order")]
    public class OrderController : Controller
    {
        IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public List<Order> GetOrders()
        {
            return orderService.getOrders();
        }
        
        [HttpPost]
        public string SaveOrder(Order order)
        {
            return orderService.AddOrder(order);
        }
    }
}
