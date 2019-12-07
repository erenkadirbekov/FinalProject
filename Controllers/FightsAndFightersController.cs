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
    public class FightsAndFightersController : Controller
    {
        private readonly MyContext _context;

        public FightsAndFightersController(MyContext context)
        {
            _context = context;
        }

        // GET: FightsAndFighters
        public async Task<IActionResult> Index()
        {
            var myContext = _context.Fights_And_Fighters.Include(f => f.fight).Include(f => f.fighter);
            return View(await myContext.ToListAsync());
        }

        // GET: FightsAndFighters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fightsAndFighters = await _context.Fights_And_Fighters
                .Include(f => f.fight)
                .Include(f => f.fighter)
                .FirstOrDefaultAsync(m => m.fightsAndFightersId == id);
            if (fightsAndFighters == null)
            {
                return NotFound();
            }

            return View(fightsAndFighters);
        }

        // GET: FightsAndFighters/Create
        public IActionResult Create()
        {
            ViewData["fightId"] = new SelectList(_context.Fights, "FightId", "FightId");
            ViewData["fighterId"] = new SelectList(_context.Fighters, "FighterId", "name");
            return View();
        }

        // POST: FightsAndFighters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("fightsAndFightersId,fightId,fighterId")] FightsAndFighters fightsAndFighters)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fightsAndFighters);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["fightId"] = new SelectList(_context.Fights, "FightId", "FightId", fightsAndFighters.fightId);
            ViewData["fighterId"] = new SelectList(_context.Fighters, "FighterId", "name", fightsAndFighters.fighterId);
            return View(fightsAndFighters);
        }

        // GET: FightsAndFighters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fightsAndFighters = await _context.Fights_And_Fighters.FindAsync(id);
            if (fightsAndFighters == null)
            {
                return NotFound();
            }
            ViewData["fightId"] = new SelectList(_context.Fights, "FightId", "FightId", fightsAndFighters.fightId);
            ViewData["fighterId"] = new SelectList(_context.Fighters, "FighterId", "name", fightsAndFighters.fighterId);
            return View(fightsAndFighters);
        }

        // POST: FightsAndFighters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("fightsAndFightersId,fightId,fighterId")] FightsAndFighters fightsAndFighters)
        {
            if (id != fightsAndFighters.fightsAndFightersId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fightsAndFighters);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FightsAndFightersExists(fightsAndFighters.fightsAndFightersId))
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
            ViewData["fightId"] = new SelectList(_context.Fights, "FightId", "FightId", fightsAndFighters.fightId);
            ViewData["fighterId"] = new SelectList(_context.Fighters, "FighterId", "name", fightsAndFighters.fighterId);
            return View(fightsAndFighters);
        }

        // GET: FightsAndFighters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fightsAndFighters = await _context.Fights_And_Fighters
                .Include(f => f.fight)
                .Include(f => f.fighter)
                .FirstOrDefaultAsync(m => m.fightsAndFightersId == id);
            if (fightsAndFighters == null)
            {
                return NotFound();
            }

            return View(fightsAndFighters);
        }

        // POST: FightsAndFighters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fightsAndFighters = await _context.Fights_And_Fighters.FindAsync(id);
            _context.Fights_And_Fighters.Remove(fightsAndFighters);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FightsAndFightersExists(int id)
        {
            return _context.Fights_And_Fighters.Any(e => e.fightsAndFightersId == id);
        }
    }
}
