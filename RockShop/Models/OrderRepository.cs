using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;
        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _appDbContext.Orders.Add(order);
            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var item = new Item()
                {
                    Amount = shoppingCartItem.Amount,
                    RockId = shoppingCartItem.Rock.Id,
                    OrderId = order.Id,
                    Price = shoppingCartItem.Rock.Price
                };
                _appDbContext.Items.Add(item);
            }
            _appDbContext.SaveChanges();

        }
    }
}
