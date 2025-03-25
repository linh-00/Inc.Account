using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Accounts.Domain.Entities
{
    public class Document : BaseEntities
    {
		public Guid AccountId { get; private set; }
		public string Name { get; private set; }
		public string Number { get; private set; }
		public string Type { get; private set; }
		public string FileUrl { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public string? UpdatedBy { get; private set; }

        public Document(Guid id, Guid accountId, string name, string number, string type, string fileUrl, DateTime createdAt, string createdBy, DateTime? updatedAt, string? updatedBy): base (id)
        {
            AccountId = accountId;
            Name = name;
            Number = number;
            Type = type;
            FileUrl = fileUrl;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
        }
    } 

}
