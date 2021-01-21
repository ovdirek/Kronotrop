using Kronotrop.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kronotrop.Controllers
{
    [ApiController]
    [Route("drink")]
    public class DrinkController : ControllerBase
    {
        IDrinkService drinkService;

        public DrinkController(IDrinkService drinkService)
        {
            this.drinkService = drinkService;
        }

        [HttpGet]
        public List<Drink> GetDrinks()
        {            
            return drinkService.getDrinks();
        }
      
        [HttpPost]
        public string SaveDrink(Drink drink)
        {
            return drinkService.AddDrink(drink);
        }

        [HttpDelete]
        public string DeleteDrink(Drink drink)
        {
            return drinkService.DeleteDrink(drink);
        }
    }
}
