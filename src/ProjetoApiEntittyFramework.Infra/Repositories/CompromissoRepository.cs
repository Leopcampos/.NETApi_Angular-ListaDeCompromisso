using ProjetoApiEntittyFramework.Domain.Entities;
using ProjetoApiEntittyFramework.Infra.Contexts;
using ProjetoApiEntittyFramework.Infra.Contracts;

namespace ProjetoApiEntittyFramework.Infra.Repositories
{
    public class CompromissoRepository : BaseRepository<Compromisso>, ICompromissoRepository
    {
        private readonly SqlServerContext _context;

        public CompromissoRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        public List<Compromisso> GetByDatas(DateTime dataMin, DateTime dataMax, Guid idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}