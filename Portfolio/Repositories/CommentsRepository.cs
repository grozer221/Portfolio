using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Repositories
{
    public class CommentsRepository
    {
        private readonly AppDatabaseContext _ctx;
        private readonly UsersRepository _usersRep;
        private readonly ProjectsRepository _projectRep;
        public CommentsRepository(AppDatabaseContext ctx)
        {
            _ctx = ctx;
            _usersRep = new UsersRepository(_ctx);
            _projectRep = new ProjectsRepository(_ctx);
        }

        public async Task<int> GetCommentsCount(int projectId)
        {
            return await _ctx.Comments.Where(k => k.Project.Id == projectId).CountAsync();
        }

        public async Task AddComment(string text, int projectId, string userLogin)
        {
            ProjectModel project = await _projectRep.GetProjectIncludedUsersCommentsByIdAsync(projectId);
            UserModel user = await _usersRep.GetUserByLogin(userLogin);
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
