using Inc.Accounts.DAL.Context;
using Inc.Accounts.Domain.Interfaces;
using _Email = Inc.Accounts.DAL.Models.Email;
using EmailEntity = Inc.Accounts.Domain.Entities.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inc.Accounts.Shared.Exceptions.Exceptions;
using Inc.Accounts.Shared.Models;
using Inc.Accounts.Shared.Constants;
using Azure.Core;

namespace Inc.Accounts.DAL.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly dbIncAccountsContext _dbAccount;

        public EmailRepository(dbIncAccountsContext dbAccount)
        {
            _dbAccount = dbAccount;
        }

        public async Task<EmailEntity> Create(EmailEntity request)
        {
            _Email newEmail = new _Email()
            {
                AccountId = request.AccountId,
                Address = request.AddressMail,
                IsPrimary = request.IsPrimary,
                IsVerified = request.IsVerified,
                CreatedAt = request.CreatedAt,
                CreatedBy = request.CreatedBy
            };

            _dbAccount.Emails.Add(newEmail);
            await _dbAccount.SaveChangesAsync();
            return request;
        }

        public async Task<EmailEntity> GetById(Guid Id)
        {
            var email = await _dbAccount.Emails.Where(x => x.Id == Id).FirstOrDefaultAsync();

            if(email is not null)
            {
                return new EmailEntity(email.Id, email.AccountId, email.Address, email.IsPrimary, email.IsVerified, email.CreatedAt, email.CreatedBy, email.UpdatedAt, email.UpdatedBy);
            }
            throw new RepositoryException(ErrorMessages.EmailNotFound);
        }

        public async Task<IEnumerable<EmailEntity>> GetAllByAcountId(Guid Id)
        {
            var lstAddress = await _dbAccount.Emails.Where(x => x.Id == Id).ToListAsync();
            return lstAddress.Select(res => new EmailEntity(res.Id, res.AccountId, res.Address, res.IsPrimary, res.IsVerified, res.CreatedAt, res.CreatedBy, res.UpdatedAt, res.UpdatedBy));
        }

        public async Task<EmailEntity> Update(EmailEntity request)
        {
            var email = await _dbAccount.Emails.Where(X => X.Id == request.Id).FirstOrDefaultAsync();

            if(email is not null)
            {
                email.Address = request.AddressMail;
                email.IsPrimary = request.IsPrimary;
                email.IsVerified = request.IsVerified;
                email.UpdatedAt = request.UpdatedAt;
                email.UpdatedBy = request.UpdatedBy;
            }

            _dbAccount.Emails.Update(email);
            await _dbAccount.SaveChangesAsync();
            return request;
        }

        public async Task<bool> Delete(Guid Id)
        {
            var email = await _dbAccount.Emails.Where(X => X.Id == Id).FirstOrDefaultAsync();

            _dbAccount.Emails.Remove(email);
            await _dbAccount.SaveChangesAsync();
            return true;
        }
    }
}
