using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Repositories
{
    public class LikesRepository
    {
        private readonly AppDatabaseContext _ctx;
        private readonly UsersRepository _usersRep;
        private readonly ProjectsRepository _projectRep;
        public LikesRepository(AppDatabaseContext ctx, UsersRepository usersRep, ProjectsRepository projectRep)
        {
            _ctx = ctx;
            _usersRep = usersRep;
            _projectRep = projectRep;
        }

        public async Task<LikeModel> GetByIdAsync(int id)
        {
            return await _ctx.Likes.FindAsync(id);
        }
        
        public List<LikeModel> GetByProjectId(int projectId)
        {
            return _ctx.Projects.Include(p => p.Likes).FirstOrDefault(p => p.Id == projectId).Likes;
        }
        
        public async Task<int> GetLikesCount(int projectId)
        {
            return await _ctx.Likes.Where(l => l.Project.Id == projectId).CountAsync();
        }
        
        public async Task<bool> IsLikedProjectByUser(int projectId, string userLogin)
        {
            LikeModel like = await _ctx.Likes.Include(l => l.User).Include(l => l.Project).FirstOrDefaultAsync(l => l.Project.Id == projectId && l.User.Login == userLogin);
            if (like != null)
                return true;
            else
                return false;
        }

        public async Task<bool> LikeProject(int projectId, string userLogin)
        {
            LikeModel like = await _ctx.Likes.Include(l => l.Project).Include(l => l.User).FirstOrDefaultAsync(l => l.Project.Id == projectId && l.User.Login == userLogin);
            if (like == null)
            {
                UserModel user = await _ctx.Users.Include(u => u.Likes).ThenInclude(l => l.Project).FirstOrDefaultAsync(u => u.Login == userLogin);
                ProjectModel project = await _projectRep.GetProjectById(projectId);
                LikeModel newLike = new LikeModel();
                newLike.DateCreate = DateTime.Now;
                newLike.Project = project;
                user.Likes.Add(newLike);
                await _ctx.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UnLikeProject(int projectId, string userLogin)
        {
            LikeModel like = await _ctx.Likes.FirstOrDefaultAsync(l => l.Project.Id == projectId && l.User.Login == userLogin);
            if (like != null)
            {
                _ctx.Likes.Remove(like);
                await _ctx.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
