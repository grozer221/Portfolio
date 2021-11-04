using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using Portfolio.Repositories;
using Portfolio.ViewModels;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class TechnologiesController : Controller
    {
        private readonly TechnologiesRepository _technologiesRep;

        public TechnologiesController(TechnologiesRepository technologiesRep)
        {
            _technologiesRep = technologiesRep;
        }

        // GET: Admin/Technologies
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 6;

            int count = await _technologiesRep.GetCountAsync();
            List<TechnologyModel> technologies = await _technologiesRep.GetTechnologiesAsync(page, pageSize);

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            TechnologiesIndexViewModel viewModel = new TechnologiesIndexViewModel
            {
                Page = pageViewModel,
                Technologies = technologies
            };
            return View(viewModel);
        }

        // GET: Admin/Technologies/Details/5
        public async Task<IActionResult> Details(int id)
        {
            TechnologyModel technologyModel = await _technologiesRep.GetTechnologyByIdAsync(id);
            if (technologyModel == null)
            {
                return NotFound();
            }
            return View(technologyModel);
        }

        // GET: Admin/Technologies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Technologies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TechnologyModel technologyModel)
        {
            if (ModelState.IsValid)
            {
                await _technologiesRep.AddTechnologyAsync(User.Identity.Name, technologyModel);
                return RedirectToAction(nameof(Index));
            }
            return View(technologyModel);
        }

        // GET: Admin/Technologies/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            TechnologyModel technologyModel = await _technologiesRep.GetTechnologyByIdAsync(id);
            if (technologyModel == null)
            {
                return NotFound();
            }
            return View(technologyModel);
        }

        // POST: Admin/Technologies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TechnologyModel technologyModel)
        {
            if (id != technologyModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _technologiesRep.UpdateTechnologyAsync(technologyModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _technologiesRep.IsTechnologyExistsAsync(technologyModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(technologyModel);
        }

        // GET: Admin/Technologies/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            TechnologyModel technologyModel = await _technologiesRep.GetTechnologyByIdAsync(id);
            if (technologyModel == null)
            {
                return NotFound();
            }
            return View(technologyModel);
        }

        // POST: Admin/Technologies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _technologiesRep.DeleteTechnologyAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
