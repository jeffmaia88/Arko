using Arko.API.Common.Api;
using Arko.Core.Handlers;
using Arko.Core.Models;
using Arko.Core.Requests.Entries;
using Arko.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Arko.API.Endpoint.Entries
{
    public class CreateEntryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("", HandleAsync)
                .WithName("Entradas: Create")
                .WithSummary("Cria uma nova entrada")
                .WithDescription("Cria uma nova categoria")
                .WithOrder(1)
                .Produces<Response<Entry?>>();


        }

        private static async Task<IResult> HandleAsync([FromBody] CreateEntryRequest request, [FromServices] IEntryHandler handler)
        {
            var result =  await handler.CreateAsync(request);
            return result.IsSuccess 
                ? Results.Created($"/{result.Data?.Id}", result) 
                : Results.BadRequest(new { message = result.Message });




        }
    }
}
