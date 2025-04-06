using AutoMapper;
using Inc.Accounts.Application.DTO.Response;
using Inc.Accounts.Application.Interfaces.Address;
using Inc.Accounts.Domain.Interfaces;
using Inc.Accounts.Shared.Constants;
using Inc.Accounts.Shared.Exceptions.Exceptions;
using Inc.Accounts.Shared.Models;
using Microsoft.Extensions.Logging;

namespace Inc.Accounts.Application.UseCases.Address
{
    public class GetAllAddressByAccountIdUseCase : IGetAllAddressByAccountIdUseCase
    {
        public readonly IAddressRepository _AddressRepository;
        public readonly ILogger<GetAllAddressByAccountIdUseCase> _Logger;
        public readonly IMapper _Mapper;
        public GetAllAddressByAccountIdUseCase(IAddressRepository addressRepository, ILogger<GetAllAddressByAccountIdUseCase> logger, IMapper mapper)
        {
            _AddressRepository = addressRepository;
            _Logger = logger;
            _Mapper = mapper;
        }
        public async Task<UseCaseResponse<IEnumerable<AddressResponse>>> Execute(Guid request)
        {
            var result = new UseCaseResponse<IEnumerable<AddressResponse>>();

            try
            {
                var entity = await _AddressRepository.GetAllByAcountId(request);
                var mapper = _Mapper.Map<IEnumerable<AddressResponse>>(entity);

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
