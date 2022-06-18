using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Tech> Techs { get; set; }
    }
}