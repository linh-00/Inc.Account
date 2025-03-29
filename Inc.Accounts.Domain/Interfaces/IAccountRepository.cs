using Inc.Accounts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Accounts.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> Create(Account request);
        Task<Account> GetById(Guid Id);
        Task<IEnumerable<Account>> GetAll();
        Task<Account> Update(Account request);
        Task<bool> Delete(Guid Id);
    }
}
