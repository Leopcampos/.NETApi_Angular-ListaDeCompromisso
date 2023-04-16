namespace ProjetoApiEntity.Domain.Entities
{
    public class Usuario
    {
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; }

        #region Relacionamentos

        public List<Compromisso> Compromissos { get; set; }

        #endregion
    }
}