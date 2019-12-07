using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneProject.Models
{
    public class WeightCategory
    {
        [Key]
        public int WeightCategoryId { get; set; }
        [Required]
        [StringLength (70, ErrorMessage = "No more than 70 characters!")]
        [Remote(action: "VerifyName", controller: "WeightCategory")]
        public String name { get; set; }
        public ICollection<Fighter> fighters { get; set; }
        public ICollection<Fight> fights { get; set; }
        public ICollection<Belt> belts { get; set; }
    }
}
