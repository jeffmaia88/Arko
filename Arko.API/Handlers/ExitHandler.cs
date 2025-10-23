using Arko.Core.Handlers;
using Arko.Core.Models;
using Arko.Core.Requests.Exits;
using Arko.Core.Responses;
using Arko.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Arko.API.Handlers
{
    public class ExitHandler(ArkoDbContext context) : IExitHandler
    {
        public async Task<Response<Exit>> CreateAsync(CreateExitRequest request)
        {
            try
            {
                var equipment = await context.Equipments.FirstOrDefaultAsync(e => e.Patrimony == request.Patrimony);
                if (equipment == null)
                {
                    return new Response<Exit>(null, 404, "Equipamento não encontrado");
                }

                var analyst = await context.Analysts.FindAsync(request.AnalystId);
                if (analyst == null)
                {
                    return new Response<Exit>(null, 404, "Equipamento não encontrado");
                }

                var exit = new Exit
                {
                    Destination = request.Destination,
                    ExitDate = request.ExitDate,
                    Responsible = analyst,
                    Equipment = equipment

                };
                context.Exists.Add(exit);
                await context.SaveChangesAsync();
                return new Response<Exit>(exit, 201, "Saída registrada com sucesso");
            }
            catch
            {
                return new Response<Exit>(null, 500, "Erro ao registrar saída");
            }

        }

        public Task<PagedResponse<List<Exit>>> GetAllExitsAsync(GetAllExitsRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Exit>>> GetExitPatrimonyAsync(GetExitPatrimonyRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
