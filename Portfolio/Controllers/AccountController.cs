using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Portfolio.Models;
using Portfolio.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Portfolio.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDatabaseContext _ctx;
        public AccountController(AppDatabaseContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel user = await _ctx.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user.Login, user.Role.RoleName);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Wrong login or password");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel user = await _ctx.Users.FirstOrDefaultAsync(u => u.Login == model.Login);
                if (user == null)
                {
                    var userRole = await _ctx.Roles.FirstOrDefaultAsync(r => r.RoleName == "user");
                    user = new UserModel { Login = model.Login, Password = model.Password, Role = userRole };
                    _ctx.Users.Add(user);
                    await _ctx.SaveChangesAsync();
                    await Authenticate(user.Login, user.Role.RoleName);
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Wrong login or password");
            }
            return View(model);
        }

        private async Task Authenticate(string userName, string roleName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, roleName),
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
