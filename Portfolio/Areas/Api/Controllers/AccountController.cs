using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Repositories;
using Portfolio.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Portfolio.Areas.Api.Controllers
{
    [Area("Api")]
    public class AccountController : Controller
    {
        private readonly AppDatabaseContext _ctx;
        private readonly UsersRepository _usersRep;
        private readonly RolesRepository _rolesRep;

        public AccountController(AppDatabaseContext ctx)
        {
            _ctx = ctx;
            _usersRep = new UsersRepository(_ctx);
            _rolesRep = new RolesRepository(_ctx);
        }

        public async Task<JsonResult> IsAuth()
        {
            if (User.Identity.IsAuthenticated)
            {
                UserModel user = await _usersRep.GetUserWithRoleByLogin(User.Identity.Name);
                return Json(new ResponseModel
                {
                    ResultCode = 0,
                    Data = new
                    {
                        Id = user.Id,
                        Login = user.Login,
                        RoleName = user.Role.RoleName,
                    }
                });
            }
            return Json(new ResponseModel
            {
                ResultCode = 1,
                Messages = new string[] { "User unautorized" },
            });
        }

        [HttpPost]
        public async Task<JsonResult> Login([FromBody]LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                    return Json(new ResponseModel
                    {
                        ResultCode = 1,
                        Messages = new string[] { "User already authorized" },
                    });
                UserModel user = await _usersRep.GetUserWithRoleByLogin(model.Login, model.Password);
                if (user != null)
                {
                    await Authenticate(user.Login, user.Role.RoleName);
                    return Json(new ResponseModel
                    {
                        ResultCode = 0,
                        Data = new
                        {
                            Id = user.Id,
                            Login = user.Login,
                            RoleName = user.Role.RoleName,
                        }
                    });
                }
                return Json(new ResponseModel
                {
                    ResultCode = 1,
                    Messages = new string[] { "Login or passwrod is invalid" },
                });
            }
            return Json(new ResponseModel
            {
                ResultCode = 1,
                Messages = new string[] { "Args is invalid" },
            });
        }

        [HttpPost]
        public async Task<JsonResult> Register(RegisterViewModel model)
        {
            if (User.Identity.IsAuthenticated)
                return Json(new ResponseModel
                {
                    ResultCode = 1,
                    Messages = new string[] { "User still authorized" },
                });
            if (ModelState.IsValid)
            {
                UserModel user = await _usersRep.GetUserByLogin(model.Login);
                if (user == null)
                {
                    RoleModel userRole = await _rolesRep.GetRoleByName("user");
                    user = new UserModel { Login = model.Login, Password = model.Password, Role = userRole };
                    await _usersRep.AddUser(user);
                    await Authenticate(user.Login, user.Role.RoleName);
                    return Json(new ResponseModel
                    {
                        ResultCode = 0,
                        Data = new
                        {
                            Id = user.Id,
                            Login = user.Login,
                            RoleName = user.Role.RoleName,
                        }
                    });
                }
                return Json(new ResponseModel
                {
                    ResultCode = 1,
                    Messages = new string[] { "User with wrote login already exists" },
                });
            }
            return Json(new ResponseModel
            {
                ResultCode = 1,
                Messages = new string[] { "Args is invalid" },
            });
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

        public async Task<JsonResult> Logout()
        {
            if (!User.Identity.IsAuthenticated)
                return Json(new ResponseModel
                {
                    ResultCode = 1,
                    Messages = new string[] { "User unautorized" },
                });
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Json(new ResponseModel
            {
                ResultCode = 0,
            });
        }
    }
}
