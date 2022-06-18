using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [NotMapped]
    public class RegistrationModel
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; } = string.Empty;

        /// <summary>
        /// Логин (почта)
        /// </summary>
        public string Login { get; set; } = string.Empty;

        /// <summary>
        /// Запомнить меня?
        /// </summary>
        public bool isChecked { get; set; } = false;

        public RegistrationModel(IFormCollection collection)
        {
            Name = collection.Where(x => x.Key == "name").FirstOrDefault().Value;
            Surname = collection.Where(x => x.Key == "surname").FirstOrDefault().Value;
            Login = collection.Where(x => x.Key == "login").FirstOrDefault().Value;
            isChecked = collection.Where(x => x.Key == "remember").FirstOrDefault().Value == "on";
        }
    }
}
