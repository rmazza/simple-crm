using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleCRM.Data;
using SimpleCRM.Interfaces;
using SimpleCRM.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;

namespace SimpleCRM.Repository
{
    public class DataRepository : IDataRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public DataRepository(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<T> AddAsync<T>(T addEntity) where T : IDatabaseTable
        {
            //addEntity.AddUser = _userManager.GetUserId(User);
            addEntity.AddDate = DateTime.Now;
            var addedEntity = _dbContext.Add(addEntity);

            await _dbContext.SaveChangesAsync();

            return (T)addedEntity.Entity;
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
