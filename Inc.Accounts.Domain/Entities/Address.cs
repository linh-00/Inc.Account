using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Inc.Accounts.Domain.Entities
{
    public class Address : BaseEntities
    {
        public Guid AccountId { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public bool IsPrimary { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public string UpdatedBy { get; private set; }

        public Address(Guid id,Guid accountId, string street, string number, string complement, string neighborhood, string city, string state, string country, string zipCode, bool isPrimary, DateTime createdAt, string createdBy, DateTime? updatedAt, string updatedBy) : base(id)
        {
            AccountId = accountId;
            Street = street;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            IsPrimary = isPrimary;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
        }

        public Address(string street, string number, string complement, string neighborhood, string city, string state, string country, string zipCode, bool isPrimary, string createdBy)
        {
            Street = street;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            IsPrimary = isPrimary;
            CreatedAt = DateTime.Now;
            CreatedBy = createdBy;
        }
        public void Update(string street, string number, string complement, string neighborhood, string city, string state, string country, string zipCode, bool isPrimary, string updatedBy)
        {
            Street = street;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            IsPrimary = isPrimary;
            UpdatedAt = DateTime.Now;
            UpdatedBy = updatedBy;
        }

    }
}
