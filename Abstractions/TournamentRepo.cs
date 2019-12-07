using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MilestoneProject.Data;
using MilestoneProject.Models;

namespace FinalProject.Abstractions
{
    public class TournamentRepo : ITournamentRepo
    {
        readonly MyContext _context;
        public TournamentRepo(MyContext context)
        {
            _context = context;
        }
        public void Add(Tournament tournament)
        {
            _context.Add(tournament);
        }

        public void Delete(Tournament tournament)
        {
            _context.Remove(tournament);
        }

        public bool Exist(int id)
        {
            return _context.Tournaments.Any(t => t.tournamentId == id);
        }

        public Task<List<Tournament>> GetAll()
        {
            return _context.Tournaments.ToListAsync();
        }

        public Task<Tournament> GetDetail(int? id)
        {
            return _context.Tournaments.FirstOrDefaultAsync(t => t.tournamentId == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(Tournament tournament)
        {
            _context.Update(tournament);
        }
    }
}
