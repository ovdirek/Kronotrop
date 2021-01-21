using Kronotrop.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kronotrop.Service
{
    public class AdditionService : IAdditionService
    {
        public AdditionService()
        {
        }
        private List<Addition> additions = new List<Addition>()
        {
            new Addition{Id = 1, Name="Milk"},
            new Addition{Id = 2, Name="Chocalate sauce"},
            new Addition{Id = 3, Name="Hazelnut Syrup"},
        };

        public List<Addition> getAdditions()
        {
            return additions;
        }

        public string AddAddition(Addition addition)
        {
            var additionValidation = new AdditionValidationControls(this);
            string result = additionValidation.ValidateItemforAdd(addition);
            if (result.Substring(0,4) == "Fail")
            {
                return result;
            }
            else
            {
                additions.Add(addition);
                return result;
            }
        }

        public string DeleteAddition(Addition addition)
        {
            var additionValidation = new AdditionValidationControls(this);
            string result = additionValidation.ValidateItemforDelete(addition);
            if (result.Substring(0,4) == "Fail")
            {
                return result;
            }
            else
            {
                var additionDeleted = additions.FirstOrDefault(x => x.Id == addition.Id);
                additions.Remove(additionDeleted);
                return result;
            }
        }
    }
}
