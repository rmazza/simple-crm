using GraphQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleCRM.Data;
using SimpleCRM.Interfaces;
using SimpleCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SimpleCRM.Repository
{
    public class DataRepository : IDataRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Guid _loggedInUserId;

        public DataRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var claim = identity.FindFirst("sub");
            _loggedInUserId = Guid.Parse(claim.Value);
        }

        public async Task<T> AddAsync<T>(T addEntity) where T : IDatabaseTable
        {
            var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var claim = identity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            addEntity.AddUser = Guid.Parse(claim.Value);
            addEntity.AddDate = DateTime.Now;
            var addedEntity = _dbContext.Add(addEntity);

            await _dbContext.SaveChangesAsync();

            return (T)addedEntity.Entity;
        }

        public async Task<T> UpdateAsync<T>(T updateEntity) where T : IDatabaseTable
        {
            var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var claim = identity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            updateEntity.ChangeUser = Guid.Parse(claim.Value);
            updateEntity.ChangeDate = DateTime.Now;
            var updatedEntity = _dbContext.Update(updateEntity);

            await _dbContext.SaveChangesAsync();

            return (T)updatedEntity.Entity;
        }

        public async Task<T> DeleteAsync<T>(Guid id) where T : class, IDatabaseTable
        {
            var entityToDelete = await _dbContext.Set<T>().Where(x => x.Id.Equals(id)).SingleOrDefaultAsync();

            if (entityToDelete == null)
                throw new KeyNotFoundException($"No id was found that mathced: { id }");

            var deletedEntity = _dbContext.Remove(entityToDelete);

            await _dbContext.SaveChangesAsync();

            return (T)deletedEntity.Entity;
        }

        public async Task<Customer> GetCustomerAsync(Guid id)
        {
            return await _dbContext.Customers
                .Where(customer => customer.Id.Equals(id))
                .Include(x => x.EmailAddresses).ThenInclude(x => x.EmailType)
                .Include(x => x.PhoneNumbers).ThenInclude(x => x.PhoneType)
                .SingleOrDefaultAsync();
        }

        public Task<List<Customer>> GetCustomersAsync()
        {
            return _dbContext.Customers
                .Include(x => x.EmailAddresses).ThenInclude(x => x.EmailType)
                .Include(x => x.PhoneNumbers).ThenInclude(x => x.PhoneType)
                .ToListAsync();
        }

        public Task<List<EmailType>> GetEmailTypes()
        {
            return _dbContext.EmailTypes.ToListAsync();
        }

        public Task<List<PhoneType>> GetPhoneTypes()
        {
            return _dbContext.PhoneTypes.ToListAsync();
        }
    }
}
