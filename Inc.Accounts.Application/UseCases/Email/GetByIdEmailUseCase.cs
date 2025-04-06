using AutoMapper;
using Inc.Accounts.Application.DTO.Response;
using Inc.Accounts.Application.Interfaces.Email;
using Inc.Accounts.Domain.Interfaces;
using Inc.Accounts.Shared.Constants;
using Inc.Accounts.Shared.Exceptions.Exceptions;
using Inc.Accounts.Shared.Models;
using Microsoft.Extensions.Logging;

namespace Inc.Accounts.Application.UseCases.Email
{
    public class GetByIdEmailUseCase : IGetByIdEmailUseCase
    {
        public readonly IEmailRepository _EmailRepository;
        public readonly ILogger<GetByIdEmailUseCase> _Logger;
        public readonly IMapper _Mapper;

        public GetByIdEmailUseCase(IEmailRepository emailRepository, ILogger<GetByIdEmailUseCase> logger, IMapper mapper)
        {
            _EmailRepository = emailRepository;
            _Logger = logger;
            _Mapper = mapper;
        }
        public async Task<UseCaseResponse<EmailResponse>> Execute(Guid request)
        {
            var result = new UseCaseResponse<EmailResponse>();

            try
            {
                var entity = await _EmailRepository.GetById(request);
                var mapper = _Mapper.Map<EmailResponse>(entity);

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
