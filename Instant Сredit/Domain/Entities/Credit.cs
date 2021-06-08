using Domain.Root;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Credit : Entity
    {
        public decimal Amount { get; private set; }
        public Credit()
        { }
        public Credit(decimal amount)
        {
            Amount = amount;
        }


    }
}
