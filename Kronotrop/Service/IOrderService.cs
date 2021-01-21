using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kronotrop.Service
{
    public interface IOrderService
    {
        public List<Order> getOrders();
        public string AddOrder(Order order);
    }
}
