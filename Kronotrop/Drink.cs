using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kronotrop
{
    public class Drink
    {
        [Required]
        public int Id { get; set; }
        
        public string Name { get; set; }
    }
}
