using Arko.API.Common.Api;
using Arko.API.Endpoint.Entries;

namespace Arko.API.Endpoint
{
    public static class Endpoint
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app.MapGroup("v1");


            endpoints.MapGroup("v1/entries")
                     .WithTags("Entries")
                     //.RequireAuthorization()
                     .MapEndpoint<CreateEntryEndpoint>();
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
            where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;

        }
    }
}
