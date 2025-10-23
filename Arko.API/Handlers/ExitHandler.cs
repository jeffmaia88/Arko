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

        public async Task<PagedResponse<List<Exit>>> GetAllExitsAsync(GetAllExitsRequest request)
        {
            try
            {
                var exits = await context.Exists
                                    .Include(e => e.Responsible)
                                    .Include(e => e.Equipment)
                                    .Skip((request.PageNumber - 1) * request.PageSize)
                                    .Take(request.PageSize)
                                    .ToListAsync();
                var count = await context.Exists
                                         .AsNoTracking()
                                         .OrderByDescending(e => e.ExitDate)
                                         .CountAsync();
                return new PagedResponse<List<Exit>>(exits,count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Exit>>(null,500, "Erro ao Buscar as Saídas");
            }

            
        }

        public async Task<PagedResponse<List<Exit>>> GetExitPatrimonyAsync(GetExitPatrimonyRequest request)
        {
            try
            {
                var query = context.Exists
                               .Include(e => e.Equipment)
                               .Include(e => e.Responsible)
                               .Where(e => e.Equipment.Patrimony == request.Patrimony);

                var count = await query.CountAsync();

                var exits = await query.OrderByDescending(e => e.ExitDate)
                                      .Skip((request.PageNumber - 1) * request.PageSize)
                                      .Take(request.PageSize)
                                      .ToListAsync();
                return new PagedResponse<List<Exit>>(exits, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Exit>>(null, 500, "Erro ao buscar saídas por patrimônio");
            }
            

            
        }
    }
}
