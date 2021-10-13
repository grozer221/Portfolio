using Microsoft.EntityFrameworkCore;
using Portfolio.Models.Account;
using Portfolio.Models.Projects;

namespace Portfolio
{
    public class AppDatabaseContext : DbContext
    {
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
    }
}
