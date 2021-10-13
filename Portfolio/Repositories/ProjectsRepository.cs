using Microsoft.EntityFrameworkCore;
using Portfolio.Models.Projects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Repositories
{
    public class ProjectsRepository
    {
        private readonly AppDatabaseContext _ctx;
        public ProjectsRepository(AppDatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<int> GetCount()
        {
            return await _ctx.Projects.CountAsync();
        }

        public async Task<IEnumerable<ProjectModel>> GetProjects(int pageNumber, int pageSize)
        {
            return await _ctx.Projects.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<ProjectModel> GetProjectById(int id)
        {
            return await _ctx.Projects.FindAsync(id);
        }

        public async Task AddProject(string userLogin, ProjectModel project)
        {
            var user = await _ctx.Users.Include(u => u.Projects).FirstOrDefaultAsync(u => u.Login == userLogin);
            user.Projects.Add(project);
            await _ctx.SaveChangesAsync();
        }
        
        public async Task UpdateProject(ProjectModel project)
        {
            _ctx.Update(project);
            await _ctx.SaveChangesAsync();
        }
        
        public async Task DeleteProject(int id)
        {
            var projectModel = await GetProjectById(id);
            _ctx.Projects.Remove(projectModel);
            await _ctx.SaveChangesAsync();
        }

        public Task<bool> ProjectModelExists(int id)
        {
            return _ctx.Projects.AnyAsync(e => e.Id == id);
        }
    }
}
