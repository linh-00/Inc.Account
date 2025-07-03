using AutoMapper;
using Inc.Accounts.Application.DTO.Request;
using Inc.Accounts.Application.DTO.Response;
using Inc.Accounts.Application.Interfaces.Address;
using Inc.Accounts.Domain.Interfaces;
using Inc.Accounts.Shared.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Inc.Accounts.Application.UseCases.Address
{
    public class UpdatedAddressUseCase : IUpdatedAddressUseCase
    {
        public readonly IAddressRepository _AddressRepository;
        public readonly ILogger<UpdatedAddressUseCase> _Logger;
        public readonly IMapper _Mapper;

        public UpdatedAddressUseCase (IAddressRepository addressRepository, ILogger<UpdatedAddressUseCase> logger, IMapper mapper)
        {
            _AddressRepository = addressRepository;
            _Logger = logger;
            _Mapper = mapper;
        }

        public async Task<UseCaseResponse<AddressResponse>> Execute(UpdatedAddressRequest request)
        {
            var result = new UseCaseResponse<AddressResponse>();

            try
            {
                var existingAddress = await _AddressRepository.GetInfo(request.Id);
                existingAddress.Update(request.Street, request.Number, request.Complement, request.Neighborhood, request.City, request.State, request.Country, request.ZipCode, request.IsPrimary, "");
                
                await _AddressRepository.Update(existingAddress);


               var response = _Mapper.Map<AddressResponse>(existingAddress);

                return result.SetSuccess(response);
            }

            catch(Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
