using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Repositories
{
    public class CommentsRepository
    {
        private readonly AppDatabaseContext _ctx;
        private readonly UsersRepository _usersRep;
        private readonly ProjectsRepository _projectRep;
        public CommentsRepository(AppDatabaseContext ctx, UsersRepository usersRep, ProjectsRepository projectRep)
        {
            _ctx = ctx;
            _usersRep = usersRep;
            _projectRep = projectRep;
        }

        public async Task<CommentModel> GetByIdAsync(int id)
        {
            return await _ctx.Comments.FindAsync(id);
        }
        
        public List<CommentModel> GetByProjectId(int projectId)
        {
            return _ctx.Projects.Include(p => p.Comments).FirstOrDefault(p => p.Id == projectId).Comments;
        }
        
        public async Task<int> GetCommentsCount(int projectId)
        {
            return await _ctx.Comments.Where(k => k.Project.Id == projectId).CountAsync();
        }

        public async Task AddComment(string text, int projectId, string userLogin)
        {
            ProjectModel project = await _projectRep.GetProjectIncludedUsersCommentsByIdAsync(projectId);
            UserModel user = await _usersRep.GetByLoginAsync(userLogin);
            project.Comments.Add(new CommentModel
            {
                User = user,
                Text = text,
                DateCreate = DateTime.Now,
            });
            await _ctx.SaveChangesAsync();
        }
    }
}
