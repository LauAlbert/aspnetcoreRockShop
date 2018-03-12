using RockShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockShop.ViewModels
{
    public class ShopViewModel
    {
        public IEnumerable<Rock> Rocks { get; set; }
        public string sortOrder { get; set; }
    }
}
