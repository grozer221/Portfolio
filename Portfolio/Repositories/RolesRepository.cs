using Microsoft.EntityFrameworkCore;
using Portfolio.Models.Account;
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

        public async Task<RoleModel> GetRoleByName(string name)
        {
            return await _ctx.Roles.FirstOrDefaultAsync(r => r.RoleName == name);
        }
    }
}
