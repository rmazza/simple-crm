using GraphQL;
using Microsoft.Extensions.Logging;
using SimpleCRM.Data;
using SimpleCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCRM.Graphql
{
    public class Query
    {
        private ILogger<Query> _logger;
        private readonly ApplicationDbContext _db;

        public Query(ILogger<Query> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [GraphQLMetadata("customers")]
        public IEnumerable<Customer> GetCustomers()
        {
            return _db.Customers.ToList();
        }
    }
}
