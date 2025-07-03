using AutoMapper;
using Inc.Accounts.Application.Interfaces.Contact;
using Inc.Accounts.Domain.Interfaces;
using Inc.Accounts.Shared.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Accounts.Application.UseCases.Contact
{
    public class DeleteContactUseCase : IDeleteContactUseCase
    {
        public readonly IContactRepository _ContactRepository;
        public readonly ILogger<DeleteContactUseCase> _Logger;
        public readonly IMapper _Mapper;

        public DeleteContactUseCase(IContactRepository contactRepository, ILogger<DeleteContactUseCase> logger, IMapper mapper)
        {
            _ContactRepository = contactRepository;
            _Logger = logger;
            _Mapper = mapper;
        }

        public async Task<UseCaseResponse<bool>> Execute(Guid request)
        {
            var result = new UseCaseResponse<bool>();

            try
            {
                var entity = await _ContactRepository.Delete(request);

                return result.SetSuccess(true);
            }
            catch (Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
