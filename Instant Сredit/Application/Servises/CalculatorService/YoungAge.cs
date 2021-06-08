using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servises.CalculatorService
{
    public class YoungAge : ICalculator 
    {
        private int creditSum { get; set; }
        public YoungAge(int creditSum)
        {
            this.creditSum = creditSum;
        }
        public int Calculate()
        {
            if (creditSum < 1000000) return 12;
            else if (creditSum >= 1000000 && creditSum <= 3000000) return 9;
            else return 0;
        }
    }
}
