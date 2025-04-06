using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Accounts.Application.DTO.Request
{
    public record AccountRequest
    {
        public string NickName { get; init; }
        public string FullName { get; init; }
        public DateTime BirthDate { get; init; }
        public char? Gender { get; init; }
        public bool IsVerify { get; init; }
        public string ProfilePicture { get; init; }
    }
}
