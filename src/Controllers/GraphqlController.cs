using GraphQL;
using Microsoft.AspNetCore.Mvc;
using SimpleCRM.Data;
using SimpleCRM.Graphql;
using System.Threading.Tasks;

namespace SimpleCRM.Controllers
{
    [Route("api/v1/graphql")]
    [ApiController]
    public class GraphqlController : ControllerBase
    {

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GraphQLQuery query)
        {
            var schema = new ApiSchema();
            var inputs = query.Variables.ToInputs();

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema.GraphQLSchema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}