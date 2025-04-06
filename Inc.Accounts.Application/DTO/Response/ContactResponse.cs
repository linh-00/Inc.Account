using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Accounts.Application.DTO.Response
{
    public record ContactResponse
    {
        public Guid AccountId { get; private set; }
        public string Type { get; private set; }
        public string Value { get; private set; }
        public bool Isprimary { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public string? UpdatedBy { get; private set; }

    }
}
