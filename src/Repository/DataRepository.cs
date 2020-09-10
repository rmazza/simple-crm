using GraphQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleCRM.Data;
using SimpleCRM.Interfaces;
using SimpleCRM.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SimpleCRM.Repository
{
    public class DataRepository : IDataRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DataRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
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
