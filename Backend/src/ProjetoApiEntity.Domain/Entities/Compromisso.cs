namespace ProjetoApiEntity.Domain.Entities
{
    public class Compromisso
    {
        public Guid IdCompromisso { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public string Descricao { get; set; }
        public Guid IdUsuario { get; set; }

        #region Relacionamentos

        public Usuario Usuario { get; set; }

        #endregion
    }
}