using Application.Validation;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class FullNameValidator : ValidationStrategy
    {
        private FullName FullName { get; }

        public FullNameValidator(FullName fullName)
        {
            FullName = fullName;
        }
        public override ValidationResult Validate()
        {
            if (IsRequired(FullName.FirstName))
            {
                Results.Add(new Result("Имя - обязательное поле для заполнения"));
            }

            if (IsRequired(FullName.LastName))
            {
                Results.Add(new Result("Фамилия - обязательное поле для заполения"));
            }

            return GetResult();

        }
    }
}
