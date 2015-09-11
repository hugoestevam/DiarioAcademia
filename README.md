# DiarioAcademia

Para executar este projeto em seu potencial é necessário ter um servidor Node rodando na máquina.

#### Instalando NodeJS
* Obtenha o NodeJS pelo:
 * [Site oficial](https://nodejs.org/), ou use
 * [Chocolatey](https://chocolatey.org/)
 

#### Preparando o ambiente

##### Resumo dos comandos
    > npm install bower -g
    > npm install gulp -g
        -reinicie o prompt
    > npm install
    > bower install
    > gulp start


##### Detalhes
* Inicie o prompt com permissões de administrador e apontando para a [pasta do projeto web](https://github.com/AlexandreRech/DiarioAcademia/tree/master/NDDigital.DiarioAcademia.Apresentacao.WebApp) (onde está o `gulpfile.js`)
* Instale o bower globalmente inserindo no prompt `> npm install bower -g`
 * Será instalado na pasta de sistema `AppData` no caso do Windows
* Instale o gulp globalmente inserindo no prompt `> npm install gulp -g`
* Instale todas as dependencias de desenvolvedor com `> npm install`
 * O Node vai ler e baixar cada uma das dependencia listadas em `package.json`
* Instale todas as dependencias do client com `> bower install`
 * O Node vai ler e baixar cada uma das dependencia listadas em `bower.json`
* Insira simplemente `> gulp`. 
 * Se tudo estiver ok, o prompt irá listar todas as tasks do gulp

#### Executando
* Web Api
 * No Visual Studio, set o projeto `Distributed Services\Webapi`  `as StartUp Project` e o execute
* Web App
 * Com o prompt apontado para a pasta raíz do projeto web, insira `> gulp start`
 
A aplicação já deve estar executando em  [http://localhost:3000](http://localhost:3000). Lembrando que para tudo funcionar corretamente, o projeto [Webapi](https://github.com/AlexandreRech/DiarioAcademia/tree/master/NDDigital.DiarioAcademia.WebApi) deve estar executando no IIS.

