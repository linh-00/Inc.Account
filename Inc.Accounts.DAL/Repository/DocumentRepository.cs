using Azure.Core;
using Inc.Accounts.DAL.Context;
using Inc.Accounts.DAL.Models;
using Inc.Accounts.Domain.Entities;
using Inc.Accounts.Shared.Constants;
using Inc.Accounts.Shared.Exceptions.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Document = Inc.Accounts.DAL.Models.Document;
using Document = Inc.Accounts.Domain.Entities.Document;

namespace Inc.Accounts.DAL.Repository
{
    public class DocumentRepository
    {
        private readonly dbIncAccountsContext _dbAccount;

        public DocumentRepository(dbIncAccountsContext dbAccount)
        {
            _dbAccount = dbAccount;
        }

        public async Task<Document> Create(Document request)
        {
            _Document newDoc = new _Document()
            {
                AccountId = request.AccountId,
                Name = request.Name,
                Number = request.Number,
                Type = request.Type,
                FileUrl = request.FileUrl,
                CreatedAt = request.CreatedAt,
                CreatedBy = request.CreatedBy
            };

            _dbAccount.Documents.Add(newDoc);
            await _dbAccount.SaveChangesAsync();
            return request;
        }

        public async Task<Domain.Entities.Document> GetById (Guid Id)
        {
            var document = await _dbAccount.Documents.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (document is not null)
            {
                return new Domain.Entities.Document(document.Id, document.AccountId, document.Name, document.Number, document.Type, document.FileUrl, document.CreatedAt, document.CreatedBy, document.UpdatedAt, document.UpdatedBy);
            }

            throw new RepositoryException(ErrorMessages.UserNotFound);
        }

        public async Task<Document> Update(Document request)
        {
            var document = await _dbAccount.Documents.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (document is not null)
            {
                document.Name = request.Name;
                document.Number = request.Number;
                document.Type = request.Type;
                document.FileUrl = request.FileUrl;
                document.UpdatedAt = request.UpdatedAt;
                document.UpdatedBy = request.UpdatedBy;

                _dbAccount.Documents.Update(document);
                await _dbAccount.SaveChangesAsync();
                return request;
            }

            throw new RepositoryException(ErrorMessages.DocumentNotFound);
        }
        public async Task<bool> Delete(Guid Id)
        {
            var document = await _dbAccount.Documents.Where(x => x.Id == Id).FirstOrDefaultAsync();

            _dbAccount.Documents.Remove(document);
            await _dbAccount.SaveChangesAsync();
            return true;
        }
    }
}
