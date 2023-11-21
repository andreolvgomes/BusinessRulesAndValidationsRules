using System.ComponentModel.DataAnnotations;

namespace BusinessRulesAndValidationsRules
{
    public class MinValue : ValidationAttribute
    {
        public bool AllowNullable { get; set; }
        public int Minimum { get; set; }

        public MinValue(int value)
        {
            this.Minimum = value;
        }

        public override bool IsValid(object? value)
        {
            if (!AllowNullable && value is null)
                return false;

            else if (value is null)
                return true;

            return ((int)value >= Minimum);
        }
    }
}
