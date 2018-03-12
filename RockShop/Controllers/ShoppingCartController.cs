using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RockShop.Models;
using RockShop.ViewModels;

namespace RockShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IRockRepository _rockRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IRockRepository rockRepository, ShoppingCart shoppingCart)
        {
            _rockRepository = rockRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int Id)
        {
            var selectedRock = _rockRepository.GetRocks().FirstOrDefault(r => r.Id == Id);

            if (selectedRock != null)
            {
                _shoppingCart.AddToCart(selectedRock, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int Id)
        {
            var selectedRock = _rockRepository.GetRocks().FirstOrDefault(r => r.Id == Id);

            if (selectedRock != null)
            {
                _shoppingCart.RemoveFromCart(selectedRock);
            }
            return RedirectToAction("Index");
        }
    }
}