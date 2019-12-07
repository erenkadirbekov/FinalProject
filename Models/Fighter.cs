using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneProject.Models
{
    public class Fighter
    {
        [Key]
        public int FighterId { get; set; }
        [Required]
        public String name { get; set; }
        [Required]
        public int wins { get; set; }
        [Required]
        public int losts { get; set; }
        [Required]
        public int draws { get; set; }


        public int weightCategoryId { get; set; }
        public WeightCategory weightCategory { get; set; }
        public List<FightsAndFighters> fightsAndFighters { get; set; }
        public Belt belt { get; set; }

    }
}
