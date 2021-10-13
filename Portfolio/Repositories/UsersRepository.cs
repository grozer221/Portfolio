using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
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

        public async Task<UserModel> GetUserById(int id)
        {
            return await _ctx.Users.FindAsync(id);
        }
        
        public async Task<UserModel> GetUserByLogin(string login)
        {
            return await _ctx.Users.FirstOrDefaultAsync(u => u.Login == login);
        }
        
        public async Task<UserModel> GetUserWithRole(string login, string password)
        {
            return await _ctx.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
        }
        
        public async Task AddUser(UserModel user)
        {
            _ctx.Users.Add(user);
            await _ctx.SaveChangesAsync();
        }
    }
}
