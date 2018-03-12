using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RockShop.Models;
using RockShop.ViewModels;

namespace RockShop.Controllers
{
    public class ShopController : Controller
    {
        private readonly IRockRepository _rockRepository;

        public ShopController(IRockRepository rockRepository)
        {
            _rockRepository = rockRepository;
        }
        public IActionResult Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";

            var Rocks = _rockRepository.GetRocks().AsQueryable();

            switch (sortOrder)
            {
                case "name_desc":
                    Rocks = Rocks.OrderByDescending(r => r.Name);
                    break;
                case "Price":
                    Rocks = Rocks.OrderBy(r => r.Price);
                    break;
                case "price_desc":
                    Rocks = Rocks.OrderByDescending(r => r.Price);
                    break;
                default:
                    Rocks = Rocks.OrderBy(r => r.Name);
                    break;
                
            }

            ShopViewModel results = new ShopViewModel
            {
                Rocks = Rocks.ToList(),
                sortOrder = sortOrder
            };


            return View(results);
        }
    }
}