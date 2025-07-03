using Azure.Core;
using Inc.Accounts.DAL.Context;
using Inc.Accounts.DAL.Models;
using Inc.Accounts.Domain.Entities;
using Inc.Accounts.Shared.Constants;
using Inc.Accounts.Shared.Exceptions.Exceptions;
using Microsoft.EntityFrameworkCore;
using _Contact = Inc.Accounts.DAL.Models.Contact;
using Contact = Inc.Accounts.Domain.Entities.Contact;


namespace Inc.Accounts.DAL.Repository
{
    public class ContactRepository
    {
        private readonly dbIncAccountsContext _dbAccount;

        public ContactRepository(dbIncAccountsContext dbAccount)
        {
            _dbAccount = dbAccount;
        }

        public async Task<Domain.Entities.Contact> Create(Domain.Entities.Contact request)
        {
            _Contact newContatc = new _Contact()
            {
                AccountId = request.AccountId,
                Type = request.Type,
                Value = request.Value,
                IsPrimary = request.Isprimary,
                CreatedAt = request.CreatedAt,
                CreatedBy = request.CreatedBy
            };
            _dbAccount.Contacts.Add(newContatc);
            await _dbAccount.SaveChangesAsync();
            return request;
        }

        public async Task<Domain.Entities.Contact> GetById(Guid id)
        {
            var contact = await _dbAccount.Contacts.Where(x => x.Id == id).FirstOrDefaultAsync();

            if(contact is not null)
            {
                return new Contact(contact.Id, contact.AccountId, contact.Type, contact.Value, contact.IsPrimary, contact.CreatedAt, contact.CreatedBy, contact.UpdatedAt, contact.UpdatedBy);
            }

            throw new RepositoryException(ErrorMessages.ContactNotFound);
        }
        public async Task<IEnumerable<Contact>> GetAllByAcountId(Guid Id)
        {
            var lstAddress = await _dbAccount.Contacts.Where(x => x.Id == Id).ToListAsync();
            return lstAddress.Select(res => new Contact(res.Id, res.AccountId, res.Type, res.Value, res.IsPrimary, res.CreatedAt, res.CreatedBy, res.UpdatedAt, res.UpdatedBy));
        }
        public async Task<Contact> GetInfo(Guid id)
        {
            var contact = await _dbAccount.Contacts.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (contact is not null)
                return new Contact(contact.Id, contact.AccountId, contact.Type, contact.Value, contact.IsPrimary, contact.CreatedAt, contact.CreatedBy, contact.UpdatedAt, contact.UpdatedBy);

            throw new RepositoryException(ErrorMessages.AddressNotFound);
        }

        public async Task<Domain.Entities.Contact> Update(Contact request)
        {
            var contact = await _dbAccount.Contacts.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (contact is not null)
            {
                contact.Type = request.Type;
                contact.Value = request.Value;
                contact.IsPrimary = request.Isprimary;
                contact.UpdatedAt = request.UpdatedAt;
                contact.UpdatedBy = request.UpdatedBy;
            }

            _dbAccount.Contacts.Update(contact);
            await _dbAccount.SaveChangesAsync();
            return request;
        }

        public async Task<bool> Delete (Guid Id)
        {
            var contact = await _dbAccount.Contacts.Where(x => x.Id == Id).FirstOrDefaultAsync();
                       
            _dbAccount.Contacts.Remove(contact);
            await _dbAccount.SaveChangesAsync();
            return true;

        }
    }
}
