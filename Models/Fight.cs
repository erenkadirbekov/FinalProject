using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneProject.Models
{
    public class Fight
    {
        [Key]
        public int FightId { get; set; }
        public List<FightsAndFighters> fightsAndFighters { get; set; }
        public int weightCategoryId { get; set; }
        public WeightCategory weightCategory { get; set; }
        
        public int tournamentId { get; set; }
        public Tournament tournament { get; set; }

        
    }
}
