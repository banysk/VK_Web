using Web.Models;

namespace Web.Database
{
    public class UsersHandler
    {
        private readonly ApplicationDbContext _dbContext;
        public UsersHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Registrate(RegistrationModel data)
        {
            if (_dbContext.Users.Where(x => x.Login == data.Login).Count() == 0)
            {
                User user = new User()
                {
                    Name = data.Name,
                    Surname = data.Surname,
                    Login = data.Login
                };
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Login(LoginModel data)
        {
            return _dbContext.Users.Where(x => x.Login == data.Login && x.Password == data.Password).Count() == 1;
        }

        public User getUser(string login)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Login == login);

            return user != null
                ? user
                : new User();
        }
    }
}
