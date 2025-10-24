using Arko.API.Common.Api;
using Arko.API.Endpoint.Entries;
using Arko.API.Endpoint.Exits;

namespace Arko.API.Endpoint
{
    public static class Endpoint
    {
        public static void MapEndpoints(this WebApplication app)
        {
           // var endpoints = app.MapGroup("/")
                             //  .WithTags("Health Check")
                               //.MapGet("", () => new { message = "Ok" });

            var entries = app.MapGroup("v1/entries");


            entries.MapGroup("v1/entries")
                     .WithTags("Entries")
                     //.RequireAuthorization()
                     .MapEndpoint<CreateEntryEndpoint>()
                     .MapEndpoint<GetEntryPatrimonyEndpoint>()
                     .MapEndpoint<GetAllEntriesEndpoint>();

            var exits = app.MapGroup("v1/exits");

            exits.MapGroup("v1/exits")
                 .WithTags("Exits")
                 //.RequireAuthorization()
                 .MapEndpoint<CreateExitEndpoint>()
                 .MapEndpoint<GetExitPatrimonyEndpoint>()
                 .MapEndpoint<GetAllExitsEndpoint>();

        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
            where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;

        }
    }
}
