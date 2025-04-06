using AutoMapper;
using Inc.Accounts.Application.DTO.Request;
using Inc.Accounts.Application.DTO.Response;
using Inc.Accounts.Application.Interfaces.Contact;
using Inc.Accounts.Domain.Interfaces;
using Inc.Accounts.Shared.Models;
using Microsoft.Extensions.Logging;
using ContactDomain = Inc.Accounts.Domain.Entities.Contact;

namespace Inc.Accounts.Application.UseCases.Contact
{
    public class CreateContactUseCase : ICreateContactUseCase
    {
        public readonly IContactRepository _ContactRepository;
        public readonly IMapper _Mapper;
        public readonly ILogger<CreateContactUseCase> _Logger;

        public CreateContactUseCase(IContactRepository createRepository, IMapper mapper, ILogger<CreateContactUseCase> logger)
        {
            _ContactRepository = createRepository;
            _Mapper = mapper;
            _Logger = logger;
        }

        public async Task<UseCaseResponse<ContactResponse>> Execute(ContactRequest request)
        {
            var result = new UseCaseResponse<ContactResponse>();

            try
            {
                var domain = new ContactDomain(request.Type, request.Value, request.Isprimary, "");
                var entity = await _ContactRepository.Create(domain);
                var mapper = _Mapper.Map<ContactResponse>(entity);

                return result.SetSuccess(mapper);
            }

            catch(Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
