using AutoMapper;
using Inc.Accounts.Application.DTO.Request;
using Inc.Accounts.Application.DTO.Response;
using Inc.Accounts.Application.Interfaces.Address;
using Inc.Accounts.Domain.Entities;
using Inc.Accounts.Domain.Interfaces;
using Inc.Accounts.Shared.Models;
using Microsoft.Extensions.Logging;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection.Emit;
using AddressDomain = Inc.Accounts.Domain.Entities.Address;

namespace Inc.Accounts.Application.UseCases.Address
{
    public class CreateAddressUseCase : ICreateAddressUseCase
    {
        public readonly ILogger<CreateAddressUseCase> _Logger;
        public readonly IMapper _Mapper;
        public readonly IAddressRepository _AddressRepository;

        public CreateAddressUseCase(ILogger<CreateAddressUseCase> logger, IMapper mapper, IAddressRepository addressRepository)
        {
            _Logger = logger;
            _AddressRepository = addressRepository;
            _Mapper = mapper;
        }
        public async Task<UseCaseResponse<AddressResponse>> Execute(AddressRequest request)
        {
            var result = new UseCaseResponse<AddressResponse>();

            try
            {
                var domain = new AddressDomain(request.Street, request.Number, request.Complement, request.Neighborhood, request.City, request.State, request.Country, request.ZipCode, request.IsPrimary, "");
                var entity = await _AddressRepository.Create(domain);
                var mapper = _Mapper.Map<AddressResponse>(entity);

                return result.SetSuccess(mapper);

            }
            catch(Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
