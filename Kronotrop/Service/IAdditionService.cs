using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kronotrop.Service
{
    public interface IAdditionService
    {
        public List<Addition> getAdditions();
        public string AddAddition(Addition addition);
        string DeleteAddition(Addition addition);
    }
}
