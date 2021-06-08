using Domain.Root;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Borrower : Entity
    {
        public int Age { get; private set; }
        public bool IsConvicted { get; private set; }
        public decimal CreditAmount { get; private set; }
        public Purpose CreditPurpose { get; private set; }
        public Employment GetEmployment { get; private set; }
        public Pledge GetPledge { get; private set; }
        public FullName FullName { get; set; }
        public Passport Passport { get; set; }

        private readonly HashSet<Credit> _credits;
        public IEnumerable<Credit> Credits => _credits?.ToList();

        public Borrower() { }
        public Borrower(Passport passport, FullName fullName, int age, bool isConvicted, decimal creditAmount, Purpose creditPurpose, Employment getEmployment, Pledge pledge)
        {
            Passport = passport ?? throw new ArgumentNullException(nameof(passport));
            FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
            Age = age;
            IsConvicted = isConvicted;
            CreditAmount = creditAmount;
            CreditPurpose = creditPurpose;
            GetEmployment = getEmployment;
            GetPledge = pledge;
        }

        public void UpdatePassport(Passport passport)
        {
            Passport = passport;
        }

        public void UpdateAge(int age)
        {
            Age = age;
        }

        public void UpdateIsConvicted(bool isConvicted)
        {
            IsConvicted = isConvicted;
        }

        public void UpdateCreditAmount(decimal creditAmount)
        {
            CreditAmount = creditAmount;
        }

        public void UpdateCreditPurpose(Purpose creditPurpose)
        {
            CreditPurpose = creditPurpose;
        }

        public void UpdateEmployment(Employment employment)
        {
            GetEmployment = employment;
        }

        public void AddCredit(Credit credit, DbContext context = null)
        {
            if (_credits != null)
            {
                _credits.Add(credit);
            }
            else if (credit == null)
            {
                throw new ArgumentNullException(nameof(context),
                    "You must provide a context if the Credit collection isn't valid.");
            }
            else if (context.Entry(this).IsKeySet)
            {
                context.Add(credit);
            }
            else
            {
                throw new InvalidOperationException("Could not add a new credit.");
            }    
        }

        public enum Employment
        {
            Unemployed,
            Pensioner,
            IndividualEntrepreneur,
            ContractOfEmployment,
            WithoutContractOfEmployment
        }

        public enum Purpose
        {
            Consumer,
            Realty,
            Relending
        }

        public enum Pledge
        {
            Without,
            Realty,
            Car,
            Surety
        }
    }
}
