using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kronotrop.Validation
{
    public abstract class Validation<T>where T:class
    {
        public abstract string ValidateItemforAdd(T item);
        public abstract string ValidateItemforDelete(T item);
    }
}
