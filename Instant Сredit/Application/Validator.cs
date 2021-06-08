using Application.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Validator
    {
        private ValidationStrategy ValidationStrategy;

        public List<Result> Validation(ValidationStrategy validationStrategy)
        {
             ValidationStrategy = validationStrategy;

            return ValidationStrategy.Validate().GetResult().ToList();
        }
    }
}
