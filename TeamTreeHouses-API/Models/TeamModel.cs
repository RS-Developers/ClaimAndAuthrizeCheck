using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamTreeHouses_API.Models
{
    public class TeamModel : ModelBase
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(this.TeamName))
                yield return new ValidationResult("TeamName Is Null");
        }
    }
}