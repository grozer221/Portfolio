using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using Portfolio.Repositories;
using Portfolio.ViewModels;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProjectsController : Controller
    {
        private readonly AppDatabaseContext _ctx;
        private readonly ProjectsRepository _projectsRep;
        private readonly TechnologiesRepository _technologiesRep;
        private readonly LikesRepository _likesRep;
        private readonly CommentsRepository _commentsRep;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProjectsController(AppDatabaseContext context, IWebHostEnvironment webHostEnvironment)
        {
            _ctx = context;
            _projectsRep = new ProjectsRepository(_ctx);
            _technologiesRep = new TechnologiesRepository(_ctx);
            _likesRep = new LikesRepository(_ctx);
            _commentsRep = new CommentsRepository(_ctx);
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/Projects
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 6;

            int count = await _projectsRep.GetCount();
            List<ProjectModel> items = await _projectsRep.GetProjectsIncludedTechnologiesAsync(page, pageSize);

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
            ProjectModel projectModel = await _projectsRep.GetProjectIncludedTechnologiesLikesCommentsByIdAsync(id);
            if (projectModel == null)
            {
                return NotFound();
            }
            projectModel.ImageURL = Path.Combine("/media/projects", projectModel.ImageURL);
            ViewBag.IsLiked = await _likesRep.IsLikedProjectByUser(id, User.Identity.Name);
            ViewBag.LikesCount = await _likesRep.GetLikesCount(id);
            return View(projectModel);
        }

        // GET: Admin/Projects/Create
        public async Task<IActionResult> Create()
        {
            ProjectModel project = new ProjectModel();
            project.Technologies = await _technologiesRep.GetTechnologiesAsync();
            return View(project);
        }

        // POST: Admin/Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectModel projectModel)
        {
            if (ModelState.IsValid)
            {
                string imageName = "noimage.jpeg";
                if (projectModel.ImageUpload != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media\\projects");
                    imageName = Guid.NewGuid().ToString() + "_" + projectModel.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadDir, imageName);
                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                        await projectModel.ImageUpload.CopyToAsync(fs);
                }
                projectModel.ImageURL = imageName;
                await _projectsRep.AddProject(User.Identity.Name, projectModel);
                TempData["Success"] = "The project has been created";
                return RedirectToAction(nameof(Index));
            }
            return View(projectModel);
        }

        // GET: Admin/Projects/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ProjectModel projectModel = await _projectsRep.GetProjectById(id);
            if (projectModel == null)
                return NotFound();

            List<TechnologyModel> technologiesInProject = await _technologiesRep.GetTechnologiesByProjectIdAsync(id);
            List<TechnologyModel> allTechnologies = await _technologiesRep.GetTechnologiesAsync();
            List<SelectListItem> resultTechnologies = new List<SelectListItem>();
            foreach (var technologyFromAll in allTechnologies)
                 resultTechnologies.Add(new SelectListItem { Text = technologyFromAll.Name, Value = technologyFromAll.Id.ToString(), Selected = false });
            int i = 0;
            foreach (var technologyFromProject in technologiesInProject)
                if (resultTechnologies.Any(t => t.Value == technologyFromProject.Id.ToString()))
                    resultTechnologies[i++].Selected = true;

            ViewBag.Technologies = resultTechnologies;
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
                    if (projectModel.ImageUpload != null)
                    {
                        string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media\\projects");
                        string imageName = Guid.NewGuid().ToString() + "_" + projectModel.ImageUpload.FileName;
                        string filePath = Path.Combine(uploadDir, imageName);
                        using (FileStream fs = new FileStream(filePath, FileMode.Create))
                            await projectModel.ImageUpload.CopyToAsync(fs);
                        projectModel.ImageURL = imageName;
                    }
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
        
        // POST: Admin/Projects/Like/5
        [HttpPost]
        public async Task<IActionResult> Like(int id)
        {
            if (await _likesRep.LikeProject(id, User.Identity.Name))
                return Ok();
            else
                return BadRequest();
        }
        
        // POST: Admin/Projects/UnLike/5
        [HttpPost]
        public async Task<IActionResult> UnLike(int id)
        {
            if (await _likesRep.UnLikeProject(id, User.Identity.Name))
                return Ok();
            else
                return BadRequest();
        }

        // POST: Admin/Projects/AddComment/text/id
        [HttpPost]
        public async Task<ActionResult> AddComment(string text, int id)
        {
            await _commentsRep.AddComment(text, id, User.Identity.Name);
            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
