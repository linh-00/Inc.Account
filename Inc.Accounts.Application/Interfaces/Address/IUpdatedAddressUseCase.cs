using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inc.Accounts.Application.DTO.Request;
using Inc.Accounts.Application.DTO.Response;
using Inc.Accounts.Shared.Interfaces;

namespace Inc.Accounts.Application.Interfaces.Address
{
    public interface IUpdatedAddressUseCase : IUseCase<UpdatedAddressRequest, AddressResponse>
    {
    }
}
