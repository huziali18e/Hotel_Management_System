using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Hotel_Management_System.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Hotel_Management_System.Controllers
{
    public class AccessController : Controller
    {
        public IActionResult Login()
        {
            ClaimsPrincipal claimuser = HttpContext.User;
            if(claimuser.Identity.IsAuthenticated)
                {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login( VMLogin vMLogin)
        {
            if (vMLogin.Email == "Admin12@gmail.com" && vMLogin.Password == "123")
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, vMLogin.Email),
                    new Claim("OtherProperties", "Example Role")
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties Properties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    Properties);
                return RedirectToAction("Index", "Home");
            }
            ViewData["Message"] = "Invalid Credentials, Please try again.";
            return View();
        }
    }
}
