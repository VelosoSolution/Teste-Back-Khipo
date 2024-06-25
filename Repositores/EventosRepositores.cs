using Teste.Data;
using Teste.Models;
using Teste.Repositores.Interface;
using Microsoft.EntityFrameworkCore;

namespace Teste.Repositores
{
    public class EventosRepositores: IEventos
    {
        private readonly DbContextTeste _context;

        public EventosRepositores(DbContextTeste context)
        {
            _context = context;
        }

        public IEnumerable<EventosModels> GetEventos()
        {
            return  _context.Eventos.ToList();
        }

      

        public async Task<EventosModels> AddEventos(EventosModels evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();
            return evento;
        }

        public async Task<bool> UpdateEventos(int id, EventosModels evento)
        {
            var EventosExistente = await _context.Eventos.FindAsync(id);

            if (EventosExistente == null)
            {
                return false;
            }

            EventosExistente.nomedoevento = evento.nomedoevento;
            EventosExistente.datadoevento = evento.datadoevento;
            EventosExistente.horariodoevento = evento.horariodoevento;
            EventosExistente.email = evento.email;
            EventosExistente.telefone = evento.telefone;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteEventos(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return false;
            }

            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
