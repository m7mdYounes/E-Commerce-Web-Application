using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly StoreContext context;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, StoreContext context,RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
            this.roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserVM uservm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = uservm.name;
                user.Email = uservm.email;
                user.PasswordHash = uservm.Password;
                user.addresss = uservm.address;
                user.PhoneNumber = uservm.phonenumber;
                IdentityResult identityResult = await userManager.CreateAsync(user, uservm.Password);
                if (identityResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "User");
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("index", "product");
                }

                else
                {
                    foreach (var item in identityResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(uservm);
        }

        [HttpGet]
        public IActionResult RegisterAdmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> RegisterAdmin(RegisterUserVM uservm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = uservm.name;
                user.Email = uservm.email;
                user.PasswordHash = uservm.Password;
                user.addresss = uservm.address;
                user.PhoneNumber = uservm.phonenumber;
                IdentityResult identityResult = await userManager.CreateAsync(user, uservm.Password);
                if (identityResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("index", "product");
                }

                else
                {
                    foreach (var item in identityResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(uservm);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserVM uservm)
        {
            if (ModelState.IsValid)
            {
             ApplicationUser user = await userManager.FindByEmailAsync(uservm.Email);
                if (user != null) 
                {
                    var re = await signInManager.CheckPasswordSignInAsync(user, uservm.Password, false);
                    return RedirectToAction("index", "product");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid E-mail Or Password,Try Again");
                }
            }
            return View(uservm);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
       // [ValidateAntiForgeryToken]
        public IActionResult addrole()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> addrole(RoleVM role)
        {
            if(ModelState.IsValid == true)
            {
                IdentityRole identityRole = new IdentityRole();
                identityRole.Name = role.userRole;
                IdentityResult identityResult = await roleManager.CreateAsync(identityRole);
                if (identityResult.Succeeded)
                {
                    return RedirectToAction("index", "product");
                }
                else
                {
                    foreach(var item in identityResult.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }
            }
            return View(role);

        }
        public async Task<IActionResult> signout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("login");
        }
    } 
}
