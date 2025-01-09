using System.ComponentModel.DataAnnotations;

namespace ToDo_API.Model.Attributes
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is not DateTime dateValue)
                return true;

            return dateValue > DateTime.Now;
        }
    }
}
