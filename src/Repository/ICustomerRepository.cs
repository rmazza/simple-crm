using SimpleCRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleCRM.Repository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomers();
    }
}
