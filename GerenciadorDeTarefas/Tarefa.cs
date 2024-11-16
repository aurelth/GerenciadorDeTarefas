namespace GerenciadorDeTarefas
{
    public class Tarefa
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool Concluida { get; set; } = false;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataConclusao { get; set; } = null;
    }
}
