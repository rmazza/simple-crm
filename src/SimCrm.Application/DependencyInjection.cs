using Microsoft.Extensions.DependencyInjection;
using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.SystemTextJson;
using Simcrm.Application.GraphQL.Schema;
using System.Reflection;
using MediatR;
using System.Text.Json;

namespace SimCrm.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddGraphQL()
                .AddSystemTextJson()
                .AddDocumentExecuter<DocumentExecuter>()
                .AddSchema(services => new ApiSchema(new SelfActivatingServiceProvider(services)));

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
