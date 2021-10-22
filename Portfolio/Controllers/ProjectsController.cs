using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Repositories;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly AppDatabaseContext _ctx;
        private readonly ProjectsRepository _projectsRep;
        private readonly LikesRepository _likesRep;

        public ProjectsController(AppDatabaseContext context)
        {
            _ctx = context;
            _projectsRep = new ProjectsRepository(_ctx);
            _likesRep = new LikesRepository(_ctx);
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
            ProjectModel project = await _projectsRep.GetProjectById(id);
            if (project == null)
                return NotFound();
            if (User.Identity.IsAuthenticated)
                ViewBag.IsLiked = await _likesRep.IsLikedProjectByUser(id, User.Identity.Name);
            ViewBag.LikesCount = await _likesRep.GetLikesCount(id);
            return View(project);
        }

        // POST: Admin/Projects/Like/5
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Like(int id)
        {
            if (await _likesRep.LikeProject(id, User.Identity.Name))
                return Ok();
            else
                return BadRequest();
        }

        // POST: Admin/Projects/UnLike/5
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UnLike(int id)
        {
            if (await _likesRep.UnLikeProject(id, User.Identity.Name))
                return Ok();
            else
                return BadRequest();
        }
    }
}
