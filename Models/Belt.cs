using FinalProject.Validation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneProject.Models
{
    public class Belt
    {
        [Key]
        public int beltId { get; set; }
        [Required]
        [BeltValidation]
        [Remote(action: "Create", controller: "BeltController")]
        public string type { get; set; }
        public int weightCategoryId { get; set; }
        public WeightCategory weightCategory { get; set; }
        public int fighterId { get; set; }
        public Fighter owner { get; set; }
    }
}
