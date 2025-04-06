using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Accounts.Application.DTO.Request
{
    public record DocumentRequest
    {
        public string Name { get; init; }
        public string Number { get; init; }
        public string Type { get;  init; }
        public string FileUrl { get;init; }
    }
}
