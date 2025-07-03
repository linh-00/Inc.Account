using Inc.Accounts.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inc.Accounts.Application.Interfaces.Configuration
{
    public interface IActionResultConverter
    {
        IActionResult Convert<T>(UseCaseResponse<T> response, bool noContentIfSuccess = false);
    }
}
