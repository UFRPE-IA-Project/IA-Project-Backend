<h1> IA-Project-Backend </h1> 
API do projeto de IA educacional da disciplina Engenharia de Software ministrado pelo Prof. Dr. Leandro Marques. A API é escrita com base em C# e .NET 6.
<br/>
<h2>Participantes</h2>
<p>Anderson Souza - Frontend<br>
André lima - Frontend/Infra<br>
Diego Passos- Backend<br>
Gilmar Campelo - Database e apoio geral<br>
Kleyton Clementino - Backend/Infra<br>
Samuel Alves - Frontend<br>
Victor Anunciação - Backend<br>
<br/>

<h2> Proposta da aplicação </h2>
<p> A aplicação tem a proposta de automatizar rotinas de aprendizagem desde a elaboração do plano de ensino à realização de provas pela e simulados pela plataforma. </p> 

<h2> Tecnologias Utilizadas no projeto </h2>

  <span> <img src ='https://icon-library.com/images/react-icon/react-icon-29.jpg' style='width:20px' >  React   </span> <br>
 <span> <img src ='https://static.vecteezy.com/system/resources/previews/021/495/993/original/chatgpt-openai-logo-icon-free-png.png' style='width:20px' >  OpenAi   </span> <br>
  <span> <img src ='https://static-00.iconduck.com/assets.00/c-sharp-c-icon-1822x2048-wuf3ijab.png' style='width:20px' >  C#   </span> <br>
  <span> <img src ='https://cdn.icon-icons.com/icons2/3053/PNG/512/mysql_workbench_macos_bigsur_icon_189924.png' style='width:20px' >  Mysql   </span> 

<h2>Funcionalidades do sistema</h2>

<h3> <img src='https://cdn-icons-png.flaticon.com/512/4312/4312094.png' style='width:40px'> Cadastro de usuário </h3>
<p>Ao realizar o cadastro, o usuário deverá indicar se está realizando um cadastro para professor ou aluno, caso o usuário seja um aluno, deverá informar o código da turma, informada pelo seu professor por seu professor, que por sua vez deverá cadastrar as turmas a ministrar </p>

<p> Os usuários poderão obter múltiplas turmas na plataforma. </p>

<h3> <img src='https://cdn-icons-png.flaticon.com/512/2941/2941658.png' style='width:40px'> Funcionalidades para o Professor </h3>

<h4>Plano de ensino</h4>

<p> O professor, além de cadastrar e acompanhar suas turmas, poderá elaborar o seu plano de ensino, interagindo com a inteligência artificial para montar, de forma automatizada, o seu plano de ensino. Para isto, o professor deverá informar as seguintes informações:   </p>

<li> Disciplina </li>
<li> Escolaridade </li>
<li> Assuntos abordados - (Deverá indicar a profundidade de cada assunto abordado) </li>
<li> Carga horária da disciplina </li>
<li> Referências Bibliográficas </li>
<li> Assuntos abordados - Deverá indicar sua profundidade através de pontos a serem distribuídos entre os itens adicionados </li> <br>

<p> Ao realizar o plano de ensino, o professor poderá avaliar os tópicos trazidos pela IA, e avaliar caso deseje refazer o plano de ensino, indicando quais pontos precisam ser melhorados.</p>
<p>O professor poderá editar ou criar manualmente os planos. </p>

 <h4>Banco de Questões</h4>
 <p> Ao realizar o cadastro da disciplina, o professor poderá gerar questões baseadas em seu plano de ensino, indicando o Nível das questões que deseja elaborar e o tipo de questão. </p>
 <p> A IA, irá elaborar as questões de acordo com o plano de ensino da disciplina </p>
 <p> O professor poderá editar e incluir questões manualmente. </p>

<h4> Elaborar Provas ou simulados </h4>
<p>A partir do banco de questões o professor poderá elaborar provas e simulados para os seus alunos, onde deverá realizar a revisão da correção realizada pela IA.</p>

<h3> <img src='https://cdn-icons-png.flaticon.com/512/3413/3413591.png' style='width:40px'> Funcionalidades para o aluno </h3>

 
<h4> Consultar Disciplina </h4>
<p>O aluno poderá consultar o conteúdo programático da disciplina, disponibilizada pelo professor </p>

<h4> Provas e simulados </h4>
<p> O aluno poderá realizar provas e simulados elaborados e disponibilizados pelo professor, onde terá uma nota dada pela IA para as atividades, esta nota será revisada e aprovada pelo professor. </p> 
