<h1>Projeto IA na Educação -- Macroarquitetura</h1>
<p>
  Nosso projeto é dividido em camadas e no padrão MVC-Web, de forma genérica: 
  <li> Frontend - Usando Javascript e React </li>
  <li> Backend - Usando C# e .Net 6  </li>
  <li> Camada de persistência de dados - Usando SQLite </li><br>

  Nossa API (backend) é estruturada em camadas também (entidades, repositorios, serviços e controllers/web) seguindo um padrão de desacoplamento entres as camadas e com inversão de dependência.<br>
  Dependencias essas, injetadas pelo próprio framework do .NET, com uma auxílio de uma classe estática chamada [RegisterHelp.cs](https://github.com/UFRPE-IA-Project/IA-Project-Backend/blob/Develop/IAE.Web/Utils/RegisterHelp.cs). Os controladores seguem o padrão REST de API e possue a documentação da API via 
  Swagger, sendo também criado um arquivo ['swagger.json'](https://github.com/UFRPE-IA-Project/IA-Project-Backend/blob/Develop/IAE.Web/swagger.json) que pode ser visualisado no [Swagger Editor](https://editor.swagger.io/).<br>
  A API ainda possui implementada internamente o padrão de repositórios, contendo um repositório base genérico ([BaseRepository](https://github.com/UFRPE-IA-Project/IA-Project-Backend/blob/Develop/IAE.Repositorio/Repositories/BaseRepository.cs)) do qual todos os repositórios do projeto herdam/estende dele.<br>
  Tanto os Serviços quanto os repositórios possuem interfaces, essas são usadas para a comunicação entre as classes de serviços e repositórios.<br><br>
  
  A camada de Persistência é em um banco de dados relacional simplificado (SQLite) e o acesso ao banco é feito via uma biblioteca relativamente simples chamada Dapper.<br><br>
  <span> <img src ='https://github.com/UFRPE-IA-Project/IA-Project-Backend/assets/11301984/66f00037-e123-492e-acd2-bf3ea93f0286' style='width:1000px' > </span>
  <h6>Modelo Prototipado do Banco de Dados</h6>
</p>
