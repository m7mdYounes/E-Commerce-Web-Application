using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CatalogueController : Controller
    {
        private readonly StoreContext context;

        public CatalogueController(StoreContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Catalogue catalogue)
        {
            if (ModelState.IsValid)
            {
                context.Catalogs.Add(catalogue);
                context.SaveChanges();
                return RedirectToAction("index", "product");
            }
            else
            {
                return View(catalogue);
            }
        }
    }
}
