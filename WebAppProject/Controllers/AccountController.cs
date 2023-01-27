using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebAppProject.Controllers
{
    public class AccountController : Controller
    {
        // Get the UserManager from HttpContext
        public UserManager<IdentityUser> UserManager => HttpContext.GetOwinContext().Get<UserManager<IdentityUser>>();

        // Get the SignInManager from HttpContext
        public SignInManager<IdentityUser, string> SignInManager => HttpContext.GetOwinContext().Get<SignInManager<IdentityUser, string>>();

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            // Create the user
            var identityResult = await UserManager.CreateAsync(new IdentityUser(model.UserName), model.Password);

            // Validate result
            if (identityResult.Succeeded)
            {
                return RedirectToAction("index", "Home");
            }

            // Add errors if it's the case
            ModelState.AddModelError("", identityResult.Errors.FirstOrDefault());

            // Return errors to view
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model)
        {
            // Sign in the user
            var signInStatus = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, true, true);

            switch (signInStatus)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Home");
                default:
                    ModelState.AddModelError("", "Invalid Credentials");
                    return View(model);
            }

        }
    }

    public class RegisterModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}