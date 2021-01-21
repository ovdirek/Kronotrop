using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kronotrop
{
    public class Order
    {
        [Required]
        public int drinkId { get; set; }
        public List<int> addtionIds { get; set; }
    }


}
