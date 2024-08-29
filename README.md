## Gerenciador de Cadastros CRUD C# <img align="center" alt="C#" height="30" width="40" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg">

Este projeto é um Gerenciador de Cadastros desenvolvido em C# usando .NET Core. A aplicação é um console que permite realizar operações de CRUD (Criar, Ler, Atualizar, Excluir) para gerenciar uma entidade. A aplicação pode armazenar dados em um arquivo ou em uma lista em memória, e oferece uma interface de usuário para manipulação dos dados.

## Funcionalidades
 - Exibição Inicial: Ao iniciar a aplicação, as últimas cinco entidades cadastradas são exibidas. Se houver menos de cinco, exibe o número total de entidades ou uma mensagem informando que não há entidades cadastradas.
 - Menu de Inclusão: Permite ao usuário inserir dados para criar uma nova entidade e adicioná-la ao repositório.
 - Menu de Alteração: Permite ao usuário pesquisar uma entidade existente, exibir seus dados atuais e atualizar com novas informações.
 - Menu de Exclusão: Permite ao usuário pesquisar uma entidade, exibir seus dados e confirmar a exclusão da entidade.
 - Menu de Pesquisa: Permite ao usuário buscar entidades por uma cadeia de caracteres ou ID. Exibe os resultados com a opção de visualizar detalhes e realizar cálculos baseados em propriedades DateTime.
 - Opção de Armazenamento: Escolha entre armazenar dados em um arquivo ou em uma lista em memória.

## Estrutura do Projeto

 - Camada de Apresentação: Projeto do tipo Console para entrada e saída de dados.
 - Camada de Negócio: Projeto do tipo Class Library contendo a classe para representar a entidade.
 - Camada de Dados: Projeto do tipo Class Library com dois repositórios:
 - Repositório em Arquivo: Realiza leitura e escrita de entidades em um arquivo.
 - Repositório em Memória: Realiza leitura e escrita de entidades em uma coleção em memória.
 - Interface de Repositório: Define métodos para operações de leitura e escrita de entidades, implementados pelos repositórios.
