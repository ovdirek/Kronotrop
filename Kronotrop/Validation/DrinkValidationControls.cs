using Kronotrop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kronotrop.Validation
{
    public class DrinkValidationControls : Validation<Drink>
    {
        IDrinkService drinkService;

        public DrinkValidationControls(IDrinkService drinkService)
        {
            this.drinkService = drinkService;
        }
        public override string ValidateItemforAdd(Drink drink)
        {
            string result = string.Empty;
            List<Drink> drinks = drinkService.getDrinks();
            if (drink == null)
            {
                result = "Fail - Drink is null!";
            }
            else if (drinks.Any(x => x.Id == drink.Id))
            {
                result = "Fail - There is same drink id!";
            }
            else if (drinks.Any(x => x.Name == drink.Name))
            {
                result = "Fail - There is same drink name!";
            }
            else if (drink.Id <= 0)
            {
                result = "Fail - Drink Id that you want to add is 0!";
            }
            else if (string.IsNullOrWhiteSpace(drink.Name))
            {
                result = "Fail - Drink Name that you want to add is null!";
            }
            else
            {
                result = "Success.";
            }
            return result;
        }

        public override string ValidateItemforDelete(Drink drink)
        {
            string result = string.Empty;
            List<Drink> drinks = drinkService.getDrinks();
            if (drink == null)
            {
                result = "Fail - Drink you want to delete is null!";
            }
            else if (!drinks.Any(x=>x.Id == drink.Id))
            {
                result = "Fail - There is no drink id that you want to delete!";
            }
            else if (!drinks.Any(x => x.Name == drink.Name))
            {
                result = "Fail - There is no drink name that you want to delete!";
            }
            else
            {
                result = "Success.";
            }
            return result;
        }
    }
}
