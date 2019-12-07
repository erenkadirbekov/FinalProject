using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneProject.Models
{
    public class FightsAndFighters
    {
        [Key]
        public int fightsAndFightersId { get; set; }
        public int fightId { get; set; }
        public Fight fight { get; set; }

        public int fighterId { get; set; }
        public Fighter fighter { get; set; }
    }
}
