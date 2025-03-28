using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailEntity = Inc.Accounts.Domain.Entities.Email;

namespace Inc.Accounts.Domain.Interfaces
{
    public interface IEmailRepository
    {
        Task<EmailEntity> Create(EmailEntity request);
        Task<EmailEntity> GetById(Guid Id);
        Task<IEnumerable<EmailEntity>> GetAllByAcountId(Guid Id);
        Task<EmailEntity> Update(EmailEntity request);
        Task<bool> Delete(Guid Id);
    }
}
