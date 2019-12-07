using FinalProject.Abstractions;
using MilestoneProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Services
{
    public class TournamentService
    {
        private readonly ITournamentRepo _tournamentRepo;

        public TournamentService(ITournamentRepo tournamentRepo)
        {
            _tournamentRepo = tournamentRepo;
        }

        public async Task<List<Tournament>> GetAll()
        {
            return await _tournamentRepo.GetAll();
        }

        public async Task<Tournament> DetailsTournament(int? id)
        {
            return await _tournamentRepo.GetDetail(id);
        }
        
        public bool TournamentExist(int id)
        {
            return _tournamentRepo.Exist(id);
        }
        
        public async Task AddAndSave(Tournament tournament)
        {
            _tournamentRepo.Add(tournament);
            await _tournamentRepo.Save();
        }

        
        public async Task Update(Tournament tournament)
        {
            _tournamentRepo.Update(tournament);
            await _tournamentRepo.Save();
        }

        public async Task Delete(Tournament tournament)
        {
            _tournamentRepo.Delete(tournament);
            await _tournamentRepo.Save();
        }
    }
}
