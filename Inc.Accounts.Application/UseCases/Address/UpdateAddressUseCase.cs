using AutoMapper;
using Inc.Accounts.Application.DTO.Request;
using Inc.Accounts.Application.DTO.Response;
using Inc.Accounts.Application.Interfaces.Address;
using Inc.Accounts.Domain.Interfaces;
using Inc.Accounts.Shared.Models;
using Microsoft.Extensions.Logging;

namespace Inc.Accounts.Application.UseCases.Address
{
    public class UpdateAddressUseCase : IUpdateAddressUseCase
    {
        public readonly ILogger<UpdateAddressUseCase> _Logger;
        public readonly IAddressRepository _AddressRepository;
        public readonly IMapper _Mapper;

        public UpdateAddressUseCase(ILogger<UpdateAddressUseCase> logger, IAddressRepository addressRepository, IMapper mapper)
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
                throw new Exception();
            }
            catch (Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
