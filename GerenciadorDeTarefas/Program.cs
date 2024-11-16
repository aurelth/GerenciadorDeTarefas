
using GerenciadorDeTarefas;
using GerenciadorDeTarefas.Interfaces;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
                .AddSingleton<IGerenciadorTarefas, GerenciadorTarefas>() // Registro da interface e implementação
                .AddSingleton<MenuOpcoes>() // Registro do menu de opções
                .BuildServiceProvider();

// Resolvendo o MenuDeOpcoes a partir do contêiner
var menu = serviceProvider.GetService<MenuOpcoes>();
menu.ExibirMenu();