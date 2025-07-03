using AutoMapper;
using Inc.Accounts.Application.DTO.Request;
using Inc.Accounts.Application.DTO.Response;
using Inc.Accounts.Application.Interfaces.Email;
using Inc.Accounts.Domain.Interfaces;
using Inc.Accounts.Shared.Models;
using Microsoft.Extensions.Logging;
using EmailDomain = Inc.Accounts.Domain.Entities.Email;

namespace Inc.Accounts.Application.UseCases.Email
{
    public class CreateEmailUseCase : ICreateEmailUseCase
    {
        public readonly IEmailRepository _EmailRepository;
        public readonly ILogger<CreateEmailUseCase> _Logger;
        public readonly IMapper _Mapper;

        public CreateEmailUseCase(IEmailRepository emailRepository, ILogger<CreateEmailUseCase> logger, IMapper mapper)
        {
            _EmailRepository = emailRepository;
            _Logger = logger;
            _Mapper = mapper;
        }

        public async Task<UseCaseResponse<EmailResponse>> Execute(EmailRequest request)
        {
            var result = new UseCaseResponse<EmailResponse>();

            try
            {
                //var domain = new EmailDomain(request.AddressMail, request.IsPrimary, request.IsVerified, "");
                //var entity = await _EmailRepository.Create(domain);
                //var mapper = _Mapper.Map<EmailResponse>(entity);

                //return result.SetSuccess(mapper);
                throw new Exception();

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
