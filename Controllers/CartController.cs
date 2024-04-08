using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;

namespace E_Commerce.Controllers
{
    public class CartController : Controller
    {
        private readonly StoreContext context;

        public CartController(StoreContext context)
        {
            this.context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            Claim uid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            string userid = uid.Value;
            List<Cart> carts = context.Carts
            .Include(c => c.product)  // Eager loading of Product
            .Where(c => c.userid == userid)
            .ToList();
            //List<Cart> carts = context.Carts.Where(c=>c.userid == userid).ToList(); 
            return View(carts);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(int productId)
        {
            Claim uid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            string userId = uid.Value;
            Cart c = context.Carts.FirstOrDefault(c => c.userid == userId && c.productID == productId);
            if (c == null)
            {
            Cart cartItem = new Cart
                {
                    userid = userId,
                    productID = productId
                };

                context.Carts.Add(cartItem);
                context.SaveChanges();
                return RedirectToAction("index", "Product");
            }

            return RedirectToAction("Index", "Product");
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult removefromcart(int productId)
        {
            Claim uid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            string userid = uid.Value;

            Cart cart = context.Carts.FirstOrDefault(c => c.userid == userid && c.productID == productId);

            if (cart != null)
            {
                context.Carts.Remove(cart);
                context.SaveChanges();

                return RedirectToAction("Index", "Cart");
            }
            else
            {
                TempData["ErrorMessage"] = "Item not found in the cart.";
                return RedirectToAction("Index", "Cart");
            }
        }

        //[Authorize]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult removefromcart(int productId)
        //{
        //    Claim uid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        //    string userid = uid.Value;
        //    Cart cart = context.Carts.FirstOrDefault(c => c.userid == userid && c.productID == productId);
        //    context.Carts.Remove(cart);
        //    context.SaveChanges();
        //    return View("Index", "Product");

        //}

        //[Authorize]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult addtocart(int pid)
        //{
        //    Claim uid = User.Claims.FirstOrDefault( c=> c.Type == ClaimTypes.NameIdentifier);
        //    string userid = uid.Value;

        //    Cart c = context.Carts.FirstOrDefault(c => c.userid == userid && c.productID == pid);
        //    if (c == null)
        //    {
        //        Cart cart = new Cart()
        //        {
        //            userid = userid,
        //            productID = pid
        //        };
        //        context.Carts.Add(cart);
        //        context.SaveChanges();
        //        return RedirectToAction("index", "Product");
        //    }
        //    else
        //    {
        //        return View("index","Cart");


        //    }
        //}





    }
}
