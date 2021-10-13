using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Repositories;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly AppDatabaseContext _ctx;
        private readonly ProjectsRepository _projectsRep;

        public ProjectsController(AppDatabaseContext context)
        {
            _ctx = context;
            _projectsRep = new ProjectsRepository(_ctx);
        }

        // GET: Admin/Projects
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 6;

            int count = await _projectsRep.GetCount();
            var items = await _projectsRep.GetProjects(page, pageSize);

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ProjectsIndexViewModel viewModel = new ProjectsIndexViewModel
            {
                Page = pageViewModel,
                Projects = items
            };
            return View(viewModel);
        }

        // GET: Admin/Projects/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var projectModel = await _projectsRep.GetProjectById(id);
            if (projectModel == null)
            {
                return NotFound();
            }
            return View(projectModel);
        }
    }
}
