using Microsoft.AspNetCore.Mvc;
using Teste.Repositores.Interface;
using Teste.Models;

namespace Teste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocaisController : ControllerBase
    {
        private readonly ILocais _repository;

        private readonly List<LocaisModels> LocaisTable = new List<LocaisModels>();

        public LocaisController([FromServices] ILocais repository)
        {
            _repository = repository;

            for (int i = 1; i <= 50; i++)
            {
                LocaisTable.Add(new LocaisModels
                {
                    id = i,
                    nomedolocal = "ABCD" + i,
                    apelido = "ABCD" + i,
                    cnpj = "ABCD" + i,
                    cidade = "ABCD" + i,
                    uf = "M" + i,
                    cep = "ABCD" + i,
                    endereco = "ABCD" + i,
                    complemento = "ABCD" + i,
                    email = "a@a" + i,
                    telefone = "1" + i,
                    cadastrodecatracas = "1" + i,
                    cadastroentradas = "1" + i,
                });
            }
        }

        [HttpGet]
        public IEnumerable<LocaisModels> Get(int page = 1, int pagesize = 10)
        {
            //var locais = LocaisTable.ToList();
            var totalgeral = LocaisTable.Count;
            var totalpaginas = (int)Math.Ceiling((decimal)totalgeral / pagesize);

            var locais = LocaisTable
                .Skip((page - 1) * pagesize)
                .Take(pagesize)
                .ToList();

            return locais;
        }

        [HttpPost]
        public async Task<ActionResult<LocaisModels>> AddLocais(LocaisModels local)
        {

            await _repository.AddLocais(local);
            return CreatedAtAction(nameof(Get), new { id = local.id }, local);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocais(int id, LocaisModels local)
        {
            var result = await _repository.UpdateLocais(id, local);

            if (result)
            {
                return NoContent();
            }
            else
            {
                return NotFound("Local não encontrado");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLocais(int id)
        {
            var result = await _repository.DeleteLocais(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
