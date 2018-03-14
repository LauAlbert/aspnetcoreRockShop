using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RockShop.Models;

namespace RockShop.Controllers
{
    public class RockController : Controller
    {
        private readonly IRockRepository _rockRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public RockController(IRockRepository rockRepository, IHostingEnvironment hostingEnvironment)
        {
            _rockRepository = rockRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        public ActionResult Index()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            return Content(webRootPath + "\n" + contentRootPath);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Rock rock)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                foreach (var Image in files)
                {
                    
                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;

                        var imageType = Image.Name;
                        //There is an error here
                        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, $"rocks\\img\\{imageType}");
                        if (file.Length > 0)
                        {
                            var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                if (Image.Name == "ImageThumbnailUrl")
                                {
                                    rock.ImageThumbnailUrl = $"rocks\\img\\{imageType}\\{fileName}";
                                }
                                else if (Image.Name == "ImageUrl")
                                {
                                    rock.ImageUrl = $"rocks\\img\\{imageType}\\{fileName}";
                                }
                            }

                        }
                    }
                }
                _rockRepository.AddRock(rock);
                await _rockRepository.Save();
                return RedirectToAction("CreateSuccess");
                
            }
            return View(rock);
        }

        public IActionResult CreateSuccess()
        {
            return View();
        }
    }
}