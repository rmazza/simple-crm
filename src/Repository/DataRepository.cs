using Microsoft.EntityFrameworkCore;
using SimpleCRM.Data;
using SimpleCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<int> AddCustomerAsync(Customer customer)
        {
            //    customer.AddUser = Guid.Parse(_user.Id);
            customer.AddDate = DateTime.Now;

            _dbContext.Customers.Add(customer);
            return _dbContext.SaveChangesAsync();
        }

        public Task<List<Customer>> GetCustomersAsync()
        {
            var test = _dbContext.Customers.Include(x => x.EmailAddresses).Include(x => x.PhoneNumbers).ToList();
            return _dbContext.Customers.Include(x => x.EmailAddresses).Include(x => x.PhoneNumbers).ToListAsync();
        }

        public Task<List<EmailType>> GetEmailTypes()
        {
            return _dbContext.EmailTypes.ToListAsync();
        }
    }
}
