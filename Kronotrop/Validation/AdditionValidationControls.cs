using Kronotrop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kronotrop.Validation
{
    public class AdditionValidationControls : Validation<Addition>
    {
        IAdditionService additionService;

        public AdditionValidationControls(IAdditionService additionService)
        {
            this.additionService = additionService;
        }
        public override string ValidateItemforAdd(Addition addition)
        {
            string result = string.Empty;
            List<Addition> additions = additionService.getAdditions();
            if (addition == null)
            {
                result = "Fail - Addition you want to add is null!";
            }
            else if(additions.Any(x => x.Id == addition.Id))
            {
                result = "Fail - There is same addition id!";
            }
            else if (additions.Any(x => x.Name == addition.Name))
            {
                result = "Fail - There is same addition name!";
            }
            else if (addition.Id <= 0)
            {
                result = "Fail - Addition Id that you want to add is 0!";
            }
            else if (string.IsNullOrWhiteSpace(addition.Name))
            {
                result = "Fail - Addition Name that you want to add is null!";
            }
            else
            {
                result = "Success.";
            }
            return result;
        }

        public override string ValidateItemforDelete(Addition addition)
        {
            string result = string.Empty;
            List<Addition> additions = additionService.getAdditions();
            if (addition == null)
            {
                result = "Fail - Addition you want to delete is null!";
            }
            else if (!additions.Any(x=> x.Id == addition.Id))
            {
                result = "Fail - There is no addition id that you want to delete!";
            }
            else if (!additions.Any(x=> x.Name == addition.Name))
            {
                result = "Fail - There is no addition name that you want to delete!";
            }
            else
            {
                result = "Success.";
            }
            return result;
        }
    }
}
