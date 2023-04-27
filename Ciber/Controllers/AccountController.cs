using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Ciber.Models;

namespace Ciber.Controllers
{
  
    public class AccountController : Controller
    {
        public IActionResult Login(string requestPath)
        {
            ViewBag.RequestPath = requestPath ?? "/";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!IsAuthenticated(model.Username, model.Password))
                return View();

            // create claims
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Cookie authentication"),
                new Claim(ClaimTypes.Email, model.Username)
            };

            // create identity
            ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");

            // create principal
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            // sign-in
            await HttpContext.SignInAsync(
                    scheme: "CiberSecurityScheme",
                    principal: principal,
                    properties: new AuthenticationProperties
                    {
                       
                    });

            return Redirect(model.RequestPath ?? "/");
        }

        public async Task<IActionResult> Logout(string requestPath)
        {
            await HttpContext.SignOutAsync(
                    scheme: "CiberSecurityScheme");

            return RedirectToAction("Login");
        }

        public IActionResult Access()
        {
            return View();
        }

        private bool IsAuthenticated(string username, string password)
        {
            return (username == "root" && password == "admin");
        }
    }
}
