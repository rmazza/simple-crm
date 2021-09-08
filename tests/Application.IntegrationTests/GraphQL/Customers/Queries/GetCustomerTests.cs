using Application.IntegrationTests.Common;
using GraphQL;
using GraphQL.Execution;
using GraphQL.SystemTextJson;
using NUnit.Framework;
using SimCrm.Application.GraphQL.Commands;
using SimCrm.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.IntegrationTests.GraphQL.Customers.Queries
{
    using static SetUp;

    public class GetCustomerTests : TestBase
    {
        [Test]
        public async Task GetCustomerTests_ShouldReturnAllCustomers()
        {
            //Arrange 
            IEnumerable<Customer> testCustomers = Utility.GetTestCustomers();
            await AddRangeAsync(testCustomers);

            var returnObject = new
            {
                data = new
                {
                    customers = testCustomers.Select(x =>
                        new {
                            firstName = x.FirstName,
                            lastName = x.LastName,
                            middleName = x.MiddleName,
                            dateOfBirth = x.DateOfBirth
                        })
                }
            };

            var expectedResult = JsonSerializer.Serialize(returnObject);

            var query = new GraphqlCommand
            {
                Query = @"{
                            customers {
                                firstName
                                lastName
                                middleName
                                dateOfBirth
                            }
                        }"
            };

            // Act
            ExecutionResult result = await SendAsync(query);

            string actualResult = await Utility.GetJson(result);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
