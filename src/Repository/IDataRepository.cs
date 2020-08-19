using SimpleCRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleCRM.Repository
{
    public interface IDataRepository
    {
        Task<int> AddCustomerAsync(Customer customer);
        Task<List<Customer>> GetCustomersAsync();
        Task<List<EmailType>> GetEmailTypes();
    }
}
