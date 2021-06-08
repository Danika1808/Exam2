using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servises.CalculatorService
{
    class WithoutConvicted : ICalculator
    {
        public int Calculate()
        {
            return 15;
        }
    }
}
