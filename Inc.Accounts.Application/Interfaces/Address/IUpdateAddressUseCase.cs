using Inc.Accounts.Application.DTO.Request;
using Inc.Accounts.Application.DTO.Response;
using Inc.Accounts.Shared.Interfaces;

namespace Inc.Accounts.Application.Interfaces.Address
{
    public interface IUpdateAddressUseCase : IUseCase<AddressRequest, AddressResponse>
    {
    }
}
