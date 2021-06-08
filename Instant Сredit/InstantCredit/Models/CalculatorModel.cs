using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantCredit.Models
{
    class CalculatorModel
    {
        public CalculatorModel(Borrower.Employment employment, Borrower.Pledge pledge, Borrower.Purpose purpose, int age, bool isConvicted)
        {
            Employment = employment;
            Pledge = pledge;
            Purpose = purpose;
            Age = age;
            this.isConvicted = isConvicted;
        }

        public Borrower.Employment Employment { get; private set; }
        public Borrower.Pledge Pledge { get; private set; }
        public Borrower.Purpose Purpose { get; private set; }
        public int Age { get; private set; }
        public bool isConvicted { get; private set; }

    }
}
