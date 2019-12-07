using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MilestoneProject.Data;
using MilestoneProject.Models;

namespace FinalProject.Controllers
{
    public class WeightCategoryController : Controller
    {
        private readonly WeightCategoryService _weightCategoryService;

        public WeightCategoryController(WeightCategoryService weightCategoryService) => _weightCategoryService = weightCategoryService;

        // GET: WeightCategory
        public async Task<IActionResult> Index()
        {
            var weightCategories = await _weightCategoryService.GetAll();
            return View(weightCategories);
        }

        // GET: WeightCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weightCategory = await _weightCategoryService.DetailsWeightCategory(id);
            if (weightCategory == null)
            {
                return NotFound();
            }

            return View(weightCategory);
        }

        // GET: WeightCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WeightCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WeightCategoryId,name")] WeightCategory weightCategory)
        {
            if (ModelState.IsValid)
            {
                await _weightCategoryService.AddAndSave(weightCategory);
                return RedirectToAction(nameof(Index));
            }
            return View(weightCategory);
        }

        // GET: WeightCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weightCategory = await _weightCategoryService.DetailsWeightCategory(id);
            if (weightCategory == null)
            {
                return NotFound();
            }
            return View(weightCategory);
        }

        // POST: WeightCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WeightCategoryId,name")] WeightCategory weightCategory)
        {
            if (id != weightCategory.WeightCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _weightCategoryService.Update(weightCategory);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeightCategoryExists(weightCategory.WeightCategoryId))
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
            return View(weightCategory);
        }

        // GET: WeightCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weightCategory = await _weightCategoryService.DetailsWeightCategory(id);
            if (weightCategory == null)
            {
                return NotFound();
            }

            return View(weightCategory);
        }

        // POST: WeightCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weightCategory = await _weightCategoryService.DetailsWeightCategory(id);
            await _weightCategoryService.Delete(weightCategory);
            return RedirectToAction(nameof(Index));
        }

        private bool WeightCategoryExists(int id)
        {
            return _weightCategoryService.WeightCategoryExist(id);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyName(string name)
        {
            if (!_weightCategoryService.WeightCategoryExist(name))
                return Json("$That name already exists in the system!");
            return Json(true);
        }
    }
}
