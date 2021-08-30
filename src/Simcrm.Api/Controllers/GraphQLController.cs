using GraphQL;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimCrm.Application.GraphQL.Commands;
using SimCrm.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace Simcrm.Api.Controllers
{
    public class GraphqlController : ApiControllerBase
    {
        private readonly ILogger<GraphqlController> _logger;

        public GraphqlController(ILogger<GraphqlController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task Post([FromBody] GraphqlCommand query)
        {
            try
            {
                ExecutionResult result = await Mediator.Send(query);

                Response.ContentType = "application/json";
                if (result.Errors?.Count > 0)
                {
                    Response.StatusCode = 400; // Bad Request
                }
                else
                {
                    Response.StatusCode = 200; // OK
                }

                // following code is needed due to IActionResult and System.Text.Json error
                DocumentWriter writer = new();
                await writer.WriteAsync(Response.Body, result);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                _logger.LogError(ex, "Internal Server Error");
            }
        }
    }
}