using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockShop.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int RockId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Rock Rock { get; set; }
        public Order Order { get; set; }
    }
}
