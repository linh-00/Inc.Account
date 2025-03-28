using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Accounts.Domain.Interfaces
{
    public interface IDocumentRepository
    {
        Task<Domain.Entities.Document> Create(Domain.Entities.Document request);
        Task<Domain.Entities.Document> GetById(Guid Id);
        Task<IEnumerable<Domain.Entities.Document>> GetAllByAcountId(Guid Id);
        Task<Domain.Entities.Document> Update(Domain.Entities.Document request);
        Task<bool> Delete(Guid Id);
    }
}
