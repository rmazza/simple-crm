using GraphQL.Types;
using GraphQL;

namespace SimpleCRM.Graphql
{
    public class MySchema
    {
        private ISchema _schema { get; set; }
        public ISchema GraphQLSchema
        {
            get
            {
                return this._schema;
            }
        }

        public MySchema()
        {
            this._schema = Schema.For(@"
                type Customer {
                  id: ID
                  firstName: String!,
                  lastName: String!,
                  middleName: Date
                }
                
                type Author {
                  id: ID,
                  name: String,
                  books: [Book]
                }
                
                type Mutation {
                  addAuthor(name: String): Author
                }
                
                type Query {
                    customers: [Customer]
                }
            ", _ =>
            {
                _.Types.Include<Query>();
                _.Types.Include<Mutation>();
            });
        }
    }
}
