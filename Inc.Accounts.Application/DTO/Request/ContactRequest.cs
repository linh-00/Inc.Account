using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Accounts.Application.DTO.Request
{
    public record ContactRequest
    {
        public string Type { get; init; }
        public string Value { get; init; }
        public bool Isprimary { get; init; }
    }
}
