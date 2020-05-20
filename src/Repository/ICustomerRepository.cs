using SimpleCRM.Models;
using System.Collections.Generic;

namespace SimpleCRM.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
    }
}
