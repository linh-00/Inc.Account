using Inc.Accounts.Application.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Accounts.Application.DTO.Response
{
    public record AccountResponse
    {
        public string NickName { get; init; }
        public string FullName { get; init; }
        public DateTime BirthDate { get; init; }
        public char? Gender { get; init; }
        public bool IsVerify { get; init; }
        public string ProfilePicture { get; init; }
        public IEnumerable<AddressRequest> Addresses { get; init; }
        public IEnumerable<ContactRequest> Contacts { get; init; }
        public IEnumerable<DocumentRequest> Documents { get; init; }
        public IEnumerable<EmailRequest> Emails { get; init; }
    }
}
