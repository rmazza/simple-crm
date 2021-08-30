using GraphQL;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using MediatR;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SimCrm.Application.GraphQL.Commands
{
    public class GraphqlCommand: IRequest<ExecutionResult>
    { 
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public JsonElement Variables { get; set; }
    }

    public class GraphqlCommandHander : IRequestHandler<GraphqlCommand, ExecutionResult>
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documentExecuter;
        private readonly IServiceProvider _serviceProvider;

        public GraphqlCommandHander(ISchema schema, IDocumentExecuter documentExecuter, IServiceProvider serviceProvider)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
            _serviceProvider = serviceProvider;
        }

        public async Task<ExecutionResult> Handle(GraphqlCommand request, CancellationToken cancellationToken)
        {
            return await _documentExecuter.ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = request.Query;
                _.OperationName = request.OperationName;
                _.Inputs = request.Variables.ToInputs();
                _.RequestServices = _serviceProvider;
            });

        }
    }
}
