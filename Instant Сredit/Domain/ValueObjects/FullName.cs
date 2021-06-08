using Domain.Entities;
using Domain.Root;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class FullName : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        #nullable enable
        public string? MiddleName { get; private set; }
        #nullable disable
        public FullName() { }
        public FullName(string firstName, string lastName, string middleName)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            MiddleName = middleName;
        }

        public void UpdateFirstName(string firstName)
        {
            FirstName = firstName;
        }

        public void UpdateLastName(string lastName)
        {
            LastName = lastName;
        }

        public void UpdateMiddleName(string middleName)
        {
            MiddleName = middleName;
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
            yield return MiddleName;
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {MiddleName}";
        }
    }
}
