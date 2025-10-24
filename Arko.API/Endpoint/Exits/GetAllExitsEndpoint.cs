using Arko.API.Common.Api;
using Arko.Core;
using Arko.Core.Handlers;
using Arko.Core.Models;
using Arko.Core.Requests.Exits;
using Arko.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Arko.API.Endpoint.Exits
{
    public class GetAllExitsEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/", HandleAsync)
                .WithName("Saídas : Lista")
                .WithSummary("Busca Todas as Saídas")
                .WithDescription("Busca Todas as Saídas")
                .WithOrder(1)
                .Produces<PagedResponse<Exit>>();
        }

        private static async Task<IResult> HandleAsync([FromServices] IExitHandler handler,
                                                        [FromQuery] int pageNumber = Definitions.DefaultPageNumber,
                                                        [FromQuery] int pageSize = Definitions.DefaultPageSize)
        {
            var request = new GetAllExitsRequest
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var result = await handler.GetAllExitsAsync(request);
            return result.IsSuccess
                ? TypedResults.Ok(result.Data)
                : TypedResults.NotFound(result.Data);
        }
    }
}
