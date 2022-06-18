using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        #region Страница пользователя
        /// <summary>
        /// Возвращает страницу с данными пользователя
        /// </summary>
        [HttpGet]
        [Route("User/{user_name}")]
        public IActionResult UserPage()
        {
            return View("UserPage");
        }
        #endregion

        #region Авторизация пользователя
        /// <summary>
        /// Возвращает страницу для авторизации пользователя
        /// </summary>
        [HttpGet]
        [Route("Login")]
        [Route("User/Login")]
        public IActionResult LoginPage()
        {
            return View("LoginPage");
        }
        #endregion

        #region Регистрация пользователя
        /// <summary>
        /// Возвращает страницу для регистрации пользователя
        /// </summary>
        [HttpGet]
        [Route("")]
        [Route("Registration")]
        [Route("User/Registration")]
        public IActionResult RegistrationPage()
        {
            return View("RegistrationPage");
        }
        #endregion
    }
}
