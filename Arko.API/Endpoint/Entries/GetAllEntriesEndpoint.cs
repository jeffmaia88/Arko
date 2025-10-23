using Arko.API.Common.Api;
using Arko.Core;
using Arko.Core.Handlers;
using Arko.Core.Requests.Entries;
using Microsoft.AspNetCore.Mvc;

namespace Arko.API.Endpoint.Entries
{
    public class GetAllEntriesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/", HandleAsync)
               .WithName("Entradas : Lista")
               .WithSummary("Lista todas as entradas")
               .WithDescription("Lista todas as entradas")
               .WithOrder(3);
        }

        private static async Task<IResult> HandleAsync([FromServices] IEntryHandler handler,
                                                       [FromQuery] int pageNumber = Definitions.DefaultPageNumber,
                                                       [FromQuery] int pageSize = Definitions.DefaultPageSize)
        {
            var request = new GetAllEntriesRequest
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var result = await handler.GetAllAsync(request);
            return result.IsSuccess
                ? TypedResults.Ok(result.Data)
                : TypedResults.NotFound(result.Data);


        }
    }
}
