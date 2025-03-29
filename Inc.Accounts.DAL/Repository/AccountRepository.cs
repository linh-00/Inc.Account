using Inc.Accounts.DAL.Context;
using Inc.Accounts.Domain.Entities;
using _Account = Inc.Accounts.DAL.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inc.Accounts.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Principal;
using Inc.Accounts.Shared.Exceptions.Exceptions;
using Inc.Accounts.Shared.Constants;

namespace Inc.Accounts.DAL.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly dbIncAccountsContext _dbAccount;

        public AccountRepository(dbIncAccountsContext dbAccount)
        {
            _dbAccount = dbAccount;
        }

        public async Task<Account> Create(Account request)
        {
            _Account newAccount = new _Account()
            {
                NickName = request.NickName,
                FullName = request.FullName,
                BirthDate = request.BirthDate,
                Gender = request.Gender.ToString(),
                IsVerify = request.IsVerify,
                ProfilePicture = request.ProfilePicture
            };

            _dbAccount.Accounts.Add(newAccount);
            await _dbAccount.SaveChangesAsync();
            return request;
        }

        public async Task<Account> GetById(Guid Id)
        {
            var account = await _dbAccount.Accounts
                .Include(x => x.Addresses)
                .Include(x => x.Contacts)
                .Include(x => x.Documents)
                .Include(x => x.Emails)
                .Where(x => x.Id == Id)
                .FirstOrDefaultAsync();

            if (account is null)
                throw new RepositoryException(ErrorMessages.AccountNotFound);

            var addresses = account.Addresses.Select(a => new Address(a.Id, a.AccountId, a.Street, a.Number, a.Complement, a.Neighborhood, a.City, a.State, a.Country, a.ZipCode, a.IsPrimary, a.CreatedAt, a.CreatedBy, a.UpdatedAt, a.UpdatedBy));

            var contacts = account.Contacts.Select(c => new Contact(c.Id, c.AccountId, c.Type, c.Value, c.IsPrimary, c.CreatedAt, c.CreatedBy, c.UpdatedAt, c.UpdatedBy));

            var documents = account.Documents.Select(d => new Document(d.Id, d.AccountId, d.Name, d.Number, d.Type, d.FileUrl, d.CreatedAt, d.CreatedBy, d.UpdatedAt, d.UpdatedBy));

            var emails = account.Emails.Select(e => new Email(e.Id, e.AccountId, e.Address, e.IsPrimary, e.IsVerified, e.CreatedAt, e.CreatedBy, e.UpdatedAt, e.UpdatedBy));

            var accounts = new Account(account.Id, account.FullName, account.BirthDate, account.Gender.FirstOrDefault(), account.IsVerify, account.ProfilePicture, emails, addresses, contacts, documents);


            return accounts;

        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            var account = await _dbAccount.Accounts.ToListAsync();

            if(account is not null)
            {
                return account.Select(res => new Account(res.Id, res.FullName, res.BirthDate, res.Gender.FirstOrDefault(), res.IsVerify, res.ProfilePicture));
            }

            throw new RepositoryException(ErrorMessages.AccountNotFound);
        }

        public async Task<Account> Update(Account request)
        {
            var account = await _dbAccount.Accounts.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if(account is not null)
            {
                account.NickName = request.NickName;
                account.FullName = request.FullName;
                account.BirthDate = request.BirthDate;
                account.Gender = request.Gender.ToString();
                account.IsVerify = request.IsVerify;
                account.ProfilePicture = request.ProfilePicture;

                _dbAccount.Accounts.Update(account);
                await _dbAccount.SaveChangesAsync();
                return request;
            }

            throw new RepositoryException(ErrorMessages.AccountNotFound);
        }

        public async Task<bool> Delete(Guid Id)
        {
            var account = await _dbAccount.Accounts.Where(x => x.Id == Id).FirstOrDefaultAsync();

            if (account is not null)
            {
                _dbAccount.Accounts.Remove(account);
                await _dbAccount.SaveChangesAsync();
                return true;
            }

            throw new RepositoryException(ErrorMessages.AccountNotFound);
        }
    }
}
