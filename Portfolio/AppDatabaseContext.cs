using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

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
        public DbSet<TechnologyModel> Technologies { get; set; }
        public DbSet<LikeModel> Likes { get; set; }
    }
}
