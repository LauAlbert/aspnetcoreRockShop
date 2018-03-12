using RockShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockShop.ViewModels
{
    public class RockListViewModel
    {
        public IEnumerable<Rock> Rocks { get; set; }
        public IEnumerable<Rock> RockofTheWeek { get; set; }
    }
}
