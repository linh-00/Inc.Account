using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Accounts.Application.DTO.Response
{
    public record EmailResponse
    {
        public Guid AccountId { get; init; }
        public string AddressMail { get; init; }
        public bool? IsPrimary { get; init; }
        public bool IsVerified { get; init; }
        public DateTime CreatedAt { get; init; }
        public string CreatedBy { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public string? UpdatedBy { get; init; }
    }
}
