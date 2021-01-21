using Kronotrop;
using Kronotrop.Service;
using Kronotrop.Validation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KronotropTest
{
    [TestClass]
    public class DrinkServiceTest
    {
        public IServiceProvider Preparationfor_Test()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<IDrinkService, DrinkService>();
            return services.BuildServiceProvider();
        }


        [TestMethod]
        public void Get_Drinks_Test()
        {
            var provider = Preparationfor_Test();
            var drinkser = provider.GetService<IDrinkService>();
                       
            Drink testDrink = new Drink { Id = 99, Name = "TestDrink" };
            drinkser.AddDrink(testDrink);
            List<Drink> drinks = drinkser.getDrinks();
            bool isInList = drinks.Any(x => x.Id == 99 && x.Name == "TestDrink");
            Assert.IsTrue(isInList);
        }

        [TestMethod]
        public void Post_Drink_Test()
        {
            var provider = Preparationfor_Test();
            var drinkser = provider.GetService<IDrinkService>();

            Drink testDrink = new Drink { Id = 99, Name = "TestDrink" };
            string result = drinkser.AddDrink(testDrink);
            Assert.AreEqual(result, "Success.");
        }

        [TestMethod]
        public void Post_Delete_Drink_Test()
        {
            var provider = Preparationfor_Test();
            var drinkSer = provider.GetService<IDrinkService>();

            Drink testDrink = new Drink { Id = 99, Name = "TestDrink" };
            string resultAdd = drinkSer.AddDrink(testDrink);
            string resultDelete = drinkSer.DeleteDrink(testDrink);
            Assert.AreEqual(resultDelete, "Success.");
        }

    }
}
