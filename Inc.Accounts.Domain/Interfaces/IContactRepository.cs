using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Accounts.Domain.Interfaces
{
    public interface IContactRepository
    {
        Task<Domain.Entities.Contact> Create(Domain.Entities.Contact request); 
        Task<Domain.Entities.Contact> GetById(Guid id);
        Task<IEnumerable<Domain.Entities.Contact>> GetAllByAcountId(Guid Id);
        Task<Domain.Entities.Contact> GetInfo(Guid id);
        Task<Domain.Entities.Contact> Update(Domain.Entities.Contact request); 
        Task<bool> Delete(Guid Id);
    }
}
