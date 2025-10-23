using Arko.API.Data;
using Arko.Core.Handlers;
using Arko.Core.Models;
using Arko.Core.Requests.Entries;
using Arko.Core.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Arko.API.Handlers
{
    public class EntryHandler(ArkoDbContext context) : IEntryHandler
    {
        public async Task<Response<Entry>> CreateAsync(CreateEntryRequest request)
        {
            var equipment = await context.Equipments.FirstOrDefaultAsync(e => e.Patrimony == request.Patrimony);
                                                                             

            if (equipment == null)
            {
                return new Response<Entry>(null, 404, "Equipamento não encontrado");
            }

            var analyst = await context.Analysts.FindAsync(request.AnalystId);
            if (analyst is null)
            {
                return new Response<Entry>(null, 404, "Analista não encontrado");
            }


            var entry = new Entry
            {
                Origin = request.Origin,
                EntryDate = request.EntryDate,
                Equipment = equipment,
                Responsible = analyst,
            };

            context.Entries.Add(entry);
            await context.SaveChangesAsync();

            return new Response<Entry>(entry, 201, "Entrada Registrada com Sucesso");            

        }

        public Task<Response<Entry>> DeleteAsync(DeleteEntryRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponse<List<Entry>>> GetAllAsync(GetAllEntriesRequest request)
        {
           throw new NotImplementedException();
        }

        public async Task<PagedResponse<List<Entry>>> GetAllByPatrimonyAsync(GetEntryPatrimonyRequest request)
        {
            try
            {
                var query = context.Entries
                                   .Include(e => e.Equipment)
                                   .Include(e => e.Responsible)
                                   .Where(e => e.Equipment.Patrimony == request.Patrimony);

                var totalCount = await query.CountAsync();

                var entries = await query.OrderByDescending(e => e.EntryDate)
                                         .Skip((request.PageNumber - 1) * request.PageSize)
                                         .Take(request.PageSize)
                                         .ToListAsync();
                return new PagedResponse<List<Entry>>(entries, totalCount, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Entry>>(null, 500, "Erro ao buscar entradas pelo patrimônio");
            }
        }

        public Task<Response<Entry>> UpdateAsync(UpdateEntryRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
