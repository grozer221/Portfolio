using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Repositories
{
    public class TechnologiesRepository
    {
        private readonly AppDatabaseContext _ctx;
        public TechnologiesRepository(AppDatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<TechnologyModel> GetByIdAsync(int id)
        {
            return await _ctx.Technologies.FindAsync(id);
        }
        
        public List<TechnologyModel> GetByProjectId(int projectId)
        {
            return _ctx.Projects.Include(p => p.Technologies).FirstOrDefault(p => p.Id == projectId).Technologies;
        }

        public async Task<int> GetCountAsync()
        {
            return await _ctx.Technologies.CountAsync();
        }

        public async Task<List<TechnologyModel>> GetTechnologiesAsync(int pageNumber, int pageSize)
        {
            return await _ctx.Technologies.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        
        public async Task<List<TechnologyModel>> GetTechnologiesAsync()
        {
            return await _ctx.Technologies.ToListAsync();
        }

        public async Task<TechnologyModel> GetTechnologyByIdAsync(int id)
        {
            return await _ctx.Technologies.FindAsync(id);
        }

        public async Task<List<TechnologyModel>> GetTechnologiesByProjectIdAsync(int id)
        {
            ProjectModel project = await _ctx.Projects.Include(p => p.Technologies).FirstOrDefaultAsync(p => p.Id == id);
            return project.Technologies.ToList();
        }

        public async Task AddTechnologyAsync(string userLogin, TechnologyModel technology)
        {
            var user = await _ctx.Users.Include(u => u.Technologies).FirstOrDefaultAsync(u => u.Login == userLogin);
            technology.DateCreate = DateTime.Now;
            technology.DateLastChange = DateTime.Now;
            user.Technologies.Add(technology);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateTechnologyAsync(TechnologyModel technology)
        {
            technology.DateLastChange = DateTime.Now;
            _ctx.Technologies.Update(technology);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteTechnologyAsync(int id)
        {
            TechnologyModel technology = await GetTechnologyByIdAsync(id);
            _ctx.Technologies.Remove(technology);
            await _ctx.SaveChangesAsync();
        }

        public Task<bool> IsTechnologyExistsAsync(int id)
        {
            return _ctx.Technologies.AnyAsync(e => e.Id == id);
        }

        public async Task<List<TechnologyModel>> GetTechnologiesByIds(int[] ids)
        {
            List<TechnologyModel> technologies = new List<TechnologyModel>();
            if(ids != null)
                foreach (int id in ids)
                {
                    TechnologyModel technology = await GetTechnologyByIdAsync(id);
                    technologies.Add(technology);
                }
            return technologies;
        }
    }
}
