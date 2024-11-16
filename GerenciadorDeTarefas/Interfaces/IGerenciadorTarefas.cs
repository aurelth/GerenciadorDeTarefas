namespace GerenciadorDeTarefas.Interfaces
{
    public interface IGerenciadorTarefas
    {
        void AdicionarTarefa(string titulo, string descricao);
        void ListarTarefas(Func<Tarefa, bool> filtro = null);
        void EditarTarefa(Guid id, string novoTitulo, string novaDescricao);
        void ExcluirTarefa(Guid id);
        void AlternarStatusTarefa(Guid id);
    }
}
