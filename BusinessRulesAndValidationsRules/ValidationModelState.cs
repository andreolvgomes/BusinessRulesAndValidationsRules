using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesAndValidationsRules
{
    public class ValidationModelState
    {
        public ValidationResult2 Valid(object value)
        {
            var result = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(value, null, null);

            // validation with dataannotations
            Validator.TryValidateObject(value, context, result, true);

            //if (resultadoValidacao.Count > 0)
            //    return BadRequest(resultadoValidacao);
            var errors = result.Select(s => new ValidaError()
            {
                Field = s.MemberNames.FirstOrDefault(),
                Message = s.ErrorMessage
            }).ToList();

            if (errors.Count > 0)
                return new ValidationResult2() { Message = "Validation errors in your request ", Errors = errors };

            return new ValidationResult2();
        }
    }

    public class ValidationResult2
    {
        public string Message { get; set; }
        public List<ValidaError> Errors { get; set; } = new List<ValidaError>();
    }

    public class ValidaError
    {
        public string Message { get; set; }
        public string Field { get; set; }
    }
}
