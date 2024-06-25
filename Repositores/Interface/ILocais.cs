using Teste.Models;
namespace Teste.Repositores.Interface
{
    public interface ILocais
    {
        Task<List<LocaisModels>> GetLocais();
        Task<LocaisModels> GetLocais(int id);
        Task<LocaisModels> AddLocais(LocaisModels locai);
        Task<bool> UpdateLocais(int id, LocaisModels locai);
        Task<bool> DeleteLocais(int id);
    }
}
