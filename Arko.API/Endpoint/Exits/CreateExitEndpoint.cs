using Arko.API.Common.Api;
using Arko.Core.Handlers;
using Arko.Core.Models;
using Arko.Core.Requests.Exits;
using Arko.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Arko.API.Endpoint.Exits
{
    public class CreateExitEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("", HandleAsync)
               .WithName("CreateExit")
               .WithSummary("Registra uma nova saída de equipamento")
               .WithDescription("Registra uma nova saída de equipamento no sistema.")
               .WithOrder(1)
               .Produces<Response<Exit>>();
        }

        private static async Task<IResult> HandleAsync([FromBody] CreateExitRequest request, [FromServices] IExitHandler handler)
        {
            var result = await handler.CreateAsync(request);
            return result.IsSuccess
                ? TypedResults.Created($"/{result.Data?.Id}", result.Data)
                : TypedResults.BadRequest(result.Data);
        }
    }
}
