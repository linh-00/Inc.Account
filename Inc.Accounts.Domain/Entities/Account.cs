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
        public DateTime BirthDate { get; private set; }
        public char? Gender { get; private set; }
        public bool IsVerify { get; private set; }
        public string ProfilePicture { get; private set; }
        public IEnumerable<Address> Addresses { get; private set; }
        public IEnumerable<Contact> Contacts { get; private set; }
        public IEnumerable<Document> Documents { get; private set; }
        public IEnumerable<Email> Emails { get; private set; }

        public Account(Guid id, string fullName, DateTime birthDate, char? gender, bool isVerify, string profilePicture) : base(id)
        {
            FullName = fullName;
            BirthDate = birthDate;
            Gender = gender;
            IsVerify = isVerify;
            ProfilePicture = profilePicture;            
        }
        public Account(Guid id, string fullName, DateTime birtDate, char? gender, bool isVerify, string profilePicture, IEnumerable<Email> emails, IEnumerable<Address> addresses, IEnumerable<Contact> contacts, IEnumerable<Document> documents) : base(id)
        {
            FullName = fullName;
            BirthDate = birtDate;
            Gender = gender;
            IsVerify = isVerify;
            ProfilePicture = profilePicture;
            Emails = emails;
            Addresses = addresses;
            Contacts = contacts;
            Documents = documents;

        }

    }
}
