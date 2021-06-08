using Domain.Entities;
using Domain.Root;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.ValueObjects
{
    public class Passport : ValueObject
    {
        public string Series { get; private set; }
        public string Number { get; private set; }
        public string IssuedBy { get; private set; }
        public string SubdivisionCode { get; private set; }
        public DateTime DateOfIssue { get; private set; }
        public string Residency { get; private set; }
        public Passport() { }
        public Passport(string series, string number, string issuedBy, string subdivisionCode, DateTime dateOfIssue, string residency)
        {
            Series = series;
            Number = number;
            IssuedBy = issuedBy;
            SubdivisionCode = subdivisionCode;
            DateOfIssue = dateOfIssue;
            Residency = residency;
        }

        public void UpdateSeries(string series)
        {
            Series = series;
        }

        public void UpdateNumber(string number)
        {
            Number = number;
        }

        public void UpdateIssuedBy(string issuedBy)
        {
            IssuedBy = issuedBy;
        }

        public void UpdateSubdivisionCode(string subdivisionCode)
        {
            SubdivisionCode = subdivisionCode;
        }

        public void UpdateDate(DateTime dateOfIssue)
        {
            DateOfIssue = dateOfIssue;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Series;
            yield return Number;
        }
    }
}
