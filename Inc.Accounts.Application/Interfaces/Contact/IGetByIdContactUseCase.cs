using Inc.Accounts.Application.DTO.Response;
using Inc.Accounts.Shared.Interfaces;

namespace Inc.Accounts.Application.Interfaces.Contact
{
    public interface IGetByIdContactUseCase : IUseCase<Guid, ContactResponse>
    {
    }
}
