using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RockShop.Models;
using RockShop.ViewModels;

namespace RockShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRockRepository _rockRepository;

        public HomeController(IRockRepository rockRepository)
        {
            _rockRepository = rockRepository;
        }
        public IActionResult Index()
        {
            RockListViewModel rockListViewModel = new RockListViewModel();
            rockListViewModel.Rocks = _rockRepository.GetRocks();
            rockListViewModel.RockofTheWeek = _rockRepository.GetRockOfTheWeek();
        
            return View(rockListViewModel);
        }
        public IActionResult Detail(int id)
        {
            var rock = _rockRepository.GetRock(id);
            if(rock == null)
            {
                return NotFound();
            }
            return View(rock);
        }
    }
}