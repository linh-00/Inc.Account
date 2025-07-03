using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Accounts.Application.DTO.Response
{
    public record DocumentResponse
    {
        public Guid AccountId { get; init; }
        public string Name { get; init; }
        public string Number { get; init;}
        public string Type { get; init; }
        public string FileUrl { get; init; }
        public DateTime CreatedAt { get;  init; }
        public string CreatedBy { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public string? UpdatedBy { get; init; }
    }
}
