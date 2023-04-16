using ProjetoApiEntity.Domain.Entities;

namespace ProjetoApiEntity.Infra.Contracts
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario Get(string email);
        Usuario Get(string email, string senha);
    }
}