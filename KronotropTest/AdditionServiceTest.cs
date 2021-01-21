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
    public class AdditionServiceTest
    {
        public IServiceProvider Preparationfor_Test()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<IAdditionService, AdditionService>();
            services.AddTransient<AdditionValidationControls>();
            return services.BuildServiceProvider();
        }

        [TestMethod]
        public void Get_Additions_Test()
        {
            var provider = Preparationfor_Test();
            var additionSer = provider.GetService<IAdditionService>();

            Addition testAddition = new Addition { Id = 99, Name = "TestAddition" };
            additionSer.AddAddition(testAddition);
            List<Addition> additions = additionSer.getAdditions();
            bool isInList = additions.Any(x => x.Id == 99 && x.Name == "TestAddition");
            Assert.IsTrue(isInList);
        }

        [TestMethod]
        public void Post_Add_Addition_Test()
        {
            var provider = Preparationfor_Test();
            var additionSer = provider.GetService<IAdditionService>();

            Addition testAddition = new Addition { Id = 99, Name = "TestAddition" };
            string resultAdd = additionSer.AddAddition(testAddition);
            Assert.AreEqual(resultAdd, "Success.");
        }

        [TestMethod]
        public void Post_Delete_Addition_Test()
        {
            var provider = Preparationfor_Test();
            var additionSer = provider.GetService<IAdditionService>();

            Addition testAddition = new Addition { Id = 99, Name = "TestAddition" };
            string resultAdd = additionSer.AddAddition(testAddition);
            string resultDelete = additionSer.DeleteAddition(testAddition);
            Assert.AreEqual(resultDelete, "Success.");
        }
    }
}
