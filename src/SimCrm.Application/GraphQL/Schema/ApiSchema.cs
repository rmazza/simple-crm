using Microsoft.Extensions.DependencyInjection;
using Simcrm.Application.GraphQL.Query;
using SimCrm.Application.GraphQL.Mutations;
using System;
using Graph = GraphQL.Types;

namespace Simcrm.Application.GraphQL.Schema
{
    public class ApiSchema : Graph.Schema
    {
        public ApiSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<ApiQuery>();
            Mutation = provider.GetRequiredService<ApiMutation>();
        }
    }
}
