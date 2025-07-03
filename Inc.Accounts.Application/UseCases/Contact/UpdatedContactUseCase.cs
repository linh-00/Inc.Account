using AutoMapper;
using Inc.Accounts.Application.DTO.Request;
using Inc.Accounts.Application.DTO.Response;
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
    public class UpdatedContactUseCase : IUpdatedContactUseCase
    {
        public readonly IContactRepository _ContactRepository;
        public readonly ILogger<UpdatedContactUseCase> _Logger;
        public readonly IMapper _Mapper;

        public UpdatedContactUseCase(IContactRepository contactRepository, ILogger<UpdatedContactUseCase> logger, IMapper mapper)
        {
            _ContactRepository = contactRepository;
            _Logger = logger;
            _Mapper = mapper;
        }

        public async Task<UseCaseResponse<ContactResponse>> Execute(UpdatedContactRequest request)
        {
            var result = new UseCaseResponse<ContactResponse>();

            try
            {               
                var contact = await _ContactRepository.GetInfo(request.Id);
                contact.Update(request.Type, request.Value, request.Isprimary, "");

                await _ContactRepository.Update(contact);


                var response = _Mapper.Map<ContactResponse>(contact);

                return result.SetSuccess(response);

            }
            catch (Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
