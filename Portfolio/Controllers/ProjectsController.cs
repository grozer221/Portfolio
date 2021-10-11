using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly AppDatabaseContext _ctx;

        public ProjectsController(AppDatabaseContext context)
        {
            _ctx = context;
        }

        // GET: Admin/Projects
        public async Task<IActionResult> Index()
        {
            return View(await _ctx.Projects.ToListAsync());
        }

        // GET: Admin/Projects/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var projectModel = await _ctx.Projects.FirstOrDefaultAsync(m => m.Id == id);
            if (projectModel == null)
            {
                return NotFound();
            }
            return View(projectModel);
        }
    }
}
