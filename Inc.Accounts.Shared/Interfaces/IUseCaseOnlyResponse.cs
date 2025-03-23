using Inc.Accounts.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Accounts.Shared.Interfaces
{
    public interface IUseCaseOnlyResponse<TResponse>
    {
        Task<UseCaseResponse<TResponse>> Execute();
    }
}
