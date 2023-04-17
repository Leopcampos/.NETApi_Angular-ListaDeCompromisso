using ProjetoApiEntity.Domain.Entities;

namespace ProjetoApiEntity.Infra.Contracts
{
    public interface ICompromissoRepository : IBaseRepository<Compromisso>
    {
        List<Compromisso> GetByDatas(DateTime dataMin, DateTime dataMax, Guid idUsuario);
    }
}