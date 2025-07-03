using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Accounts.Domain.Entities
{
    public class Contact : BaseEntities
    {
        public Guid AccountId { get; private set; }
        public string Type { get; private set; }
        public string Value { get; private set; }
        public bool Isprimary { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public string? UpdatedBy { get; private set; }

        public Contact(Guid id, Guid accountId, string type, string value, bool isprimary, DateTime createdAt, string createdBy, DateTime? updatedAt, string? updatedBy): base(id)
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

        public Contact (string type, string value, bool isprimary, string createdBy) 
        {
            
            Type = type;
            Value = value;
            Isprimary = isprimary;
            CreatedAt = DateTime.Now;
            CreatedBy = createdBy;
        }

        public void Update(string type, string value, bool isprimary, string updatedBy)
        {
            Type = type;
            Value = value;
            Isprimary = isprimary;
            CreatedAt = DateTime.Now;
            UpdatedBy = updatedBy;
        }
    }
         
}
