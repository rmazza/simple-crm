using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using SimpleCRM.Graphql;
using System.Threading.Tasks;

namespace SimpleCRM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GraphqlController : ControllerBase
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documentExecuter;
        private readonly IDocumentWriter _documentWriter;

        public GraphqlController(ISchema schema, IDocumentExecuter documentExecuter, IDocumentWriter documentWriter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
            _documentWriter = documentWriter;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var result = await _documentExecuter.ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            });
            
            if (result.Errors?.Count > 0)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new
            {
                data = result.Data,
                errors = result.Errors
            });
        }
    }
}