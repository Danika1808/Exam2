using Application.Validation;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class PassportValidator : ValidationStrategy
    {
        private Passport Passport { get; }

        public PassportValidator(Passport passport)
        {
            Passport = passport;
        }
        public override ValidationResult Validate()
        {
            if (IsRequired(Passport.Series))
            {
                Results.Add(new Result("Серия пасспорта - обязательное поле для заполнения"));
            }
            else if (!(Passport.Series.Length == 4 && int.TryParse(Passport.Series, out _)))
            {
                Results.Add(new Result("Серия пасспорта должна состоять из 4 цифр"));
            }

            if (IsRequired(Passport.Number))
            {
                Results.Add(new Result("Номер пасспорта - обязательное поле для заполнения"));
            }
            else if (!(Passport.Number.Length == 6 && int.TryParse(Passport.Number, out _)))
            {
                Results.Add(new Result("Номер пасспорта должна состоять из 6 цифр"));
            }

            if (IsRequired(Passport.IssuedBy))
            {
                Results.Add(new Result("Кем выдан - обязательное поле для заполнения"));
            }

            if (IsRequired(Passport.SubdivisionCode))
            {
                Results.Add(new Result("Код подразделения - обязательное поле для заполнения"));
            }
            else if (!Regex.IsMatch(Passport.SubdivisionCode, @"^\d{3}-\d{3}$"))
            {
                Results.Add(new Result("Код подразделения должен быть в формате 123-456"));
            }

            if (Passport.DateOfIssue == new DateTime())
            {
                Results.Add(new Result("Дата выдачи - обязательное поле для заполнения"));
            }

            if (IsRequired(Passport.Residency))
            {
                Results.Add(new Result("Информация о прописке - обязательное поле для заполнения"));
            }

            return GetResult();
        }
    }
}
