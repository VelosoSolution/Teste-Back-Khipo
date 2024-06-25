using Microsoft.AspNetCore.Mvc;
using Teste.Repositores.Interface;
using Teste.Models;

namespace Teste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventos _repository;
        private readonly List<EventosModels> EventosTable = new List<EventosModels>();

        public EventosController([FromServices] IEventos repository)
        {
            _repository = repository;

            for (int i = 1; i <= 50; i++)
            {
                EventosTable.Add(new EventosModels
                {
                    Id = i,
                    nomedoevento = "ABCD" + i,
                    datadoevento = DateTime.Today,
                    horariodoevento = DateTime.Today,
                    email = "eu@eu.com" + i
                });
            }
        }

        [HttpGet]
        public IEnumerable<EventosModels> Get(int page = 1, int pagesize = 10)
        {
            
            var totalgeral = EventosTable.Count;
            var totalpaginas = (int)Math.Ceiling((decimal)totalgeral / pagesize);

            var eventos = EventosTable
                .Skip((page - 1) * pagesize)
                .Take(pagesize)
                .ToList();

            return eventos;
        }

        [HttpPost]
        public async Task<ActionResult<EventosModels>> AddEventos(EventosModels evento)
        {
            await _repository.AddEventos(evento);
            return CreatedAtAction(nameof(Get), new { id = evento.Id }, evento);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventos(int id, EventosModels evento)
        {
            var result = await _repository.UpdateEventos(id, evento);

            if (result)
            {
                return NoContent();
            }
            else
            {
                return NotFound("Evento não encontrado");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEventos(int id)
        {
            var result = await _repository.DeleteEventos(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
