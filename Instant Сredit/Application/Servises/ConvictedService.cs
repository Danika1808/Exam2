using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servises
{
    public class ConvictedService : IConvictedService
    {
        public bool IsConvicted(string number, string serial)
        {
            if (number == "123456" && serial == "1234")
            {
                return true;
            }

            return false;
        }
    }
}
