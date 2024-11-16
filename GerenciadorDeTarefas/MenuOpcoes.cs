using GerenciadorDeTarefas.Interfaces;

namespace GerenciadorDeTarefas
{
    public class MenuOpcoes
    {
        private readonly IGerenciadorTarefas gerenciador;

        public MenuOpcoes(IGerenciadorTarefas gerenciador)
        {
            this.gerenciador = gerenciador;
        }

        public void ExibirMenu()
        {
            while (true)
            {
                Console.Clear(); // Limpa o console para cada exibição do menu
                Console.WriteLine("===== Gerenciador de Tarefas =====");
                Console.WriteLine("1. Adicionar Tarefa");
                Console.WriteLine("2. Listar Todas as Tarefas");
                Console.WriteLine("3. Listar Tarefas Pendentes");
                Console.WriteLine("4. Listar Tarefas Concluídas");
                Console.WriteLine("5. Editar Tarefa");
                Console.WriteLine("6. Excluir Tarefa");
                Console.WriteLine("7. Alternar Status de Tarefa");
                Console.WriteLine("8. Sair");
                Console.WriteLine("==================================");
                Console.Write("Escolha uma opção: ");

                var escolha = Console.ReadLine();

                Console.Clear(); // Limpa o console antes de mostrar o resultado
                switch (escolha)
                {
                    case "1":
                        AdicionarTarefa();
                        break;
                    case "2":
                        gerenciador.ListarTarefas();
                        Pausar();
                        break;
                    case "3":
                        gerenciador.ListarTarefas(t => !t.Concluida);
                        Pausar();
                        break;
                    case "4":
                        gerenciador.ListarTarefas(t => t.Concluida);
                        Pausar();
                        break;
                    case "5":
                        EditarTarefa();
                        Pausar();
                        break;
                    case "6":
                        ExcluirTarefa();
                        Pausar();
                        break;
                    case "7":
                        AlternarStatusTarefa();
                        Pausar();
                        break;
                    case "8":
                        Console.WriteLine("Saindo do sistema. Até logo!");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        Pausar();
                        break;
                }
            }
        }

        private void AdicionarTarefa()
        {
            string titulo;
            do
            {
                Console.Write("Digite o título da tarefa (obrigatório): ");
                titulo = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(titulo))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("O título é obrigatório e não pode estar vazio.");
                    Console.ResetColor();
                }
            } while (string.IsNullOrWhiteSpace(titulo));

            string descricao;
            do
            {
                Console.Write("Digite a descrição da tarefa (obrigatória): ");
                descricao = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(descricao))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A descrição é obrigatória e não pode estar vazia.");
                    Console.ResetColor();
                }
            } while (string.IsNullOrWhiteSpace(descricao));

            gerenciador.AdicionarTarefa(titulo, descricao);
        }


        private void EditarTarefa()
        {
            Console.Write("Digite o ID da tarefa que deseja editar: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid id))
            {
                string titulo;
                do
                {
                    Console.Write("Novo título (obrigatório): ");
                    titulo = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(titulo))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("O título é obrigatório e não pode estar vazio.");
                        Console.ResetColor();
                    }
                } while (string.IsNullOrWhiteSpace(titulo));

                string descricao;
                do
                {
                    Console.Write("Nova descrição (obrigatória): ");
                    descricao = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(descricao))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("A descrição é obrigatória e não pode estar vazia.");
                        Console.ResetColor();
                    }
                } while (string.IsNullOrWhiteSpace(descricao));

                gerenciador.EditarTarefa(id, titulo, descricao);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Tarefa editada com sucesso!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ID inválido.");
                Console.ResetColor();
            }
        }


        private void ExcluirTarefa()
        {
            Console.Write("Digite o ID da tarefa que deseja excluir: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid id))
            {
                gerenciador.ExcluirTarefa(id);
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }

        private void AlternarStatusTarefa()
        {
            Console.Write("Digite o ID da tarefa que deseja alternar o status: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid id))
            {
                gerenciador.AlternarStatusTarefa(id);
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }

        private void Pausar()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
