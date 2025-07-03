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
    public class GetAllEmailByAccountIdUseCase : IGetAllEmailByAccountIdUseCase
    {
        public readonly ILogger<GetAllEmailByAccountIdUseCase> _Logger;
        public readonly IEmailRepository _EmailRepository;
        public readonly IMapper _Mapper;

        public GetAllEmailByAccountIdUseCase(ILogger<GetAllEmailByAccountIdUseCase> logger, IEmailRepository emailRepository, IMapper mapper)
        {
            _Logger = logger;
            _EmailRepository = emailRepository;
            _Mapper = mapper;
        }

        public async Task<UseCaseResponse<IEnumerable<EmailResponse>>> Execute(Guid request)
        {
            var result = new UseCaseResponse<IEnumerable<EmailResponse>>();
            try
            {
                var entity = await _EmailRepository.GetAllByAcountId(request);
                var mapper = _Mapper.Map<IEnumerable<EmailResponse>>(entity);

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
