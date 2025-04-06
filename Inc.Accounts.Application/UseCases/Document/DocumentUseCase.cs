using AutoMapper;
using Inc.Accounts.Application.DTO.Request;
using Inc.Accounts.Application.DTO.Response;
using Inc.Accounts.Application.Interfaces.Document;
using Inc.Accounts.Domain.Entities;
using Inc.Accounts.Domain.Interfaces;
using Inc.Accounts.Shared.Models;
using Microsoft.Extensions.Logging;
using DocumentDomain = Inc.Accounts.Domain.Entities.Document;

namespace Inc.Accounts.Application.UseCases.Document
{
    public class DocumentUseCase : IDocumentUseCase
    {
        public readonly IDocumentRepository _DocumentRepository;
        public readonly ILogger<DocumentUseCase> _Logger;
        public readonly IMapper _Mapper;

        public DocumentUseCase(IDocumentRepository documentRepository, ILogger<DocumentUseCase> logger, IMapper mapper)
        {
            _DocumentRepository = documentRepository;
            _Logger = logger;
            _Mapper = mapper;
        }

        public async Task<UseCaseResponse<DocumentResponse>> Execute(DocumentRequest request)
        {
            var result = new UseCaseResponse<DocumentResponse>();

            try
            {
                var domain = new DocumentDomain(request.Name, request.Number, request.Type, request.FileUrl, "");
                var entity = await _DocumentRepository.Create(domain);
                var mapper = _Mapper.Map<DocumentResponse>(entity);

                return result.SetSuccess(mapper);
            }
            catch(Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
