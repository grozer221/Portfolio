using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Repositories
{
    public class ProjectsRepository
    {
        private readonly AppDatabaseContext _ctx;
        private readonly TechnologiesRepository _technologiesRep;
        public ProjectsRepository(AppDatabaseContext ctx)
        {
            _ctx = ctx;
            _technologiesRep = new TechnologiesRepository(_ctx);
        }

        public async Task<int> GetCount()
        {
            return await _ctx.Projects.CountAsync();
        }

        public async Task<List<ProjectModel>> GetProjects(int pageNumber, int pageSize)
        {
            return await _ctx.Projects.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        
        public async Task<List<ProjectModel>> GetProjectsIncludedTechnologiesAsync(int pageNumber, int pageSize)
        {
            return await _ctx.Projects.Include(p => p.Technologies).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<ProjectModel> GetProjectById(int id)
        {
            return await _ctx.Projects.FindAsync(id);
        }

        public async Task<ProjectModel> GetProjectIncludedTechnologiesByIdAsync(int id)
        {
            return await _ctx.Projects.Include(p => p.Technologies).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddProject(string userLogin, ProjectModel project)
        {
            UserModel user = await _ctx.Users.Include(u => u.Projects).ThenInclude(p => p.Technologies).FirstOrDefaultAsync(u => u.Login == userLogin);
            project.Technologies = await _technologiesRep.GetTechnologiesByIds(project.TechnologiesIds);
            user.Projects.Add(project);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateProject(ProjectModel project)
        {
            ProjectModel currentProject = await GetProjectIncludedTechnologiesByIdAsync(project.Id);
            if (currentProject.Technologies != null)
                currentProject.Technologies.Clear();
            currentProject.Name = project.Name;
            currentProject.SiteLink = project.SiteLink;
            currentProject.DesktopAppLink = project.DesktopAppLink;
            currentProject.AndroidAppLink = project.AndroidAppLink;
            currentProject.IOSAppLink = project.IOSAppLink;
            currentProject.Technologies = await _technologiesRep.GetTechnologiesByIds(project.TechnologiesIds);
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
