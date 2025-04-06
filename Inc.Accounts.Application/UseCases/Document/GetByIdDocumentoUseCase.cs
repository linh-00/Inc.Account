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
    public class GetByIdDocumentoUseCase : IGetByIdDocumentoUseCase
    {
        public readonly IDocumentRepository _DocumentRepository;
        public readonly IMapper _Mapper;
        public readonly ILogger<GetByIdDocumentoUseCase> _Logger;

        public GetByIdDocumentoUseCase(IDocumentRepository documentUseCase, IMapper mapper, ILogger<GetByIdDocumentoUseCase> logger)
        {
            _DocumentRepository = documentUseCase;
            _Mapper = mapper;
            _Logger = logger;
        }
        public async Task<UseCaseResponse<DocumentResponse>> Execute(Guid request)
        {
            var result = new UseCaseResponse<DocumentResponse>();

            try
            {
                var entity = await _DocumentRepository.GetById(request);
                var mapper = _Mapper.Map<DocumentResponse>(entity);

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
