using Web.Models;

namespace Web.Utils
{
    public class InputParser
    {
        public static LoginModel ParseLoginCollection(IFormCollection collection)
        {
            return new LoginModel(collection);
        }

        public static RegistrationModel ParseRegistrationCollection(IFormCollection collection)
        {
            return new RegistrationModel(collection);
        }

        public static User ParseUserCollection(IFormCollection collection)
        {
            string knownTechs = string.Empty;
            string interestTechs = string.Empty;

            for (int i = 1; i < 23; i++)
            {
                if (collection.Where(x => x.Key == $"known_tech{i}").FirstOrDefault().Value == "on")
                    knownTechs += $"{i},";

                if (collection.Where(x => x.Key == $"wanna_tech{i}").FirstOrDefault().Value == "on")
                    interestTechs += $"{i},";
            }

            var user = new User()
            {
                Name = collection.Where(x => x.Key == "name").FirstOrDefault().Value,
                Surname = collection.Where(x => x.Key == "surname").FirstOrDefault().Value,
                Login = collection.Where(x => x.Key == "login").FirstOrDefault().Value,
                KnownTechs = knownTechs,
                InterestTechs = interestTechs,
                AboutMe = collection.Where(x => x.Key == "aboutMe").FirstOrDefault().Value,
                WannaMention = collection.Where(x => x.Key == "wannaMention").FirstOrDefault().Value == "on",
                WannaBeMentioned = collection.Where(x => x.Key == "wannaBeMentioned").FirstOrDefault().Value == "on"
            };

            return user;
        }
    }
}
