using E_Commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo iprd;
        private readonly ICatalogueRepo icat;
        public ProductController(IProductRepo iprd, ICatalogueRepo icat)
        {
            this.iprd = iprd;
            this.icat = icat;
        }
        public IActionResult Index()
        {
            List<Product> prds =  iprd.GetAll();
            return View(prds);
        }
        public IActionResult Details(int id) 
        {
            Product prd = iprd.GetbyId(id);
            return View(prd);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Addprd()
        {
            List<Catalogue> catsList = icat.GetAll();
            ViewBag.Cats = new SelectList(catsList, "Id", "Name");
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]

        public IActionResult Addprd(Product prd)
        {
            if (ModelState.IsValid)
            {
                iprd.Add(prd);
                iprd.save();
                iprd.GetAll();
                return RedirectToAction("index");
            }
            else
            {
                List<Catalogue> catsList = icat.GetAll();
                ViewBag.Cats = new SelectList(catsList, "Id", "Name");
                return View(prd);
            }
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult editprd(int id)
        {
            Product prd = iprd.GetbyId(id);
            List<Catalogue> catsList = icat.GetAll();
            ViewBag.Cats = new SelectList(catsList, "Id", "Name");
            return View(prd);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]

        public IActionResult editprd(Product prd)
        {
            if (ModelState.IsValid)
            {
                iprd.Update(prd);
                iprd.save();
                iprd.GetAll();
                return RedirectToAction("index");
            }
            else
            {
                List<Catalogue> catsList = icat.GetAll();
                ViewBag.Cats = new SelectList(catsList, "Id", "Name");
                return View(prd);
            }
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult deleteprd(int id)
        {
            Product prd = iprd.GetbyId(id);
            List<Catalogue> catsList = icat.GetAll();
            ViewBag.Cats = new SelectList(catsList, "Id", "Name");
            return View(prd);
        }
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult delete(int id)
        {
                iprd.Delete(id);
                iprd.save();
                iprd.GetAll();
                return RedirectToAction("Index","product");
        }

    }
}
