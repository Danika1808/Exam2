using Application;
using Application.Servises;
using Application.Validation;
using Application.Validators;
using Domain.Entities;
using Domain.ValueObjects;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantCredit
{
    public class CreditAssessor
    {
        private readonly AppDbContext _context;
        private Validator validator;
        private readonly OperatorService _operatorService;
        private readonly ConvictedService _convictedService;
        public CreditAssessor(AppDbContext context, Validator validator, OperatorService operatorService, ConvictedService convictedService)
        {
            _operatorService = operatorService;
            _context = context;
            this.validator = validator;
            _convictedService = convictedService;
        }

        public void Assess()
        {
            _operatorService.GetOperatorMessage();

            var fullName = GetFullName();

            var passport = GetPassport();

            var borrower = GetBorrower(fullName, passport);

        }

        private FullName GetFullName()
        {
            FullName fullName;
            List<Result> results;

            do
            {
                Console.WriteLine("Введите имя");
                var firstName = Console.ReadLine();
                Console.WriteLine("Введите фамилию");
                var secondName = Console.ReadLine();
                Console.WriteLine("Введите отчество (если имеется)");
                var middleName = Console.ReadLine();

                fullName = new FullName(firstName, secondName, middleName);

                results = validator.Validation(new FullNameValidator(fullName));

                foreach (var item in results)
                {
                    Console.WriteLine(item.Content);
                }
            }
            while (results.Count != 0);

            return fullName;
        }

        private Passport GetPassport()
        {
            Passport passport;
            List<Result> results;

            do
            {
                Console.WriteLine("Введите серию паспорта");
                var series = Console.ReadLine();
                Console.WriteLine("Введите номер паспорта");
                var number = Console.ReadLine();
                Console.WriteLine("Введите кем был выдан паспорт");
                var issuedBy = Console.ReadLine();
                Console.WriteLine("Введите код подразделения");
                var subdivisionCode = Console.ReadLine();
                Console.WriteLine("Введите дату выдачи");
                DateTime.TryParse(Console.ReadLine(), out DateTime dateTime);
                Console.WriteLine("Введите информацию о прописке");
                var Residency = Console.ReadLine();

                passport = new Passport(series, number, issuedBy, subdivisionCode, dateTime, Residency);

                results = validator.Validation(new PassportValidator(passport));

                foreach (var item in results)
                {
                    Console.WriteLine(item.Content);
                }
            }
            while (results.Count != 0);

            return passport;
        }

        private Borrower GetBorrower(FullName fullName, Passport passport)
        {
            Borrower borrower;
            List<Result> results;

            do
            {
                Console.WriteLine("Введите ваш возраст");
                int.TryParse(Console.ReadLine(), out int age);

                var convicted = _convictedService.IsConvicted(passport.Number, passport.Series);

                Console.WriteLine("Сумма кредита");
                decimal.TryParse(Console.ReadLine(), out decimal amount);

                Console.WriteLine("Выберите номер цели кредита");
                foreach (var item in Enum.GetValues(typeof(Borrower.Purpose)))
                {
                    Console.WriteLine($"{item} - {(int)item}");
                }
                int.TryParse(Console.ReadLine(), out int puproseNum);

                Console.WriteLine("Выберите номер вашей текущей занятости");
                foreach (var item in Enum.GetValues(typeof(Borrower.Employment)))
                {
                    Console.WriteLine($"{item} - {(int)item}");
                }
                int.TryParse(Console.ReadLine(), out int employmentNum);

                Console.WriteLine("Выберите вариант залога");
                foreach (var item in Enum.GetValues(typeof(Borrower.Pledge)))
                {
                    Console.WriteLine($"{item} - {(int)item}");
                }
                int.TryParse(Console.ReadLine(), out int pledgeNum);

                borrower = new Borrower(passport, fullName, age, convicted, amount, (Borrower.Purpose)puproseNum, (Borrower.Employment)employmentNum, (Borrower.Pledge)pledgeNum);

                results = validator.Validation(new BorrowerValidator(borrower));

                foreach (var item in results)
                {
                    Console.WriteLine(item.Content);
                }
        }
            while (results.Count != 0);

            return borrower;
        }
}
}
