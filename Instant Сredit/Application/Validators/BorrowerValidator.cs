using Application.Validation;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class BorrowerValidator : ValidationStrategy
    {
        private Borrower Borrower { get; }
        
        public BorrowerValidator(Borrower borrower)
        {
            Borrower = borrower;
        }
        public override ValidationResult Validate()
        {
            if (Borrower.Age == default)
            {
                Results.Add(new Result("Возраст - обязательное поле для заполнения"));
            }
            else if (Borrower.Age < 21)
            {
                Results.Add(new Result("Чтобы получить кредит вы должны быть не младше 21 лет"));
            }

            if (IsRequired(Borrower.IsConvicted))
            {
                Results.Add(new Result("Судимость - обязательное поле для заполнения"));
            }

            if (Borrower.CreditAmount == default)
            {
                Results.Add(new Result("Сумма кредита - обязательное поле для заполнения"));
            }

            if (IsRequired(Borrower.CreditPurpose))
            {
                Results.Add(new Result("Цель кредита - обязательное поле для заполнения"));
            }

            if (IsRequired(Borrower.GetEmployment))
            {
                Results.Add(new Result("Занятость - обязательное поле для заполнения"));
            }

            return GetResult();
        }
    }
}
