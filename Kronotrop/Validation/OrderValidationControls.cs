using Kronotrop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kronotrop.Validation
{
    public class OrderValidationControls : Validation<Order>
    {
        IOrderService orderService;

        public OrderValidationControls(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public override string ValidateItemforAdd(Order order)
        {
            string result = string.Empty;
            List<Order> orders = orderService.getOrders();
            if (order == null)
            {
                result = "Fail - Order is null!";
            }
            else if (order.drinkId <= 0)
            {
                result = "Fail - Order Id that you want to add is 0!";
            }
            else if (order.addtionIds == null)
            {
                result = "Fail - Addition Id that you want to add is null!";
            }
            else
            {
                result = "Success.";
            }
            return result;
        }

        public override string ValidateItemforDelete(Order order)
        {
            string result = string.Empty;
            List<Order> orders = orderService.getOrders();
            if (order == null)
            {
                result = "Fail - Order you want to delete is null!";
            }
            return result;
        }
    }
}
