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

        //public async Task<UserModel> GetUserIncludedRoleById(int id)
        //{
        //    return await _ctx.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id);
        //}
        
        
        public UserModel GetById(int id)
        {
            return _ctx.Users.Find(id);
        }

        public async Task<UserModel> GetByLoginIncludedRoleAsync(string login)
        {
            return await _ctx.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Login == login);
        }
        
        public async Task<UserModel> GetByLoginAsync(string login)
        {
            return await _ctx.Users.FirstOrDefaultAsync(u => u.Login == login);
        }

        public async Task<List<UserModel>> GetByRoleId(int roleId)
        {
            RoleModel role = await _ctx.Roles.Include(r => r.Users).FirstOrDefaultAsync(r => r.Id == roleId);
            return role.Users;
        }

        public UserModel GetUserWithRoleByLogin(string login, string password)
        {
            return _ctx.Users.Include(u => u.Role).FirstOrDefault(u => u.Login == login && u.Password == password);
        }

        public UserModel GetUserWithRoleByLogin(string login)
        {
            return _ctx.Users.Include(u => u.Role).FirstOrDefault(u => u.Login == login);
        }
        
        public async Task<UserModel> GetUserWithRoleByLoginAsync(string login)
        {
            return await _ctx.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Login == login);
        }

        public async Task AddUser(UserModel user)
        {
            _ctx.Users.Add(user);
            await _ctx.SaveChangesAsync();
        }

        //public async Task<List<UserModel>> GetUsersIncludedRoleAsync(int pageNumber = 1, int pageSize = 6)
        //{
        //    return await _ctx.Users.Include(u => u.Role).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        //}
        
        public List<UserModel> Get(int pageNumber = 1, int pageSize = 6)
        {
            return _ctx.Users.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
