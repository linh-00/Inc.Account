using Inc.Accounts.DAL.Context;
using Inc.Accounts.DAL.Models;
using Inc.Accounts.Shared.Constants;
using Inc.Accounts.Shared.Exceptions.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressDomain = Inc.Accounts.Domain.Entities.Address;
using Inc.Accounts.Domain.Entities;
using Inc.Accounts.Domain.Interfaces;
using Azure.Core;

namespace Inc.Accounts.DAL.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly dbIncAccountsContext _dbAccount;

        public AddressRepository(dbIncAccountsContext dbAccount)
        {
            _dbAccount = dbAccount;
        }

        public async Task<AddressDomain> Create(AddressDomain request)
        {
            Models.Address newAddress = new Models.Address()
            {
                AccountId = request.AccountId,
                Street = request.Street,
                Number = request.Number,
                Complement = request.Complement,
                Neighborhood = request.Neighborhood,
                City = request.City,
                State = request.State,
                Country = request.Country,
                ZipCode = request.ZipCode,
                IsPrimary = request.IsPrimary,
                CreatedAt = request.CreatedAt,
                CreatedBy = request.CreatedBy
            };

            _dbAccount.Addresses.Add(newAddress);
            await _dbAccount.SaveChangesAsync();
            return request;             
        }

        public async Task<AddressDomain> GetById (Guid Id)
        {
            var address = await _dbAccount.Addresses.Where(x => x.Id == Id).FirstOrDefaultAsync();

            if(address is not null)
            {
                return new AddressDomain(address.Id, address.AccountId, address.Street, address.Number, address.Complement, address.Neighborhood, address.City, address.State, address.Country, address.ZipCode, address.IsPrimary, address.CreatedAt, address.CreatedBy, address.UpdatedAt, address.UpdatedBy);
            }

            throw new RepositoryException(ErrorMessages.AddressNotFound);
        }

        public async Task<IEnumerable<AddressDomain>> GetAllByAcountId(Guid Id)
        {
            var lstAddress = await _dbAccount.Addresses.Where(x => x.Id == Id).ToListAsync();
            return lstAddress.Select(res => new AddressDomain(res.Id, res.AccountId, res.Street, res.Number, res.Complement, res.Neighborhood, res.City, res.State, res.Country, res.ZipCode, res.IsPrimary, res.CreatedAt, res.CreatedBy, res.UpdatedAt, res.UpdatedBy));
        }
        public async Task<AddressDomain> Update(AddressDomain request)
        {
            var address = await _dbAccount.Addresses.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if(address is not null)
            {
                address.Street = request.Street;
                address.Number = request.Number;
                address.Complement = request.Complement;
                address.Neighborhood = request.Neighborhood;
                address.City = request.City;
                address.State = request.State;
                address.Country = request.Country;
                address.ZipCode = request.ZipCode;
                address.IsPrimary = request.IsPrimary;
                address.UpdatedAt = request.UpdatedAt;
                address.UpdatedBy = request.UpdatedBy;

                _dbAccount.Addresses.Update(address);
                await _dbAccount.SaveChangesAsync();
                return request;
            }

            throw new RepositoryException(ErrorMessages.AddressNotFound);
        }   
        
        public async Task<bool> Delete(Guid Id)
        {
            var address = await _dbAccount.Addresses.Where(x => x.Id == Id).FirstOrDefaultAsync();

            if(address is not null)
            {
                _dbAccount.Addresses.Remove(address);
                await _dbAccount.SaveChangesAsync();
                return true;
            }

            throw new RepositoryException(ErrorMessages.AddressNotFound);
        }
        
    }
}
