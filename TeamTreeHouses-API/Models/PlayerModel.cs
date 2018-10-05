using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamTreeHouses_API.Models
{
    public class PlayerModel : ModelBase
    {
        public int TeamId { get; set; }
        public int PlayerId { get; set; }
        public string TeamName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(this.LastName))
                yield return new ValidationResult("LastName Is Null");
            if (string.IsNullOrWhiteSpace(this.FirstName))
                yield return new ValidationResult("FirstName Is Null");
        }
    }
}