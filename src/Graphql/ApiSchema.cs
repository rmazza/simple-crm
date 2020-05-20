using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCRM.Graphql
{
    public class ApiSchema : Schema
    {
        private ISchema _schema { get; set; }
        public ISchema GraphQLSchema
        {
            get
            {
                return this._schema;
            }
        }

        public ApiSchema()
        {
            
            this._schema = Schema.For(@"
          type Customer {
            customerId: String!
            firstName: String!,
            lastName: String!,
            middleName: String!,
            addUser: String!,
            addDate: Date!,
            changeUser: String,
            changeDate: Date
          }

          type Mutation {
            addCustomer(cst: Customer): Customer
          }

          type Query {
              customers: Customer
          }
      ", _ =>
            {
                _.Types.Include<Query>();
                _.Types.Include<Mutation>();
            });
        }

    }
}
