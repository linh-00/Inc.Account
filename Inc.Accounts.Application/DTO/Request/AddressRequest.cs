using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Accounts.Application.DTO.Request
{
    public record AddressRequest
    {
        public string Street { get; init; }
        public string Number { get; init; }
        public string Complement { get; init; }
        public string Neighborhood { get; init; }
        public string City { get; init; }
        public string State { get; init; }
        public string Country { get; init; }
        public string ZipCode { get; init; }
        public bool IsPrimary { get; init; }
       
    }
}
