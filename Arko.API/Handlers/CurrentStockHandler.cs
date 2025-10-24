using Arko.API.Data;
using Arko.Core.Handlers;
using Arko.Core.Models;
using Arko.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Arko.API.Handlers
{
    public class CurrentStockHandler(ArkoDbContext context) : ICurrentStockHandler
    {
        public async Task<Response<CurrentStock>> AddToStockAsync(string patrimony)
        {
            var equipment = await context.Equipments.FirstOrDefaultAsync(e => e.Patrimony == patrimony);

            if (equipment is null)
            {
                return new Response<CurrentStock>(null, 404, "Equipamento não encontrado");
            }

            var contains = await context.CurrentStocks.AnyAsync(cs => cs.EquipmentId == equipment.Id);
            if (contains)
            {
                return new Response<CurrentStock>(null, 409, "Equipamento já está em estoque");
            }

            var currentStock = new CurrentStock
            {
                EquipmentId = equipment.Id
            };

            context.CurrentStocks.Add(currentStock);
            await context.SaveChangesAsync();
            return new Response<CurrentStock>(currentStock, 201, "Equipamento adicionado ao estoque com sucesso");
        }

        public async Task<Response<CurrentStock>> RemoveFromStockAsync(string patrimony)
        {
            try 
            {
               var equipment =  await context.Equipments.FirstOrDefaultAsync(e => e.Patrimony == patrimony);
                if (equipment is null) 
                {
                    return new Response<CurrentStock>(null, 404, "Equipamento não encontrado");
                }

                var stock = await context.CurrentStocks.FirstOrDefaultAsync(cs => cs.EquipmentId == equipment.Id);

                if (stock is null)
                {
                    return new Response<CurrentStock>(null, 409, "Equipamento não está em estoque");
                }

                context.CurrentStocks.Remove(stock);
                await context.SaveChangesAsync();
                return new Response<CurrentStock>(stock, 200, "Equipamento removido do estoque com sucesso");

            }
            catch
            {
                return new Response<CurrentStock>(null, 500, "Erro ao remover equipamento do estoque");
            }
        }
    }
}
