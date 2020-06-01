using System.ComponentModel.DataAnnotations;

namespace SmartMed.Models.Models.Validations
{
    public class GreaterThanZero : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            double i;
            return value != null && double.TryParse(value.ToString(), out i) && i > 0;
        }
    }
}
