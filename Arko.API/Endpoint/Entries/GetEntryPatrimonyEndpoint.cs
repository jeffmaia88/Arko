using Arko.API.Common.Api;
using Arko.Core;
using Arko.Core.Handlers;
using Arko.Core.Models;
using Arko.Core.Requests.Entries;
using Arko.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Arko.API.Endpoint.Entries
{
    public class GetEntryPatrimonyEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/{patrimony}", HandleAsync)
                .WithName("Entradas : Busca")
                .WithSummary("Busca uma entrada pelo patrimônio")
                .WithDescription("Busca uma entrada pelo patrimônio")
                .WithOrder(2)
                .Produces<Response<Entry?>>();
        }

        private static async Task<IResult> HandleAsync([FromRoute] string patrimony,
                                                       [FromQuery] int? pageNumber,
                                                       [FromQuery] int? pageSize,
                                                       [FromServices] IEntryHandler handler)
        {
            var request = new GetEntryPatrimonyRequest
            {
                PageNumber = pageNumber ?? Definitions.DefaultPageNumber,
                PageSize = pageSize ?? Definitions.DefaultPageSize,
                Patrimony = patrimony
            };
            var result = await handler.GetAllByPatrimonyAsync(request);
            return result.IsSuccess
                ? TypedResults.Ok(result.Data)
                : TypedResults.NotFound(result.Data);
        }
    }
}
