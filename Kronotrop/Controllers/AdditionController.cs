using Kronotrop.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kronotrop.Controllers
{
    [ApiController]
    [Route("addition")]
    public class AdditionController : Controller
    {
        IAdditionService additionService;

        public AdditionController(IAdditionService additionService)
        {
            this.additionService = additionService;
        }

        [HttpGet]
        public List<Addition> GetAdditions()
        {
            return additionService.getAdditions();
        }

        [HttpPost]
        public string SaveAddition(Addition addition)
        {
            return additionService.AddAddition(addition);
        }

        [HttpDelete]
        public string DeleteAddition(Addition addition)
        {
            return additionService.DeleteAddition(addition);
        }
    }
}
