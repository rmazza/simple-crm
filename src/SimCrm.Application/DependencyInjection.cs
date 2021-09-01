using Microsoft.Extensions.DependencyInjection;
using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.SystemTextJson;
using Simcrm.Application.GraphQL.Schema;
using System.Reflection;
using MediatR;
using SimCrm.Domain.Entities;
using FluentValidation;
using SimCrm.Application.Validators;
using FluentValidation.AspNetCore;

namespace SimCrm.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddFluentValidation();
            services.AddGraphQL()
                .AddSystemTextJson()
                .AddDocumentExecuter<DocumentExecuter>()
                .AddSchema(services => new ApiSchema(new SelfActivatingServiceProvider(services)));

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IValidator<Customer>, CustomerValidator>();
            services.AddScoped<IValidator<EmailAddress>, EmailValidator>();

            return services;
        }
    }
}
