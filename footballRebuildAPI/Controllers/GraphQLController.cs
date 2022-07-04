

using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Football.GraphQL.Models;
using GraphQL.Execution;

namespace Football.API.Controllers
{
    [Route("[controller]")]
    public class GraphQLController : Controller
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;

        public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }

            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                OperationName = query.OperationName,
                Variables = query.Variables.ToInputs()
            };

            var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

            // Needed as https://graphql-dotnet.github.io/docs/migrations/migration4 details
            // When outputting the ExecutionResult directly in the response, need to convert the data properly like this
            result.Data = ((ExecutionNode)result.Data).ToValue();

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
