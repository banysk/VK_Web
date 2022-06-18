using Web.Models;

namespace Web.Database
{
    public class TechsHandler
    {
        private readonly ApplicationDbContext _dbContext;
        public TechsHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            if (_dbContext.Techs.Count() == 0)
            {
                foreach (Tech item in Tech.Default)
                {
                    _dbContext.Add(item);
                }
                _dbContext.SaveChanges();
            }
        }

        public List<Tech> GetAll()
        {
            return _dbContext.Techs.ToList();
        }
    }
}
