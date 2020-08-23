using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleCRM.Data;
using SimpleCRM.Interfaces;
using SimpleCRM.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleCRM.Repository
{
    public class DataRepository : IDataRepository
    {
        private readonly ApplicationDbContext _dbContext;
        //private readonly ApplicationUser _user;

        public DataRepository(ApplicationDbContext dbContext /*, ApplicationUser user*/)
        {
            _dbContext = dbContext;
            //_user = user;
        }

        public async Task<Guid> AddAsync<T>(T addEntity) where T : IDatabaseTable
        {
            //    customer.AddUser = Guid.Parse(_user.Id);
            addEntity.AddDate = DateTime.Now;
            var addedEntity = _dbContext.Add(addEntity);

            await _dbContext.SaveChangesAsync();

            return ((T)addedEntity.Entity).Id;
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
