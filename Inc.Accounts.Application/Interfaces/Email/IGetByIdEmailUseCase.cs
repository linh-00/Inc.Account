using Inc.Accounts.Application.DTO.Response;
using Inc.Accounts.Shared.Interfaces;

namespace Inc.Accounts.Application.Interfaces.Email
{
    public interface IGetByIdEmailUseCase : IUseCase<Guid, EmailResponse>
    {
    }
}
