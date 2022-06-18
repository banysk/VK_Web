using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Utils;
using Web.Database;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UsersHandler _users;
        private readonly TechsHandler _techs;

        public UserController(UsersHandler users, TechsHandler techs)
        {
            _users = users;
            _techs = techs;
        }

        #region Страница пользователя
        /// <summary>
        /// Возвращает страницу с данными пользователя
        /// </summary>
        [HttpGet]
        [Authorize]
        [Route("User/{login}")]
        public IActionResult UserPage(string login)
        {
            return View("UserPage", _users.getUser(login));
        }
        #endregion

        #region Авторизация пользователя
        /// <summary>
        /// Возвращает страницу для авторизации пользователя
        /// </summary>
        [HttpGet]
        [Route("Login")]
        public IActionResult LoginPage()
        {
            return View("LoginPage");
        }

        /// <summary>
        /// Выполняет авторизацию пользователя
        /// </summary>
        [HttpPost]
        [Route("User/Login")]
        public async Task<IActionResult> Login(IFormCollection collection)
        {
            LoginModel inputData = InputParser.ParseLoginCollection(collection);
            if (_users.Login(inputData))
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, inputData.Login)
                    };

                ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);

                await AuthenticationHttpContextExtensions.SignInAsync(HttpContext, new ClaimsPrincipal(id));
                return RedirectToAction("UserPage", _users.getUser(inputData.Login));
            }
            return Redirect("/Login");
        }
        #endregion

        #region Регистрация пользователя
        /// <summary>
        /// Возвращает страницу для регистрации пользователя
        /// </summary>
        [HttpGet]
        [Route("")]
        [Route("Registration")]
        public IActionResult RegistrationPage()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated && User.Identity.Name != null)
            {
                return Redirect($"User/{User.Identity.Name}");
            }
            return View("RegistrationPage");
        }

        /// <summary>
        /// Выполняет регистрацию пользователя
        /// </summary>
        [HttpPost]
        [Route("User/Registration")]
        public async Task<IActionResult> Registration(IFormCollection collection)
        {
            RegistrationModel inputData = InputParser.ParseRegistrationCollection(collection);
            if (_users.Registrate(inputData))
            {
                if (inputData.isChecked)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, inputData.Login)
                    };

                    ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);

                    await AuthenticationHttpContextExtensions.SignInAsync(HttpContext, new ClaimsPrincipal(id));
                    return Redirect($"User/{User.Identity.Name}");
                }
                return Redirect("/Login");
            } 
            return Redirect("/Registration");
        }
        #endregion

        #region Выход пользователя
        /// <summary>
        /// Выполняет выход пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("User/Logout")]
        public async Task<IActionResult> Logout()
        {
            await AuthenticationHttpContextExtensions.SignOutAsync(HttpContext);
            return Redirect("/Login");
        }
        #endregion
    }
}
