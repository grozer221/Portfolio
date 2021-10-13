using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models.Projects;
using Portfolio.Repositories;
using Portfolio.ViewModels.Common;
using Portfolio.ViewModels.Projects;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
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
            IndexViewModel viewModel = new IndexViewModel
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

        // GET: Admin/Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectModel projectModel)
        {
            if (ModelState.IsValid)
            {
                await _projectsRep.AddProject(User.Identity.Name, projectModel);
                TempData["Success"] = "The project has been created";
                return RedirectToAction(nameof(Index));
            }
            return View(projectModel);
        }

        // GET: Admin/Projects/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var projectModel = await _projectsRep.GetProjectById(id);
            if (projectModel == null)
            {
                return NotFound();
            }
            return View(projectModel);
        }

        // POST: Admin/Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProjectModel projectModel)
        {
            if (id != projectModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _projectsRep.UpdateProject(projectModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _projectsRep.ProjectModelExists(projectModel.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(projectModel);
        }

        // GET: Admin/Projects/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var projectModel = await _projectsRep.GetProjectById(id);
            if (projectModel == null)
            {
                return NotFound();
            }

            return View(projectModel);
        }

        // POST: Admin/Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _projectsRep.DeleteProject(id);
            TempData["Success"] = "The project has been deleted";
            return RedirectToAction(nameof(Index));
        }
    }
}
