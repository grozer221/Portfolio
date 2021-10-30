﻿using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
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
        
        public async Task<RoleModel> GetRoleByUserLogin(string login)
        {
            var user = await _ctx.Users.Include(u => u.Role).FirstOrDefaultAsync(r => r.Login == login);
            return user.Role;
        }
    }
}
