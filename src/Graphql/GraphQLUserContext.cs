using System.Security.Claims;

namespace SimpleCRM.Graphql
{
    public class GraphQLUserContext
    {
        public ClaimsPrincipal User { get; set; }
    }
}
