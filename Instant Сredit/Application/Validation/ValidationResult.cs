using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Validation
{
    public class ValidationResult
    {
        private ICollection<Result> Results { get; }
        internal bool IsAccept { get; }
        internal ValidationResult(ICollection<Result> errors)
        {
            Results = errors;
        }

        internal ValidationResult(bool isAccept)
        {
            IsAccept = isAccept;
        }

        public ICollection<Result> GetResult()
        {
            return Results;
        }
    }
}