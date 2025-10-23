using Arko.API.Common.Api;
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
            app.MapGet("", HandleAsync)
                .WithName("Entradas : Busca")
                .WithSummary("Busca uma entrada pelo patrimônio")
                .WithDescription("Busca uma entrada pelo patrimônio")
                .WithOrder(2)
                .Produces<Response<Entry?>>();
        }

        private static async Task<IResult> HandleAsync([FromRoute] string patrimony, [FromServices] IEntryHandler handler)
        {
            var request = new GetEntryPatrimonyRequest
            {
                Patrimony = patrimony
            };
            var result = await handler.GetByPatrimonyAsync(request);
            return result.IsSuccess
                ? TypedResults.Ok(result.Data)
                : TypedResults.BadRequest(result.Data);
        }
    }
}
