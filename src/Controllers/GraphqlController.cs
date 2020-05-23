using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using SimpleCRM.Data;
using SimpleCRM.Graphql;
using System.Threading.Tasks;

namespace SimpleCRM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GraphqlController : ControllerBase
    {
        private readonly ISchema _schema;
        public GraphqlController(ISchema schema)
        {
            _schema = schema;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GraphQLQuery query)
        {
            var schema = new ApiSchema();
            var inputs = query.Variables.ToInputs();

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = _schema;
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