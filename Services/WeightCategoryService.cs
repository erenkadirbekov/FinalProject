using FinalProject.Abstractions;
using MilestoneProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Services
{
    public class WeightCategoryService
    {
        private readonly IWeightCategoryRepo _weightCategoryRepo;

        public WeightCategoryService(IWeightCategoryRepo weightCategoryRepo)
        {
            _weightCategoryRepo = weightCategoryRepo;
        }
        public async Task<List<WeightCategory>> GetAll()
        {
            return await _weightCategoryRepo.GetAll();
        }

        public async Task<WeightCategory> DetailsWeightCategory(int? id)
        {
            return await _weightCategoryRepo.GetDetail(id);
        }
        // For last method
        public bool WeightCategoryExist(int id)
        {
            return _weightCategoryRepo.Exist(id);
        }
        // POST: Roles/Create
        public async Task AddAndSave(WeightCategory weightCategory)
        {
            _weightCategoryRepo.Add(weightCategory);
            await _weightCategoryRepo.Save();
        }

        // POST: Roles/Edit/5
        public async Task Update(WeightCategory weightCategory)
        {
            _weightCategoryRepo.Update(weightCategory);
            await _weightCategoryRepo.Save();
        }

        // POST: Roles/Delete/5
        public async Task Delete(WeightCategory weightCategory)
        {
            _weightCategoryRepo.Delete(weightCategory);
            await _weightCategoryRepo.Save();
        }

        public bool WeightCategoryExist(string name) 
        {
            return _weightCategoryRepo.Exist(name);
        }
}
}
