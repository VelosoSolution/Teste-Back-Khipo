using Teste.Models;
namespace Teste.Repositores.Interface
{
    public interface IEventos
    {
        IEnumerable<EventosModels> GetEventos();
        Task<EventosModels> AddEventos(EventosModels evento);
        Task<bool> UpdateEventos(int id, EventosModels evento);
        Task<bool> DeleteEventos(int id);
    }
}
