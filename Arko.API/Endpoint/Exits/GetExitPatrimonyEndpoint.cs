using Arko.API.Common.Api;
using Arko.Core;
using Arko.Core.Handlers;
using Arko.Core.Models;
using Arko.Core.Requests.Exits;
using Arko.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Arko.API.Endpoint.Exits
{
    public class GetExitPatrimonyEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/{patrimony}", HandleAsync)
                .WithName("Saídas: Busca")
                .WithSummary("Busca de Saídas pelo patrimonio")
                .WithDescription("Busca de Saídas pelo patrimonio")
                .WithOrder(2)
                .Produces<PagedResponse<Exit>>();
        }

        private static async Task<IResult> HandleAsync([FromRoute] string patrimony,
                                                       [FromServices] IExitHandler handler,
                                                       [FromQuery] int pageNumber = Definitions.DefaultPageNumber,
                                                       [FromQuery] int pageSize = Definitions.DefaultPageSize)

        {
            var request = new GetAllExitPatrimonyRequest
            {
                Patrimony = patrimony,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            var result = await handler.GetAllExitPatrimonyAsync(request);
            return result.IsSuccess
                ? TypedResults.Ok(result.Data)
                : TypedResults.NotFound(result.Data);
        }
    }

}

