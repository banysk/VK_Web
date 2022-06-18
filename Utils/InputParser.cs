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
    }
}
