using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inc.Accounts.Application.DTO.Response;
using Inc.Accounts.Shared.Interfaces;

namespace Inc.Accounts.Application.Interfaces.Contact
{
    public interface IGetAllContactByAccountIdUseCase: IUseCase<Guid, IEnumerable<ContactResponse>>
    {
    }
}
