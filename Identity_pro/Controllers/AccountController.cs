using Identity_pro.Data;
using Identity_pro.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity_pro.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signinManager;

        public AccountController(ApplicationDbContext context,UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signinManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.signinManager = signinManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            IdentityUser user = new IdentityUser()
            {
                Email = model.Email,
                PhoneNumber = model.Phone,
                UserName = model.Email
            };
            var result = await userManager.CreateAsync(user,model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel VmModel)
        {
            var result = await signinManager.PasswordSignInAsync(VmModel.Email, VmModel.Password, VmModel.RememberMe, false);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(VmModel);
        }
    }
}
