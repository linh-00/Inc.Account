using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Accounts.Domain.Entities
{
    public class Email : BaseEntities
    {
        public Guid AccountId { get; private set; }
        public string AddressMail { get; private set; }
        public bool? IsPrimary { get; private set; }
        public bool IsVerified { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public string? UpdatedBy { get; private set; }

        public Email(Guid id, Guid accountId, string addressMail, bool? isPrimary, bool isVerified, DateTime createdAt, string createdBy, DateTime? updatedAt, string? updatedBy) : base(id)
        {
            AccountId = accountId;
            AddressMail = addressMail;
            IsPrimary = isPrimary;
            IsVerified = isVerified;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
        }

        public void Create(string addressMail, bool? isPrimary, bool isVerified, string createdBy, DateTime? updatedAt)
        {

            AddressMail = addressMail;
            IsPrimary = isPrimary;
            IsVerified = isVerified;
            CreatedAt = DateTime.Now;
            CreatedBy = createdBy;
        }
    }
}
