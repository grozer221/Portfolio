using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Portfolio.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Portfolio.Models;
using Portfolio.Repositories;
using Portfolio.Utils;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UsersRepository _usersRep;
        private readonly RolesRepository _rolesRep;
        public AccountController(UsersRepository usersRep, RolesRepository rolesRep)
        {
            _usersRep = usersRep;
            _rolesRep = rolesRep;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel user = _usersRep.GetIncludedRole(model.Login, model.Password);
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
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel user = await _usersRep.GetIncludedRoleAsync(model.Login);
                if (user == null)
                {
                    RoleModel userRole = await _rolesRep.GetRoleByName("user");
                    user = new UserModel { Login = model.Login, Password = Hashing.GetHashString(model.Password), Role = userRole };
                    await _usersRep.AddUser(user);
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
