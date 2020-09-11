using SimpleCRM.Interfaces;
using SimpleCRM.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleCRM.Repository
{
    public interface IDataRepository
    {
        Task<T> AddAsync<T>(T addEntity) where T : IDatabaseTable;
        Task<T> UpdateAsync<T>(T updateEntity) where T : IDatabaseTable;
        Task<Customer> GetCustomerAsync(Guid id);
        Task<List<Customer>> GetCustomersAsync();
        Task<List<EmailType>> GetEmailTypes();
        Task<List<PhoneType>> GetPhoneTypes();
    }
}
