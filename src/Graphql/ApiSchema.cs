using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SimpleCRM.Graphql
{
    public class ApiSchema : Schema
    {
        public ApiSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<ApiQuery>();
            Mutation = resolver.Resolve<ApiMutation>();
        }

    }
}
