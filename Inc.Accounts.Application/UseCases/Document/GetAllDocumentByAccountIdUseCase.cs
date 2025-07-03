using AutoMapper;
using Inc.Accounts.Application.DTO.Response;
using Inc.Accounts.Application.Interfaces.Document;
using Inc.Accounts.Domain.Interfaces;
using Inc.Accounts.Shared.Constants;
using Inc.Accounts.Shared.Exceptions.Exceptions;
using Inc.Accounts.Shared.Models;
using Microsoft.Extensions.Logging;

namespace Inc.Accounts.Application.UseCases.Document
{
    public class GetAllDocumentByAccountIdUseCase : IGetAllDocumentByAccountIdUseCase
    {

        public readonly ILogger<GetAllDocumentByAccountIdUseCase> _Logger;
        public readonly IDocumentRepository _DocumentRepository;
        public readonly IMapper _Mapper;

        public GetAllDocumentByAccountIdUseCase(ILogger<GetAllDocumentByAccountIdUseCase> logger, IDocumentRepository documentRepository, IMapper mapper)
        {
            _Logger = logger;
            _DocumentRepository = documentRepository;
            _Mapper = mapper;
        }

        public async Task<UseCaseResponse<IEnumerable<DocumentResponse>>> Execute(Guid request)
        {
            var result = new UseCaseResponse<IEnumerable<DocumentResponse>>();

            try
            {
                var entity = await _DocumentRepository.GetAllByAcountId(request);
                var mapper = _Mapper.Map<IEnumerable<DocumentResponse>>(entity);

                return result.SetSuccess(mapper);
            }
            catch (RepositoryException ex)
            {
                return result.SetNotFound(new ErrorMessage(ErrorCodes.NotFoundError, ex.Message));
            }
            catch (Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
