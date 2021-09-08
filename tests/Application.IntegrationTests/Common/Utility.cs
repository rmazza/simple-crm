using GraphQL.SystemTextJson;
using SimCrm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Common
{
    internal static class Utility
    {
        /// <summary>
        /// Returns a generic List of Customers to test with.
        /// </summary>
        /// <param name="total"></param>
        /// <returns></returns>
        internal static List<Customer> GetTestCustomers(int total = 10)
        {
            var customers = new List<Customer>();

            for(int i = 0; i < total; i++)
            {
                customers.Add(new Customer
                {
                    UserId = i + 1,
                    FirstName = $"cst{i}FirstName",
                    LastName = $"cst{i}LastName",
                    MiddleName = $"cst{i}MiddleName",
                    DateOfBirth = DateTime.Parse("2000-1-1")
                });
            }

            return customers;
        }

        internal static async Task<string> GetJson(object obj)
        {
            string json = string.Empty;
            DocumentWriter writer = new();
            using MemoryStream stream = new();
            await writer.WriteAsync(stream, obj);
            stream.Position = 0;
            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }
    }
}
