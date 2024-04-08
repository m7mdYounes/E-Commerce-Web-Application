using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E_Commerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepo iprd;
        private readonly ICatalogueRepo icat;

        public HomeController(ILogger<HomeController> logger, IProductRepo iprd, ICatalogueRepo icat)
        {
            this.iprd = iprd;
            this.icat = icat;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Product> prds = iprd.GetAll();
            return View(prds);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
