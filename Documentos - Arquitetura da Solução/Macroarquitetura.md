<h1>Projeto IA na Educação -- Macroarquitetura</h1>
<p>
  Nosso projeto é dividido em camadas e no padrão MVC-Web, de forma genérica: 
  <li> Frontend - Usando Javascript e React </li>
  <li> Backend - Usando C# e .Net 6  </li>
  <li> Camada de persistência de dados - Usando SQLite </li><br>

  Nossa API (backend) é estruturada em camadas também (entidades, repositorios, serviços e controllers/web) seguindo um padrão de desacoplamento entres as camadas e com inversão de dependência.<br>
  Dependencias essas, injetadas pelo próprio framework do .NET, com uma auxílio de uma classe estática chamada [RegisterHelp.cs](https://github.com/UFRPE-IA-Project/IA-Project-Backend/blob/Develop/IAE.Web/Utils/RegisterHelp.cs). Os controladores seguem o padrão REST de API e possue a documentação da API via 
  Swagger, sendo também criado um arquivo ['swagger.json'](https://github.com/UFRPE-IA-Project/IA-Project-Backend/blob/Develop/IAE.Web/swagger.json), sempre que uma nova build é gerada, que pode ser visualisado copiando o arquivo e colando no [Swagger Editor](https://editor.swagger.io/).<br>
  A API ainda possui implementada internamente o padrão de repositórios, contendo um repositório base genérico ([BaseRepository](https://github.com/UFRPE-IA-Project/IA-Project-Backend/blob/Develop/IAE.Repositorio/Repositories/BaseRepository.cs)) do qual todos os repositórios do projeto herdam/estende dele.<br>
  Tanto os Serviços quanto os repositórios possuem interfaces, essas são usadas para a comunicação entre as classes de serviços e repositórios.<br><br>
  
  A camada de Persistência é em um banco de dados relacional simplificado (SQLite) e o acesso ao banco é feito via uma biblioteca relativamente simples chamada Dapper.

  A API utilizada é a do ChatGPT (OpenAI). A conexão com a API da OpenAI é feita pelo próprio front, para evitar chamadas excessivas ao back, já que cada prompt da tela levaria a ao menos uma requisição ao backend o que, cumulativamente, geraria uma latência maior na interação com o usuário.<br>
  Outro motivo para as chamadas à API da OpenAI ficarem no frontend é que o backend foi pensado para só ser utilizado uma vez que fosse necessário alguma validação, ou comunicação com o banco da dados, o que facilita uma interface mais responsiva.<br><br>

  Quanto ao repositório Git, foi implementado um GitHub Action que gera um build da aplicação e roda os testes unitários sempre que um merge acontecer. E os Pull Requests criados também passam por um build antes de serem aceitos para garantir a mínima estabilidade do sistema.
</p>
