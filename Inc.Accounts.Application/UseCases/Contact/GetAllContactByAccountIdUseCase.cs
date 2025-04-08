using AutoMapper;
using Inc.Accounts.Application.DTO.Response;
using Inc.Accounts.Application.Interfaces.Address;
using Inc.Accounts.Application.Interfaces.Contact;
using Inc.Accounts.Domain.Interfaces;
using Inc.Accounts.Shared.Constants;
using Inc.Accounts.Shared.Exceptions.Exceptions;
using Inc.Accounts.Shared.Interfaces;
using Inc.Accounts.Shared.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Accounts.Application.UseCases.Contact
{
    public class GetAllContactByAccountIdUseCase : IGetAllContactByAccountIdUseCase
    {
        public readonly IContactRepository _ContactRepository;
        public readonly ILogger<GetAllContactByAccountIdUseCase> _Logger;
        public readonly IMapper _Mapper;

        public GetAllContactByAccountIdUseCase(IContactRepository contactRepository, ILogger<GetAllContactByAccountIdUseCase> logger, IMapper mapper)
        {
            _ContactRepository = contactRepository;
            _Logger = logger;
            _Mapper = mapper;
        }

        public async Task<UseCaseResponse<IEnumerable<ContactResponse>>> Execute(Guid request)
        {
            var result = new UseCaseResponse<IEnumerable<ContactResponse>>();
            try
            {
                var entity = await _ContactRepository.GetAllByAcountId(request);
                var mapper = _Mapper.Map<IEnumerable<ContactResponse>>(entity);

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
