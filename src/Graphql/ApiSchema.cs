using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCRM.Graphql
{
    public class ApiSchema
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
            id: ID
            firstName: String!,
            lastName: String!,
            middleName: String!
          }

          type Mutation {
            addCustomer(cst: Customer): Customer
          }

          type Query {
              customers: [Customer],
              customer(id: ID): Customer
          }
      ", _ =>
            {
                _.Types.Include<Query>();
                _.Types.Include<Mutation>();
            });
        }

    }
}
