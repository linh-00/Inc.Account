using Inc.Accounts.Application.DTO.Request;
using Inc.Accounts.Application.DTO.Response;
using Inc.Accounts.Shared.Interfaces;


namespace Inc.Accounts.Application.Interfaces.Contact
{
    public interface ICreateContactUseCase : IUseCase<ContactRequest, ContactResponse>
    {
    }
}
