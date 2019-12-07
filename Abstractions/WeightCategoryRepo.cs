using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MilestoneProject.Data;
using MilestoneProject.Models;

namespace FinalProject.Abstractions
{
    public class WeightCategoryRepo : IWeightCategoryRepo
    {
        readonly MyContext _context;
        public WeightCategoryRepo(MyContext context)
        {
            _context = context;
        }

        public void Add(WeightCategory weightCategory)
        {
            _context.Add(weightCategory);
        }

        public void Delete(WeightCategory weightCategory)
        {
            _context.Remove(weightCategory);
        }

        public bool Exist(int id)
        {
            return _context.WeightCategories.Any(w => w.WeightCategoryId == id);
        }

        public Task<List<WeightCategory>> GetAll()
        {
            return _context.WeightCategories.ToListAsync();
        }

        public Task<WeightCategory> GetDetail(int? id)
        {
            return _context.WeightCategories.FirstOrDefaultAsync(w => w.WeightCategoryId == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(WeightCategory weightCategory)
        {
            _context.Update(weightCategory);
        }
         
        public bool Exist(string name)
        {
            return _context.WeightCategories.Any(w => w.name == name);
        }
    }
}
