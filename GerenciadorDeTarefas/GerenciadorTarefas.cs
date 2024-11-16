using GerenciadorDeTarefas.Interfaces;
using System.Text.Json;

namespace GerenciadorDeTarefas
{
    public class GerenciadorTarefas : IGerenciadorTarefas
    {
        private List<Tarefa> tarefas;
        private const string CaminhoArquivo = "tarefas.json";

        public GerenciadorTarefas(List<Tarefa> listaDeTarefas = null)
        {
            tarefas = listaDeTarefas ?? new List<Tarefa>();
            if (listaDeTarefas == null)
            {
                CarregarTarefas();
            }
        }

        public void AdicionarTarefa(string titulo, string descricao)
        {
            tarefas.Add(new Tarefa { Titulo = titulo, Descricao = descricao });
            SalvarTarefas();
        }

        public void ListarTarefas(Func<Tarefa, bool> filtro = null)
        {
            Console.WriteLine();
            Console.WriteLine("=== Lista das Tarefas ===");
            var tarefasFiltradas = filtro == null ? tarefas : tarefas.Where(filtro).ToList();
            if (!tarefasFiltradas.Any())
            {
                Console.WriteLine("Nenhuma tarefa encontrada.");
                return;
            }

            foreach (var tarefa in tarefasFiltradas.OrderBy(t => t.DataCriacao))
            {
                Console.WriteLine($"ID: {tarefa.Id}");
                Console.WriteLine($"Título: {tarefa.Titulo}");
                Console.WriteLine($"Descrição: {tarefa.Descricao}");
                Console.WriteLine($"Status: {(tarefa.Concluida ? "Concluída" : "Pendente")}");
                Console.WriteLine($"Criada em: {tarefa.DataCriacao}");
                if (tarefa.Concluida)
                    Console.WriteLine($"Concluída em: {tarefa.DataConclusao}");
                Console.WriteLine(new string('-', 40));
            }
        }

        public void EditarTarefa(Guid id, string novoTitulo, string novaDescricao)
        {
            var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null) throw new ArgumentException("Tarefa não encontrada.");

            tarefa.Titulo = novoTitulo;
            tarefa.Descricao = novaDescricao;         

            SalvarTarefas();
            Console.WriteLine("Tarefa atualizada com sucesso.");
        }

        public void ExcluirTarefa(Guid id)
        {
            var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null) throw new ArgumentException("Tarefa não encontrada.");

            tarefas.Remove(tarefa);
            SalvarTarefas();
        }

        public void AlternarStatusTarefa(Guid id)
        {
            var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null) throw new ArgumentException("Tarefa não encontrada.");

            tarefa.Concluida = !tarefa.Concluida;
            tarefa.DataConclusao = tarefa.Concluida ? DateTime.Now : null;
            SalvarTarefas();
        }

        private void SalvarTarefas()
        {
            File.WriteAllText(CaminhoArquivo, JsonSerializer.Serialize(tarefas));
        }

        private void CarregarTarefas()
        {
            if (File.Exists(CaminhoArquivo))
            {
                var conteudo = File.ReadAllText(CaminhoArquivo);
                tarefas = JsonSerializer.Deserialize<List<Tarefa>>(conteudo) ?? new List<Tarefa>();
            }
        }
    }
}
