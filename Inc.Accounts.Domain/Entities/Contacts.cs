using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Accounts.Domain.Entities
{
    public class Contacts : BaseEntities
    {
        public Guid AccountId { get; private set; }
        public string Type { get; private set; }
        public string Value { get; private set; }
        public bool Isprimary { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime CreatedBy { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public string UpdatedBy { get; private set; }

        public Contacts(Guid id, Guid accountId, string type, string value, bool isprimary, DateTime createdAt, DateTime createdBy, DateTime updatedAt, string updatedBy): base(id)
        {
            AccountId = accountId;
            Type = type;
            Value = value;
            Isprimary = isprimary;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
        }
    }
         
}
