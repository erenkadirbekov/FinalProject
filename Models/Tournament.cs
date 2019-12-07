using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneProject.Models
{
    public class Tournament : IValidatableObject
    {
        [Key]
        public int tournamentId { get; set; }
        [Required]
        public string name { get; set; }
        public ICollection<Fight> fights { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (fights.ToList().Count > 20)
            {
                yield return new ValidationResult(
                    "There cannot be more than 20 fights",
                    new[] { nameof(fights) });
            }
        }
    }
}
