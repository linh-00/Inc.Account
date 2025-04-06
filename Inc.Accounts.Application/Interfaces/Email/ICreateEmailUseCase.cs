using Inc.Accounts.Application.DTO.Request;
using Inc.Accounts.Application.DTO.Response;
using Inc.Accounts.Shared.Interfaces;

namespace Inc.Accounts.Application.Interfaces.Email
{
    public interface ICreateEmailUseCase : IUseCase<EmailRequest, EmailResponse>
    {
    }
}
