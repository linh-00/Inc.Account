using Inc.Accounts.Application.DTO.Response;
using Inc.Accounts.Shared.Interfaces;

namespace Inc.Accounts.Application.Interfaces.Document
{
    public interface IGetByIdDocumentoUseCase : IUseCase<Guid, DocumentResponse>
    {
    }
}
