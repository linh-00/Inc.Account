using Inc.Accounts.Application.DTO.Request;
using Inc.Accounts.Application.DTO.Response;
using Inc.Accounts.Application.Interfaces.Address;
using Inc.Accounts.Application.Interfaces.Configuration;
using Inc.Accounts.Application.UseCases.Address;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Inc.Accounts.Api.Controllers.Controller
{
    [ApiController]
    [Route("/api/v1/[Controller]")]
    public class AddressController : ControllerBase
    {
        public readonly ICreateAddressUseCase _CreateAddressUseCase;
        public readonly IActionResultConverter _IActionConverter;

        public AddressController(ICreateAddressUseCase createAddressUseCase, IActionResultConverter actionConverter)
        {
            _CreateAddressUseCase = createAddressUseCase;
            _IActionConverter = actionConverter;
        }

        [ProducesResponseType(typeof(AddressResponse), StatusCodes.Status200OK)]
        [HttpPost("CreateAccount")]
        public async Task<IActionResult> CreateAccount([FromBody] AddressRequest request)
        {
            var response = await _CreateAddressUseCase.Execute(request);
            return _IActionConverter.Convert(response);
        }
    }
}
