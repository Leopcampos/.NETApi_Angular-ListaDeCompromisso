namespace ProjetoApiEntity.Presentation.Models.Compromisso
{
    public class CompromissoConsultaModel
    {
        public Guid IdCompromisso { get; set; }
        public string Nome { get; set; }
        public string Data { get; set; }
        public string Hora { get; set; }
        public string Descricao { get; set; }
    }
}