using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TeamTreeHouses_API.Models
{
    public abstract class ModelBase : IValidatableObject
    {
        //[Required]
        //public bool? IsValid
        //{
        //    get
        //    {
        //        var lValidateResult = Validate(new ValidationContext(this));
        //        if (lValidateResult == null ||
        //            lValidateResult.Count() == 0)
        //            return true;
        //        //
        //        return null;
        //    }
        //    set { }
        //}

        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
}