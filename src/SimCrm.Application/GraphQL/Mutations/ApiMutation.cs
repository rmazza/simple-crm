using GraphQL.Types;
using Simcrm.Domain.GraphQL.Types;
using GraphQL;
using SimCrm.Domain.GraphQL.Types.InputTypes;
using Microsoft.Extensions.DependencyInjection;
using SimCrm.Application.Interfaces;
using SimCrm.Domain.Entities;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace SimCrm.Application.GraphQL.Mutations
{
    public class ApiMutation : ObjectGraphType
    {
        private readonly ILogger<ApiMutation> _logger;

        public ApiMutation(ILogger<ApiMutation> logger)
        {
            _logger = logger;

            FieldAsync(
                typeof(CustomerType),
                "addCustomer",
                "The customer to add",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CustomerInputType>> { Name = "customer" }
                ),
                resolve: async context =>
                {
                    var dbContext = context.RequestServices.GetRequiredService<IApplicationDbContext>();
                    var validator = context.RequestServices.GetService<IValidator<Customer>>();

                    var customer = context.GetArgument<Customer>("customer");
                    var validatorResult = await validator.ValidateAsync(customer);

                    if(!validatorResult.IsValid)
                    {
                        foreach(var result in validatorResult.Errors)
                        {
                            string errorMessage = $"{result.ErrorMessage} {nameof(result.AttemptedValue)}: {result.AttemptedValue}";
                            context.Errors.Add(new ExecutionError(errorMessage));
                            _logger.LogError(errorMessage);
                        }
                       
                        return null;
                    } 
                    else
                    {
                        var add = await dbContext.Customers.AddAsync(customer);
                        await dbContext.SaveChangesAsync();
                        return add.Entity;
                    }
                });

            FieldAsync(
                typeof(CustomerType),
                "updateCustomer",
                "Updated a current customer",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CustomerUpdateInputType>> { Name = "customer" }),
                resolve: async context =>
                {
                    var dbContext = context.RequestServices.GetRequiredService<IApplicationDbContext>();
                    var validator = context.RequestServices.GetService<IValidator<Customer>>();

                    var customer = context.GetArgument<Customer>("customer");
                    var dbCustomer = await dbContext.Customers.FirstOrDefaultAsync(c => c.UserId == customer.UserId);

                    dbCustomer.FirstName = customer.FirstName;
                    dbCustomer.LastName = customer.LastName;
                    dbCustomer.MiddleName = customer.MiddleName;
                    dbCustomer.DateOfBirth = customer.DateOfBirth;
                    dbCustomer.ChangeDate = DateTime.Now;

                    dbContext.Customers.Update(dbCustomer);
                    await dbContext.SaveChangesAsync();

                    return dbCustomer;
                });
        }
    }
}
