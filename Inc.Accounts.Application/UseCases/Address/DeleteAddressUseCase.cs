using AutoMapper;
using Inc.Accounts.Application.Interfaces.Address;
using Inc.Accounts.Domain.Interfaces;
using Inc.Accounts.Shared.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Accounts.Application.UseCases.Address
{
    public class DeleteAddressUseCase : IDeleteAddressUseCase
    {
        public readonly IAddressRepository _AddressRepository;
        public readonly ILogger<DeleteAddressUseCase> _Logger;
        public readonly IMapper _Mapper;

        public DeleteAddressUseCase(IAddressRepository addressRepository, ILogger<DeleteAddressUseCase> logger, IMapper mapper)
        {
            _AddressRepository = addressRepository;
            _Logger = logger;
            _Mapper = mapper;
        }

        public async Task<UseCaseResponse<bool>> Execute(Guid id)
        {
            var result = new UseCaseResponse<bool>();

            try
            {
                await _AddressRepository.Delete(id);

                return result.SetSuccess(true);
            }
            catch (Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
