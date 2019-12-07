using MilestoneProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Abstractions
{
    public interface IWeightCategoryRepo
    {
        void Add(WeightCategory weightCategory);
        void Update(WeightCategory weightCategory);
        void Delete(WeightCategory weightCategory);
        Task Save();
        Task<List<WeightCategory>> GetAll();
        Task<WeightCategory> GetDetail(int? id);
        bool Exist(int id);
        bool Exist(string name);
    }
}
