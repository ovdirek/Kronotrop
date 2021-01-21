using Kronotrop.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kronotrop.Service
{
    public class OrderService : IOrderService
    {

        public OrderService()
        {

        }
        private List<Order> Orders = new List<Order>()
        {

        };

        public List<Order> getOrders()
        {
            return Orders;
        }

        public string AddOrder(Order order)
        {
            var orderValidation = new OrderValidationControls(this);
            string result = orderValidation.ValidateItemforAdd(order);
            if (result.Substring(0, 4) == "Fail")
            {
                return result;
            }
            else
            {
                Orders.Add(order);
                return result;
            }
        }

        public string DeleteOrder(Order order)
        {
            var orderValidation = new OrderValidationControls(this);
            string result = orderValidation.ValidateItemforDelete(order);
            if (result.Substring(0,4) == "Fail")
            {
                return result;
            }
            else
            {
                Orders.Remove(order);
                return result;
            }
        }
    }
}
