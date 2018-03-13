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
        public async Task<IActionResult> Index(string sortOrder, int? page)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["CurrentSort"] = sortOrder;

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

            int pageSize = 4;

            ShopViewModel results = new ShopViewModel
            {
                Rocks = await PaginatedList<Rock>.CreateAsync(Rocks, page ?? 1, pageSize),
                sortOrder = sortOrder
            };


            return View(results);
        }
    }
}