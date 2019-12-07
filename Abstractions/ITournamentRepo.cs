using MilestoneProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Abstractions
{
    public interface ITournamentRepo
    {
        void Add(Tournament weightCategory);
        void Update(Tournament weightCategory);
        void Delete(Tournament weightCategory);
        Task Save();
        Task<List<Tournament>> GetAll();
        Task<Tournament> GetDetail(int? id);
        bool Exist(int id);
    }
}
