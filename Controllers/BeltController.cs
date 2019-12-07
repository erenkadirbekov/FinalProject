using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MilestoneProject.Data;
using MilestoneProject.Models;

namespace FinalProject.Controllers
{
    public class BeltController : Controller
    {
        private readonly MyContext _context;

        public BeltController(MyContext context)
        {
            _context = context;
        }

        // GET: Belt
        public async Task<IActionResult> Index()
        {
            var myContext = _context.Belts.Include(b => b.owner).Include(b => b.weightCategory);
            return View(await myContext.ToListAsync());
        }

        // GET: Belt/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var belt = await _context.Belts
                .Include(b => b.owner)
                .Include(b => b.weightCategory)
                .FirstOrDefaultAsync(m => m.beltId == id);
            if (belt == null)
            {
                return NotFound();
            }

            return View(belt);
        }

        // GET: Belt/Create
        public IActionResult Create()
        {
            ViewData["fighterId"] = new SelectList(_context.Fighters, "FighterId", "name");
            ViewData["weightCategoryId"] = new SelectList(_context.WeightCategories, "WeightCategoryId", "name");
            return View();
        }

        // POST: Belt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("beltId,type,weightCategoryId,fighterId")] Belt belt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(belt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["fighterId"] = new SelectList(_context.Fighters, "FighterId", "name", belt.fighterId);
            ViewData["weightCategoryId"] = new SelectList(_context.WeightCategories, "WeightCategoryId", "name", belt.weightCategoryId);
            return View(belt);
        }

        // GET: Belt/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var belt = await _context.Belts.FindAsync(id);
            if (belt == null)
            {
                return NotFound();
            }
            ViewData["fighterId"] = new SelectList(_context.Fighters, "FighterId", "name", belt.fighterId);
            ViewData["weightCategoryId"] = new SelectList(_context.WeightCategories, "WeightCategoryId", "name", belt.weightCategoryId);
            return View(belt);
        }

        // POST: Belt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("beltId,type,weightCategoryId,fighterId")] Belt belt)
        {
            if (id != belt.beltId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(belt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeltExists(belt.beltId))
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
            ViewData["fighterId"] = new SelectList(_context.Fighters, "FighterId", "name", belt.fighterId);
            ViewData["weightCategoryId"] = new SelectList(_context.WeightCategories, "WeightCategoryId", "name", belt.weightCategoryId);
            return View(belt);
        }

        // GET: Belt/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var belt = await _context.Belts
                .Include(b => b.owner)
                .Include(b => b.weightCategory)
                .FirstOrDefaultAsync(m => m.beltId == id);
            if (belt == null)
            {
                return NotFound();
            }

            return View(belt);
        }

        // POST: Belt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var belt = await _context.Belts.FindAsync(id);
            _context.Belts.Remove(belt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeltExists(int id)
        {
            return _context.Belts.Any(e => e.beltId == id);
        }
    }
}
