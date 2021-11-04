using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using Portfolio.Utils;
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

        public UserModel Get(int id)
        {
            return _ctx.Users.Find(id);
        }

        public List<UserModel> Get(int pageNumber = 1, int pageSize = 6)
        {
            return _ctx.Users.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public UserModel Get(string login)
        {
            return _ctx.Users.FirstOrDefault( u => u.Login == login);
        }
        
        public UserModel Get(string login, string password)
        {
            return _ctx.Users.FirstOrDefault( u => u.Login == login && u.Password == Hashing.GetHashString(password));
        }
        
        
        public async Task<UserModel> GetAsync(int id)
        {
            return await _ctx.Users.FindAsync(id);
        }

        public async Task<List<UserModel>> GetAsync(int pageNumber = 1, int pageSize = 6)
        {
            return await _ctx.Users.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<UserModel> GetAsync(string login)
        {
            return await _ctx.Users.FirstOrDefaultAsync( u => u.Login == login);
        }

        public async Task<UserModel> GetAsync(string login, string password)
        {
            return await _ctx.Users.FirstOrDefaultAsync( u => u.Login == login && u.Password == Hashing.GetHashString(password));
        }

        
        public UserModel GetIncludedRole(int id)
        {
            return _ctx.Users.Include(u => u.Role).FirstOrDefault(u => u.Id == id);
        }
        
        public UserModel GetIncludedRole(string login)
        {
            return _ctx.Users.Include(u => u.Role).FirstOrDefault( u => u.Login == login);
        }
        
        public UserModel GetIncludedRole(string login, string password)
        {
            return _ctx.Users.Include(u => u.Role).FirstOrDefault( u => u.Login == login && u.Password == Hashing.GetHashString(password));
        }
        
        
        public async Task<UserModel> GetIncludedRoleAsync(int id)
        {
            return await _ctx.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id);
        }
        
        public async Task<UserModel> GetIncludedRoleAsync(string login)
        {
            return await _ctx.Users.Include(u => u.Role).FirstOrDefaultAsync( u => u.Login == login);
        }
        
        public async Task<UserModel> GetIncludedRoleAsync(string login, string password)
        {
            return await _ctx.Users.Include(u => u.Role).FirstOrDefaultAsync( u => u.Login == login && u.Password == Hashing.GetHashString(password));
        }


        public async Task<List<UserModel>> GetByRoleId(int roleId)
        {
            RoleModel role = await _ctx.Roles.Include(r => r.Users).FirstOrDefaultAsync(r => r.Id == roleId);
            return role.Users;
        }

        public UserModel Add(string login, string password, RoleModel role)
        {
            UserModel user = new UserModel
            {
                Login = login,
                Password = Hashing.GetHashString(password),
                Role = role
            };
            _ctx.Users.Add(user);
            _ctx.SaveChanges();
            return user;
        }
        
        public async Task<UserModel> AddAsync(UserModel user)
        {
            _ctx.Users.Add(user);
            await _ctx.SaveChangesAsync();
            return user;
        }
    }
}
