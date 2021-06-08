using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servises
{
    class OperatorOption
    {
        public const string Block = "Operator";
        public string Name { get; set; }
        public string Phrase { get; set; }
    }
    public class OperatorService
    {
        private static OperatorOption _option { get; set; }

        public OperatorService(IConfiguration config)
        {
            _option = new OperatorOption();
            config.GetSection(OperatorOption.Block).Bind(_option);
        }

        public void GetOperatorMessage()
        {
            Console.WriteLine($"{_option.Name} : {_option.Phrase}");
        }
    }
}
