using Inc.Accounts.Application.DTO.Response;
using Inc.Accounts.Shared.Interfaces;

namespace Inc.Accounts.Application.Interfaces.Email
{
    public interface IGetAllEmailByAccountIdUseCase : IUseCase<Guid, IEnumerable<EmailResponse>>
    {
    }
}
