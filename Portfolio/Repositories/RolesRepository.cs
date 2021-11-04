using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Repositories
{
    public class RolesRepository
    {
        private readonly AppDatabaseContext _ctx;
        public RolesRepository(AppDatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<RoleModel> GetByIdAsync(int id)
        {
            return await _ctx.Roles.FindAsync(id);
        }
        
        public RoleModel GetByUser(string login, string password)
        {
            return _ctx.Users.Include(u => u.Role).FirstOrDefault(u => u.Login == login && u.Password == password).Role;
        }

        public async Task<RoleModel> GetByUserIdAsync(int userId)
        {
            UserModel user = await _ctx.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == userId);
            return user.Role;
        }
        
        public RoleModel GetRoleByName(string name)
        {
            return _ctx.Roles.FirstOrDefault(r => r.RoleName == name);
        }
        
        public async Task<RoleModel> GetRoleByNameAsync(string name)
        {
            return await _ctx.Roles.FirstOrDefaultAsync(r => r.RoleName == name);
        }
        
        public async Task<RoleModel> GetRoleByUserLogin(string login)
        {
            var user = await _ctx.Users.Include(u => u.Role).FirstOrDefaultAsync(r => r.Login == login);
            return user.Role;
        }
    }
}
