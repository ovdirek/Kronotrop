using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kronotrop.Service
{
    public interface IDrinkService
    {
        public List<Drink> getDrinks();
        public string AddDrink(Drink drink);
        public string DeleteDrink(Drink drink);
    }
}
