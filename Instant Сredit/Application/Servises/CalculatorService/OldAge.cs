using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Entities.Borrower;

namespace Application.Servises.CalculatorService
{
    class OldAge : ICalculator
    {
        private Pledge pledge;

        public OldAge(Pledge pledge)
        {
            this.pledge = pledge;
        }
        public int Calculate()
        {
            if (pledge != Pledge.Without)
            {
                return 8;
            }

            return 0;
        }
    }
}
