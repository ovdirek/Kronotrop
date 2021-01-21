using Kronotrop.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kronotrop.Service
{
    public class DrinkService : IDrinkService
    {
        public DrinkService()
        {
        }
        private List<Drink> drinks = new List<Drink>
        {
            new Drink{Id = 1, Name="Black Coffee"},
            new Drink{Id = 2, Name="Latte"},
            new Drink{Id = 3, Name="Mocha"},
            new Drink{Id = 4, Name="Tea"}
        };

        public List<Drink> getDrinks()
        {
            return drinks;
        }

        public string AddDrink(Drink drink)
        {
            var drinkValidation = new DrinkValidationControls(this);
            string result = drinkValidation.ValidateItemforAdd(drink);
            if (result.Substring(0, 4) == "Fail")
            {
                return result;
            }
            else
            {
                drinks.Add(drink);
                return result;
            }
        }

        public string DeleteDrink(Drink drink)
        {
            var drinkValidation = new DrinkValidationControls(this);
            string result = drinkValidation.ValidateItemforDelete(drink);
            if (result.Substring(0, 4) == "Fail")
            {
                return result;
            }
            else
            {
                var drinkDeleted = drinks.FirstOrDefault(x => x.Id == drink.Id);
                drinks.Remove(drinkDeleted);
                return result;
            }
        }

    }
}
