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
    public class FightController : Controller
    {
        private readonly MyContext _context;

        public FightController(MyContext context) => _context = context;

        // GET: Fight
        public IActionResult Index()
        {
            var fights = _context.Fights
                .Include(f => f.weightCategory)
                .Include(f => f.tournament);
            return View(fights.ToListAsync());
        }

        // GET: Fight/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fight = _context.Fights
                .Include(f => f.tournament)
                .Include(f => f.weightCategory)
                .FirstOrDefaultAsync(m => m.FightId == id);
            if (fight == null)
            {
                return NotFound();
            }

            return View(fight);
        }

        // GET: Fight/Create
        public IActionResult Create()
        {
            ViewData["tournamentId"] = new SelectList(_context.Tournaments, "tournamentId", "name");
            ViewData["weightCategoryId"] = new SelectList(_context.WeightCategories, "WeightCategoryId", "name");
            return View();
        }

        // POST: Fight/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FightId,weightCategoryId,tournamentId")] Fight fight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["tournamentId"] = new SelectList(_context.Tournaments, "tournamentId", "name", fight.tournamentId);
            ViewData["weightCategoryId"] = new SelectList(_context.WeightCategories, "WeightCategoryId", "name", fight.weightCategoryId);
            return View(fight);
        }

        // GET: Fight/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fight = await _context.Fights.FindAsync(id);
            if (fight == null)
            {
                return NotFound();
            }
            ViewData["tournamentId"] = new SelectList(_context.Tournaments, "tournamentId", "name", fight.tournamentId);
            ViewData["weightCategoryId"] = new SelectList(_context.WeightCategories, "WeightCategoryId", "name", fight.weightCategoryId);
            return View(fight);
        }

        // POST: Fight/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FightId,weightCategoryId,tournamentId")] Fight fight)
        {
            if (id != fight.FightId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FightExists(fight.FightId))
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
            ViewData["tournamentId"] = new SelectList(_context.Tournaments, "tournamentId", "name", fight.tournamentId);
            ViewData["weightCategoryId"] = new SelectList(_context.WeightCategories, "WeightCategoryId", "name", fight.weightCategoryId);
            return View(fight);
        }

        // GET: Fight/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fight = await _context.Fights
                .Include(f => f.tournament)
                .Include(f => f.weightCategory)
                .FirstOrDefaultAsync(m => m.FightId == id);
            if (fight == null)
            {
                return NotFound();
            }

            return View(fight);
        }

        // POST: Fight/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fight = await _context.Fights.FindAsync(id);
            _context.Fights.Remove(fight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FightExists(int id)
        {
            return _context.Fights.Any(e => e.FightId == id);
        }
    }
}
