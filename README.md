# DiarioAcademia

Para executar este projeto em seu potencial é necessário ter um servidor Node rodando na máquina.

#### Instalando NodeJS
* Obtenha o NodeJS pelo:
 * [Site oficial](https://nodejs.org/), ou use
 * [Chocolatey](https://chocolatey.org/)
* Obtenha o Python por:
 * [Python 2.7.3](https://www.python.org/ftp/python/2.7.3/python-2.7.3.msi)
* Certifique-se de possuir o Visual Studio instalado.
 
#### Baixando o Projeto

O download do projeto pode ser através do [download do zip](https://github.com/AlexandreRech/DiarioAcademia/archive/master.zip) ou pelo `git` seguindo os passos:

     > choco install git 
        -reinicie o prompt
        -aponte para a pasta da solução
     > git clone https://github.com/AlexandreRech/DiarioAcademia.git

#### Preparando o ambiente

##### Resumo dos comandos
    > npm install npm -g
        -reinicie o prompt
    > npm install gulp bower -g
        -reinicie o prompt
        -aponte para a pasta do projeto web
    > npm install
        -Em caso de aparecer avisos em relação ao phyton na instalação pode ignorar.
    > bower install
    > gulp start


##### Detalhes
* Inicie o prompt com permissões de administrador e apontando para a [pasta do projeto web](https://github.com/AlexandreRech/DiarioAcademia/tree/master/NDDigital.DiarioAcademia.Apresentacao.WebApp) (onde está o `gulpfile.js`)
* Instale a versão mais atual do npm  `> npm install npm -g`
* Instale gulp e bower globalmente inserindo no prompt `> npm install gulp bower -g`
 * Será instalado na pasta de sistema `AppData` no caso do Windows
* Execute o comando `npm install`
 * O Node vai ler e baixar cada uma das dependencias listadas em `package.json`
* Instale todas as dependencias do client com `> bower install`
 * O Node vai ler e baixar cada uma das dependencia listadas em `bower.json`
* Insira simplesmente `> gulp`. 
 * Se tudo estiver ok, o prompt irá listar todas as tasks do gulp

#### Executando
* Web Api
 * No Visual Studio, set o projeto `Distributed Services\Webapi`  `as StartUp Project` e o execute
* Web App
 * Com o prompt apontado para a pasta raíz do projeto web, insira `> gulp start`
 
A aplicação já deve estar executando em  [http://localhost:3000](http://localhost:3000). Lembrando que para tudo funcionar corretamente, o projeto [Webapi](https://github.com/AlexandreRech/DiarioAcademia/tree/master/NDDigital.DiarioAcademia.WebApi) deve estar executando no IIS.

