using ProjetoApiEntittyFramework.Domain.Entities;
using ProjetoApiEntittyFramework.Infra.Contexts;
using ProjetoApiEntittyFramework.Infra.Contracts;

namespace ProjetoApiEntittyFramework.Infra.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly SqlServerContext _context;

        public UsuarioRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        public Usuario Get(string email)
        {
            throw new NotImplementedException();
        }

        public Usuario Get(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}