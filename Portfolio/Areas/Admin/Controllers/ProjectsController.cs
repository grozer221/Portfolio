using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
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
            var projectModel = await _ctx.Projects
                .FirstOrDefaultAsync(m => m.Id == id);
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectModel projectModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _ctx.Users.Include(u => u.Projects).FirstOrDefaultAsync(u => u.Login == User.Identity.Name);
                user.Projects.Add(projectModel);
                await _ctx.SaveChangesAsync();
                TempData["Success"] = "The project has been created";
                return RedirectToAction(nameof(Index));
            }
            return View(projectModel);
        }

        // GET: Admin/Projects/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var projectModel = await _ctx.Projects.FindAsync(id);
            if (projectModel == null)
            {
                return NotFound();
            }
            return View(projectModel);
        }

        // POST: Admin/Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                    _ctx.Update(projectModel);
                    await _ctx.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectModelExists(projectModel.Id))
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
            var projectModel = await _ctx.Projects
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var projectModel = await _ctx.Projects.FindAsync(id);
            _ctx.Projects.Remove(projectModel);
            await _ctx.SaveChangesAsync();
            TempData["Success"] = "The project has been deleted";
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectModelExists(int id)
        {
            return _ctx.Projects.Any(e => e.Id == id);
        }
    }
}
