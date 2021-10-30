using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Repositories
{
    public class UsersRepository
    {
        private readonly AppDatabaseContext _ctx;
        public UsersRepository(AppDatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<UserModel> GetUserIncludedRoleById(int id)
        {
            return await _ctx.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UserModel> GetUserByLogin(string login)
        {
            return await _ctx.Users.FirstOrDefaultAsync(u => u.Login == login);
        }

        public List<UserModel> GetUsersByRoleName(string roleName)
        {
            return _ctx.Roles.Include(r => r.Users).FirstOrDefault(r => r.RoleName == roleName).Users.ToList();
        }

        public async Task<UserModel> GetUserWithRoleByLogin(string login, string password)
        {
            return await _ctx.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
        }

        public async Task<UserModel> GetUserWithRoleByLogin(string login)
        {
            return await _ctx.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Login == login);
        }

        public async Task AddUser(UserModel user)
        {
            _ctx.Users.Add(user);
            await _ctx.SaveChangesAsync();
        }

        public async Task<List<UserModel>> GetUsersIncludedRoleAsync(int pageNumber = 1, int pageSize = 6)
        {
            return await _ctx.Users.Include(u => u.Role).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
