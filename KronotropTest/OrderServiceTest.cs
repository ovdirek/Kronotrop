using Kronotrop;
using Kronotrop.Service;
using Kronotrop.Validation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KronotropTest
{
    [TestClass]
    public class OrderServiceTest
    {
        public IServiceProvider Preparationfor_Test()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<IOrderService, OrderService>();
            
            return services.BuildServiceProvider();
        }
        [TestMethod]
        public void Get_OrdersTest()
        {
            var provider = Preparationfor_Test();
            var orderSer = provider.GetService<IOrderService>();

            var additions = new List<int>() { 1, 2 };
            Order testOrder = new Order { drinkId = 99, addtionIds = additions };
            orderSer.AddOrder(testOrder);
            List<Order> orders = orderSer.getOrders();
            bool isInList = orders.Any(x => x.drinkId == 99 && x.addtionIds.Any(addition=> addition == 1));
            Assert.IsTrue(isInList);
        }

        [TestMethod]
        public void Post_OrderTest()
        {
            var provider = Preparationfor_Test();
            var orderSer = provider.GetService<IOrderService>();

            var additions = new List<int>() { 1, 2 };
            Order testOrder = new Order { drinkId = 99, addtionIds = additions };
            string result = orderSer.AddOrder(testOrder);
            Assert.AreEqual(result, "Success.");
        }
    }
}
