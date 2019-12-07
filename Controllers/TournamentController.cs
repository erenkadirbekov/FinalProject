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
    public class TournamentController : Controller
    {
        private readonly TournamentService _tournamentService;

        public TournamentController(TournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        // GET: Tournament
        public async Task<IActionResult> Index()
        {
            var tournaments = await _tournamentService.GetAll();
            return View(tournaments);
        }

        // GET: Tournament/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournament = await _tournamentService.DetailsTournament(id);
            if (tournament == null)
            {
                return NotFound();
            }

            return View(tournament);
        }

        // GET: Tournament/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tournament/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tournamentId,name")] Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                await _tournamentService.AddAndSave(tournament);
                return RedirectToAction(nameof(Index));
            }
            return View(tournament);
        }

        // GET: Tournament/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournament = await _tournamentService.DetailsTournament(id);
            if (tournament == null)
            {
                return NotFound();
            }
            return View(tournament);
        }

        // POST: Tournament/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("tournamentId,name")] Tournament tournament)
        {
            if (id != tournament.tournamentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _tournamentService.Update(tournament);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TournamentExists(tournament.tournamentId))
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
            return View(tournament);
        }

        // GET: Tournament/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournament = await _tournamentService.DetailsTournament(id);
            if (tournament == null)
            {
                return NotFound();
            }

            return View(tournament);
        }

        // POST: Tournament/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tournament = await _tournamentService.DetailsTournament(id);
            await _tournamentService.Delete(tournament);
            return RedirectToAction(nameof(Index));
        }

        private bool TournamentExists(int id)
        {
            return _tournamentService.TournamentExist(id);
        }
    }
}
