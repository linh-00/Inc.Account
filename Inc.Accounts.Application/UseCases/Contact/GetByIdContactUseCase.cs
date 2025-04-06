using AutoMapper;
using Inc.Accounts.Application.DTO.Response;
using Inc.Accounts.Application.Interfaces.Contact;
using Inc.Accounts.Domain.Interfaces;
using Inc.Accounts.Shared.Constants;
using Inc.Accounts.Shared.Exceptions.Exceptions;
using Inc.Accounts.Shared.Models;
using Microsoft.Extensions.Logging;

namespace Inc.Accounts.Application.UseCases.Contact
{
    public class GetByIdContactUseCase : IGetByIdContactUseCase
    {
        public readonly IContactRepository _ContactRepository;
        public ILogger<GetByIdContactUseCase> _Logger;
        public readonly IMapper _Mapper;

        public GetByIdContactUseCase(IContactRepository contactRepository, ILogger<GetByIdContactUseCase> logger, IMapper mapper)
        {
            _ContactRepository = contactRepository;
            _Logger = logger;
            _Mapper = mapper;
        }

        public async Task<UseCaseResponse<ContactResponse>> Execute(Guid request)
        {
            var result = new UseCaseResponse<ContactResponse>();

            try
            {
                var entity = await _ContactRepository.GetById(request);
                var mapper = _Mapper.Map<ContactResponse>(entity);

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
