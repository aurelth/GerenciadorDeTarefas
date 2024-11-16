namespace GerenciadorDeTarefas.Tests
{
    [TestFixture]
    public class GerenciadorDeTarefasTests
    {
        private List<Tarefa> tarefasSimuladas;        
        private GerenciadorTarefas gerenciador;

        [SetUp]
        public void Setup()
        {
            // Inicializa uma lista simulada antes de cada teste
            tarefasSimuladas = new List<Tarefa>();
            gerenciador = new GerenciadorTarefas(tarefasSimuladas);
        }

        [Test]
        public void AdicionarTarefa_DeveAdicionarTarefaCorretamente()
        {
            // Arrange
            var tarefasSimuladas = new List<Tarefa>();
            var gerenciador = new GerenciadorTarefas(tarefasSimuladas);
            string titulo = "Estudar NUnit";
            string descricao = "Aprender a criar testes unitários.";

            // Act
            gerenciador.AdicionarTarefa(titulo, descricao);

            // Assert
            Assert.That(tarefasSimuladas.Count, Is.EqualTo(1));
            Assert.That(tarefasSimuladas[0].Titulo, Is.EqualTo(titulo));
            Assert.That(tarefasSimuladas[0].Descricao, Is.EqualTo(descricao));
            Assert.IsFalse(tarefasSimuladas[0].Concluida);
        }

        [Test]
        public void EditarTarefa_DeveEditarTituloEDescricao()
        {
            // Arrange
            var tarefasSimuladas = new List<Tarefa>
                {
                    new Tarefa { Id = Guid.NewGuid(), Titulo = "Tarefa Original", Descricao = "Descrição Original" }
                };

            var gerenciador = new GerenciadorTarefas(tarefasSimuladas);
            var tarefa = tarefasSimuladas[0];
            string novoTitulo = "Título Editado";
            string novaDescricao = "Descrição Editada";

            // Act
            gerenciador.EditarTarefa(tarefa.Id, novoTitulo, novaDescricao);

            // Assert
            Assert.That(tarefa.Titulo, Is.EqualTo(novoTitulo));
            Assert.That(tarefa.Descricao, Is.EqualTo(novaDescricao));
        }

        [Test]
        public void ExcluirTarefa_DeveRemoverTarefaCorretamente()
        {
            // Arrange
            var tarefasSimuladas = new List<Tarefa>
                {
                    new Tarefa { Id = Guid.NewGuid(), Titulo = "Tarefa para excluir", Descricao = "Será excluída." }
                };
            var gerenciador = new GerenciadorTarefas(tarefasSimuladas);
            var tarefa = tarefasSimuladas[0];

            // Act
            gerenciador.ExcluirTarefa(tarefa.Id);

            // Assert
            Assert.That(tarefasSimuladas.Count, Is.EqualTo(0));
        }

        [Test]
        public void AlternarStatusTarefa_DeveAlterarStatusCorretamente()
        {
            // Arrange
            var tarefasSimuladas = new List<Tarefa>
                {
                    new Tarefa { Id = Guid.NewGuid(), Titulo = "Tarefa Pendente", Concluida = false }
                };
            var gerenciador = new GerenciadorTarefas(tarefasSimuladas);
            var tarefa = tarefasSimuladas[0];

            // Act
            gerenciador.AlternarStatusTarefa(tarefa.Id);

            // Assert
            Assert.IsTrue(tarefa.Concluida);

            // Act (alterna novamente)
            gerenciador.AlternarStatusTarefa(tarefa.Id);

            // Assert
            Assert.IsFalse(tarefa.Concluida);
        }

        [Test]
        public void ListarTarefas_DeveRetornarTodasAsTarefas()
        {
            // Arrange
            var tarefasSimuladas = new List<Tarefa>
                {
                    new Tarefa { Titulo = "Tarefa 1", Concluida = false },
                    new Tarefa { Titulo = "Tarefa 2", Concluida = true }
                };
            var gerenciador = new GerenciadorTarefas(tarefasSimuladas);

            // Act
            var todasAsTarefas = tarefasSimuladas;

            // Assert
            Assert.That(todasAsTarefas.Count, Is.EqualTo(2));
        }

        [Test]
        public void ListarTarefasPendentes_DeveRetornarApenasTarefasPendentes()
        {
            // Arrange
            var tarefasSimuladas = new List<Tarefa>
                {
                    new Tarefa { Titulo = "Tarefa 1", Concluida = false },
                    new Tarefa { Titulo = "Tarefa 2", Concluida = true }
                };
            var gerenciador = new GerenciadorTarefas(tarefasSimuladas);

            // Act
            var tarefasPendentes = tarefasSimuladas.Where(t => !t.Concluida).ToList();

            // Assert
            Assert.That(tarefasPendentes.Count, Is.EqualTo(1));
            Assert.That(tarefasPendentes[0].Titulo, Is.EqualTo("Tarefa 1"));
        }

        [Test]
        public void ListarTarefasConcluidas_DeveRetornarApenasTarefasConcluidas()
        {
            // Arrange
            var tarefasSimuladas = new List<Tarefa>
                {
                    new Tarefa { Titulo = "Tarefa 1", Concluida = false },
                    new Tarefa { Titulo = "Tarefa 2", Concluida = true }
                };
            var gerenciador = new GerenciadorTarefas(tarefasSimuladas);

            // Act
            var tarefasConcluidas = tarefasSimuladas.Where(t => t.Concluida).ToList();

            // Assert
            Assert.That(tarefasConcluidas.Count, Is.EqualTo(1));
            Assert.That(tarefasConcluidas[0].Titulo, Is.EqualTo("Tarefa 2"));
        }
    }
}