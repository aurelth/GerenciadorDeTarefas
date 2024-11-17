
Este é um Gerenciador de Tarefas desenvolvido em C#, com uma interface de console que permite criar, listar, editar, excluir e alternar o status de tarefas (pendente ou concluída). 
O projeto é baseado em boas práticas de programação, incluindo validações de entrada, injeção de dependência, orientação a objetos, e persistência de dados utilizando arquivos JSON.  

Funcionalidades Principais 

	*Adicionar Tarefas: 

		*Permite criar uma nova tarefa com título, descrição e status obrigatórios.
		*Garante que campos essenciais não sejam deixados em branco.
		*A tarefa é automaticamente registrada com um ID único e a data de criação.
		
	*Listar Tarefas: 

		*Exibe todas as tarefas, com opções para filtrar:
		*Todas as Tarefas.
		*Tarefas Pendentes.
		*Tarefas Concluídas.
		
	*Informações exibidas: 
		*ID, título, descrição, status (pendente ou concluída), data de criação e, se aplicável, data de conclusão.
		
Editar Tarefas: 
	*Permite alterar o título, descrição e status de uma tarefa existente.
	*O usuário pode escolher se deseja atualizar o status (concluído ou pendente) ao editar.
	*Inclui validações para garantir que os campos obrigatórios sejam preenchidos corretamente.
	
Excluir Tarefas: 
	*Remove permanentemente uma tarefa da lista.
	
Alternar Status de Tarefa: 
	*Alterna o status de uma tarefa entre "pendente" e "concluída".
	
Persistência de Dados: 
	*Todas as tarefas são armazenadas em um arquivo local chamado tarefas.json, garantindo que os dados sejam salvos mesmo após o programa ser encerrado.
	
Interface Amigável: 
	*O sistema exibe menus claros e organizados, com mensagens de erro e sucesso destacadas para facilitar a navegação.





Estrutura do Código: 
	*O projeto é modular e segue uma separação clara de responsabilidades: 

		Interfaces e Injeção de Dependência: 
			*A interface IGerenciadorDeTarefas abstrai as operações sobre tarefas.
			*A implementação concreta GerenciadorDeTarefas é registrada em um contêiner de DI usando o ServiceCollection.
	
		Classes Principais: 
			*Tarefa: Representa uma tarefa com atributos como título, descrição, status, data de criação e conclusão.
			*GerenciadorDeTarefas: Gerencia a lógica de manipulação de tarefas, como criação, edição, exclusão e persistência.
			*MenuDeOpcoes: Exibe o menu principal e interage com o usuário.
	
		Persistência de Dados: 
			*Os dados são armazenados em um arquivo JSON, garantindo compatibilidade e simplicidade. O JSON criado localiza-se no \bin\Debug\net6.0
	


		Testes Unitários: 
			*Testes foram implementados para testar cada método usando NUnit
 
		Pré-requisitos para Executar o Projeto: 
			*.NET 6.0 SDK instalado.
			*Um editor ou IDE, como Visual Studio 2022 ou Visual Studio Code.
