using Microsoft.AspNetCore.Http;
using System;

namespace SimpleCRM.Graphql
{
    public class GraphQLSettings
    {
        public PathString Path { get; set; } = "graphql";
        public Func<HttpContext, object> BuildUserContext { get; set; }
    }
}
