using Inc.Accounts.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Accounts.Application.Interfaces.Address
{
    public interface IDeleteAddressUseCase : IUseCase<Guid, bool>
    {
    }
}
