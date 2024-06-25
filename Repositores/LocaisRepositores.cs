using Teste.Data;
using Teste.Models;
using Teste.Repositores.Interface;
using Microsoft.EntityFrameworkCore;

namespace Teste.Repositores
{

    public class LocaisRepositores : ILocais
    {
        private readonly DbContextTeste _context;

        public LocaisRepositores(DbContextTeste context)
        {
            _context = context;
        }

        public async Task<List<LocaisModels>> GetLocais()
        {
            return await _context.Locais.ToListAsync();
        }

        public async Task<LocaisModels> GetLocais(int id)
        {
            return await _context.Locais.FindAsync(id);
        }

        public async Task<LocaisModels> AddLocais(LocaisModels local)
        {
            _context.Locais.Add(local);
            await _context.SaveChangesAsync();
            return local;
        }

        public async Task<bool> UpdateLocais(int id, LocaisModels local)
        {
            var LocaisExistente = await _context.Locais.FindAsync(id);

            if (LocaisExistente == null)
            {
                return false;
            }

            LocaisExistente.nomedolocal = local.nomedolocal;
            LocaisExistente.apelido = local.apelido;
            LocaisExistente.cnpj = local.cnpj;
            LocaisExistente.cidade = local.cidade;
            LocaisExistente.uf = local.uf;
            LocaisExistente.cep= local.cep;
            LocaisExistente.endereco = local.endereco;
            LocaisExistente.complemento = local.complemento;
            LocaisExistente.telefone = local.telefone;
            LocaisExistente.cadastroentradas = local.cadastroentradas;
            LocaisExistente.cadastrodecatracas = local.cnpj;
            LocaisExistente.cnpj = local.cnpj;

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
          
        public async Task<bool> DeleteLocais(int id)
        {
            var local = await _context.Locais.FindAsync(id);
            if (local == null)
            {
                return false;
            }

            _context.Locais.Remove(local);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
