using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [NotMapped]
    public class LoginModel
    {
        /// <summary>
        /// Логин (почта)
        /// </summary>
        public string Login { get; set; } = string.Empty;

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; } = string.Empty;

        public LoginModel(IFormCollection collection)
        {
            Login = collection.Where(x => x.Key == "login").FirstOrDefault().Value;
            Password = collection.Where(x => x.Key == "password").FirstOrDefault().Value;
        } 
    }
}
