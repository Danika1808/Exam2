using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validation
{
    public abstract class ValidationStrategy : IValidator
    {
        internal ICollection<Result> Results = new List<Result>();
        public abstract ValidationResult Validate();

        internal static bool IsRequired(object str)
        {
            if (str != null)
            {
                return string.IsNullOrEmpty(str.ToString());
            }
            return true;
        }

        internal ValidationResult GetResult()
        {
            return new ValidationResult(Results);
        }
    }
}
