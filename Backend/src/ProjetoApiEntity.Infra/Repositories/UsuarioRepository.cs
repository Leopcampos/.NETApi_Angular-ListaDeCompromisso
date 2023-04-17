using ProjetoApiEntity.Domain.Entities;
using ProjetoApiEntity.Infra.Contexts;
using ProjetoApiEntity.Infra.Contracts;

namespace ProjetoApiEntity.Infra.Repositories
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
            return _context.Usuario
                .Where(u => u.Email.Equals(email))
                .FirstOrDefault();
        }

        public Usuario Get(string email, string senha)
        {
            return _context.Usuario
                .Where(u => u.Email.Equals(email) && u.Senha.Equals(senha))
                .FirstOrDefault();
        }
    }
}