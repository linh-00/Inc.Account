using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Accounts.Domain.Entities
{
    public class Account : BaseEntities
    {
        public string NickName { get; private set; }
        public string FullName { get; private set; }
        public DateTime BirtDate { get; private set; }
        public char Gender { get; private set; }
        public bool IsVerify { get; private set; }
        public string ProfilePicture { get; private set; }

    public Account(Guid id, string fullName, DateTime birtDate, char gender, bool isVerify, string profilePicture) : base(id)
        {
            FullName = fullName;
            BirtDate = birtDate;
            Gender = gender;
            IsVerify = isVerify;
            ProfilePicture = profilePicture;
        }
    }
}
