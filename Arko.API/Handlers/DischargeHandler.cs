using Arko.API.Data;
using Arko.Core.Enums;
using Arko.Core.Handlers;
using Arko.Core.Models;
using Arko.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Arko.API.Handlers
{
    public class DischargeHandler(ArkoDbContext context) : IDischargeHandler
    {
        public async Task<Response<Discharge>> AddDischargeAsync(string patrimony)
        {
            try
            {
                var equipment = await context.Equipments.FirstOrDefaultAsync(e => e.Patrimony == patrimony);
                if (equipment == null)
                {
                    return new Response<Discharge>(null, 404, "Equipamento não encontrado");
                }
                
                var contains = await context.Discharges.AnyAsync(d => d.EquipmentId == equipment.Id);
                if (contains)
                {
                    return new Response<Discharge>(null, 409, "Equipamento já está baixado");
                }

                if (equipment.Status == Status.Baixado)
                {
                     var discharge = new Discharge
                        {
                            EquipmentId = equipment.Id,
                            DateDischarge = DateTime.UtcNow
                        };
                        await context.Discharges.AddAsync(discharge);
                        await context.SaveChangesAsync();
                        return new Response<Discharge>(discharge, 201, "Baixa registrada com sucesso");
                }

                return new Response<Discharge>(null, 409, "Equipamento não está com status de baixado");

            }
            catch
            {
               return new Response<Discharge>(null, 500, "Erro ao registrar baixa do equipamento");
            }
        }

        public async Task<Response<Discharge>> RemoveDischargeAsync(string patrimony)
        {
            try
            {
                var equipment =  await context.Equipments.FirstOrDefaultAsync(e => e.Patrimony == patrimony);
                if (equipment == null)
                {
                    return new Response<Discharge>(null, 404, "Equipamento não encontrado");
                }

                var discharge = await context.Discharges.FirstOrDefaultAsync(d => d.EquipmentId == equipment.Id);
                if (discharge == null)
                {
                    return new Response<Discharge>(null, 409, "Equipamento não está baixado");
                }

                context.Discharges.Remove(discharge);
                await context.SaveChangesAsync();
                return new Response<Discharge>(discharge, 200, "Baixa removida com sucesso");
            }
            catch
            {
                 return new Response<Discharge>(null, 500, "Erro ao remover baixa do equipamento");
            }
            
        }
    }
}
