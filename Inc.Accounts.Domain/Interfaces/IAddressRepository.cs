using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressDomain = Inc.Accounts.Domain.Entities.Address;

namespace Inc.Accounts.Domain.Interfaces
{
    public interface IAddressRepository
    {
        Task<AddressDomain> Create(AddressDomain request);
        Task<AddressDomain> GetById(Guid Id);
        Task<IEnumerable<AddressDomain>> GetAllByAcountId(Guid Id);
        Task<AddressDomain> GetInfo(Guid id);
        Task<AddressDomain> Update(AddressDomain request);
        Task<bool> Delete(Guid Id);
    }
}
