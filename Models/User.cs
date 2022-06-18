using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; } = "1";

        /// <summary>
        /// Логин (почта)
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Известные технологии
        /// </summary>
        public string KnownTechs { get; set; } = string.Empty;

        /// <summary>
        /// Интересующие технологии
        /// </summary>
        public string InterestTechs { get; set; } = string.Empty;

        public string AboutMe { get; set; } = "Расскажите о себе:)";

        /// <summary>
        /// Хочет быть наставником
        /// </summary>
        public bool WannaMention { get; set; } = false;

        /// <summary>
        /// Хочет найти наставника
        /// </summary>
        public bool WannaBeMentioned { get; set; } = false;

        /// <summary>
        /// Время начала
        /// </summary>
        public DateTime StartTime { get; set; } = DateTime.Parse("10:00");

        /// <summary>
        /// Время окончания
        /// </summary>
        public DateTime EndTime { get; set; } = DateTime.Parse("19:00");
    }
}
