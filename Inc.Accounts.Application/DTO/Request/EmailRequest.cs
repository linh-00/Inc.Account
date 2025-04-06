using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Accounts.Application.DTO.Request
{
    public record EmailRequest
    {
        public string AddressMail { get; init; }
        public bool? IsPrimary { get; init; }
        public bool IsVerified { get; init; }
    }
}
