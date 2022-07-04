using GraphQL.SystemTextJson;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Football.GraphQL.Models
{
    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }

        [JsonConverter(typeof(InputsJsonConverter))]
        public Dictionary<string, object> Variables { get; set; }
        //public JObject Variables { get; set; } //https://github.com/graphql-dotnet/graphql-dotnet/issues/389
    }
}
