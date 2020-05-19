using GraphQL;
using Microsoft.Extensions.Logging;
using SimpleCRM.Data;
using SimpleCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCRM.Graphql
{
    public class Query
    {
        //private ILogger<Query> _logger;
        private readonly ApplicationDbContext _db;

        public Query(ApplicationDbContext db)
        {
            _db = db;
        }

        //public Query(ILogger<Query> logger)
        //{
        //    _logger = logger;
        //}

        [GraphQLMetadata("customers")]
        public Customer GetCustomers()
        {
            return new Customer { CustomerId = Guid.NewGuid(), FirstName = "Bob" };
        }
    }
}
