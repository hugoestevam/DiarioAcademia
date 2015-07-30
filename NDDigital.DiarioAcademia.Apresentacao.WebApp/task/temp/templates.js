angular.module("core.module").run(["$templateCache", function($templateCache) {$templateCache.put("./app/directives/ndd-checkbox/ndd-checkbox.html","<div class=input-group ng-repeat=\"obj in array\" style=\"padding-bottom: 2%\" id=inputGroup{{$index}}><span class=input-group-addon><input type=checkbox ng-checked=\"onstart($index, obj, compare)\" ng-click=\"onclick($index, obj, compare, chkGroup, callback)\" ng-model=chkGroup></span> <input type=text class=form-control value={{obj.name}} disabled></div>");
$templateCache.put("./app/directives/ndd-modal/ndd-modal.html","<div class=\"modal fade\" id={{target}} tabindex=-1 role=dialog aria-labelledby=myModalLabel aria-hidden=true><div class=\"modal-dialog modal-lg\" style=\"margin-top: 5%\"><div class=modal-content><div class=modal-header><button type=button class=close data-dismiss=modal aria-label=Close><span aria-hidden=true>&times;</span></button><h4 class=modal-title id=myModalLabel>{{label}}</h4></div><div class=modal-body><div ng-transclude></div></div><div class=modal-footer><button type=button class=\"btn btn-default\" data-dismiss=modal ng-hide=info>Cancelar</button> <button type=button class=\"btn btn-primary\" data-dismiss=modal ng-click=callback()>Ok</button></div></div></div></div>");
$templateCache.put("./app/directives/ndd-panel/ndd-panel.html","<div class=col-sm-3><div class=\"panel panel-info text-center option-home\" ui-sref=aluno.list><div class=panel-body><i class=\"fa fa-2x\" ng-class=icon></i></div><div class=panel-footer>{{title}}</div></div></div>");
$templateCache.put("./app/templates/components/inner-view.html","<div id=page-wrapper><div ui-view class=container-fluid></div></div>");
$templateCache.put("./app/templates/layout/footer.html","");
$templateCache.put("./app/templates/layout/header.html","");
$templateCache.put("./app/templates/layout/navbar.html","<nav class=\"navbar navbar-inverse navbar-fixed-top\" role=navigation><div class=navbar-header><button type=button class=navbar-toggle data-toggle=collapse data-target=.navbar-ex1-collapse><span class=sr-only></span> <span class=icon-bar></span> <span class=icon-bar></span> <span class=icon-bar></span></button> <a class=navbar-brand href=index.html>Diário da Academia</a></div><div ng-include=\"\'app/templates/layout/top-menu.html\'\"></div><div ng-include=\"\'app/templates/layout/sidebar.html\'\"></div></nav>");
$templateCache.put("./app/templates/layout/sidebar.html","<div class=\"collapse navbar-collapse navbar-ex1-collapse\"><ul class=\"nav navbar-nav side-nav\"><li class=li><a ui-sref=home data-toggle=collapse><i class=\"fa fa-fw fa-home\"></i> Início</a></li><li class=li><a href=javascript:; data-toggle=collapse data-target=#demo><i class=\"fa fa-fw fa-university\"></i> Turmas <i class=\"fa fa-fw fa-angle-down\"></i></a><ul id=demo class=collapse><li><a ui-sref=turma.create>Nova Turma</a></li><li><a ui-sref=turma.list>Listar Turmas</a></li></ul></li><li class=li><a href=javascript:; data-toggle=collapse data-target=#demo2><i class=\"fa fa-fw fa-users\"></i> Alunos <i class=\"fa fa-fw fa-angle-down\"></i></a><ul id=demo2 class=collapse><li ng-if=\"shell.isVisible(\'aluno.create\')\"><a ui-sref=aluno.create>Novo Aluno</a></li><li><a ui-sref=aluno.list>Listar Alunos</a></li></ul></li><li class=li><a href=javascript:; data-toggle=collapse data-target=#demo3><i class=\"fa fa-fw fa-calendar\"></i> Aulas <i class=\"fa fa-fw fa-angle-down\"></i></a><ul id=demo3 class=collapse><li><a ui-sref=aula.create>Novo Aula</a></li><li><a ui-sref=aula.list>Listar de Aulas</a></li></ul></li><li class=li><a href=javascript:; data-toggle=collapse data-target=#demo4><i class=\"fa fa-fw fa-check\"></i> Realizar Chamada <i class=\"fa fa-fw fa-angle-down\"></i></a><ul id=demo4 class=collapse><li><a ui-sref=chamada.create>Nova Lista</a></li></ul></li><li class=li><a href=javascript:; data-toggle=collapse data-target=#demo5><i class=\"fa fa-fw fa-wrench\"></i> Gerenciador <i class=\"fa fa-fw fa-angle-down\"></i></a><ul id=demo5 class=collapse><li><a ui-sref=manager.user>Usuarios</a></li><li><a ui-sref=manager.group>Grupos</a></li><li><a ui-sref=manager.permissions>Permissões</a></li></ul></li><li class=li><a href=#><i class=\"fa fa-fw fa-database\"></i> Sobre</a></li></ul></div>");
$templateCache.put("./app/templates/layout/toolbar.html","");
$templateCache.put("./app/templates/layout/top-menu.html","<ul class=\"nav navbar-right top-nav\"><li class=dropdown><a class=\"dropdown-toggle cursorUser\" data-toggle=dropdown><i class=\"fa fa-user\"></i> {{shell.authentication.userName}}<b class=caret></b></a><ul class=dropdown-menu><li><a href=#><i class=\"fa fa-fw fa-user\"></i> Perfil</a></li><li><a href=#><i class=\"fa fa-fw fa-gear\"></i> Configurações</a></li><li data-ng-hide=shell.authentication.isAuth><a ui-sref=signup class=text>Registrar-se</a></li><li data-ng-hide=shell.authentication.isAuth><a ui-sref=login class=text>Entrar</a></li><li class=divider></li><li data-ng-show=shell.authentication.isAuth><a href class=text data-ng-click=shell.logOut()>Sair</a></li></ul></li></ul>");
$templateCache.put("./app/views/aluno/aluno-create.html","<div class=col-lg-8><h1 class=page-header>{{vm.title}}</h1><ol class=breadcrumb><li><i class=\"fa fa-home\"></i> <a ui-sref=home>Inicio</a></li><li class=active><i class=\"fa fa-users\"></i> Alunos</li></ol><div><form name=vm.alunoForm class=jumbotron><input class=form-control type=text ng-model=vm.aluno.nome name=nome placeholder=Nome ng-required=true ng-minlength=10><br><input class=form-control type=text ng-model=vm.aluno.endereco.cep name=cep placeholder=CEP ng-required=true ng-minlength=8><br><input class=form-control type=text ng-model=vm.aluno.endereco.bairro name=bairro placeholder=Bairro ng-required=true><br><input class=form-control type=text ng-model=vm.aluno.endereco.localidade name=localidade placeholder=Localidade ng-required=true><br><input class=form-control type=text ng-model=vm.aluno.endereco.uf name=uf placeholder=UF ng-required=true><br><input class=form-control type=text ng-model=vm.aluno.turma name=turma ng-hide=true ng-required=true><select class=form-control ng-model=vm.aluno.turma ng-options=\"turma.descricao for turma in vm.turmas\"><option>Selecione a Turma</option></select><br><div ng-show=\"vm.alunoForm.nome.$error.required && vm.alunoForm.nome.$dirty\" class=\"alert alert-danger\">Por favor, preencha o campo nome!</div><div ng-show=\"vm.alunoForm.nome.$error.minlength && vm.alunoForm.nome.$dirty\" class=\"alert alert-danger\">O campo nome deve ter mais de 10 caractéres!</div><div ng-show=\"vm.alunoForm.turma.$error.required && vm.alunoForm.uf.$dirty\" class=\"alert alert-danger\">Selecione uma turma válida!</div><button class=\"btn btn-primary\" ng-click=vm.save() ng-disabled=vm.alunoForm.$invalid>Salvar</button> <button class=\"btn btn-success\" ng-click=vm.clearFields()>Limpar</button></form></div></div>");
$templateCache.put("./app/views/aluno/aluno-details.html","<div class=col-lg-8><h1 class=page-header>{{vm.title}}</h1><ol class=breadcrumb><li><i class=\"fa fa-home\"></i> <a ui-sref=home>Inicio</a></li><li class=active><i class=\"fa fa-users\"></i> Alunos</li></ol><div><form name=vm.alunoForm class=jumbotron><input class=form-control type=text ng-model=vm.aluno.nome name=nome placeholder=Nome ng-required=true ng-minlength=10><br><input class=form-control type=text ng-model=vm.aluno.endereco.cep name=cep placeholder=CEP ng-required=true ng-minlength=8><br><input class=form-control type=text ng-model=vm.aluno.endereco.bairro name=bairro placeholder=Bairro ng-required=true><br><input class=form-control type=text ng-model=vm.aluno.endereco.localidade name=localidade placeholder=Localidade ng-required=true><br><input class=form-control type=text ng-model=vm.aluno.endereco.uf name=uf placeholder=UF ng-required=true><br><select class=form-control ng-model=vm.aluno.turma ng-options=\"turma.descricao for turma in vm.turmas\"><option value>Selecione a Turma</option></select><br><div ng-show=\"vm.alunoForm.nome.$error.required && vm.alunoForm.nome.$dirty\" class=\"alert alert-danger\">Por favor, preencha o campo nome!</div><div ng-show=\"vm.alunoForm.nome.$error.minlength && vm.alunoForm.nome.$dirty\" class=\"alert alert-danger\">O campo nome deve ter mais de 10 caractéres!</div><div ng-show=\"vm.alunoForm.turma.$error.selected && vm.alunoForm.nome.$dirty\" class=\"alert alert-danger\">Selecione uma turma válida!</div><button class=\"btn btn-primary\" ng-click=vm.save() ng-disabled=vm.alunoForm.$invalid>Salvar</button> <button class=\"btn btn-success\" ng-click=vm.clearFields()>Limpar</button></form></div></div>");
$templateCache.put("./app/views/aluno/aluno-list.html","<div class=col-lg-8><h1 class=page-header>{{vm.title}}</h1><ol class=breadcrumb><li><i class=\"fa fa-home\"></i> <a ui-sref=home>Inicio</a></li><li class=active><i class=\"fa fa-users\"></i> Alunos</li></ol><div><div class=jumbotron><div><input class=form-control type=text ng-model=vm.criterioDeBusca placeholder=\"O que você está procurando?\"><table class=table><tr><th></th><th>Descrição do aluno</th></tr><tr ng-class ng-repeat=\"aluno in vm.alunos | filter: vm.criterioDeBusca\"><td><input type=checkbox ng-click=\"vm.alunoSelecionado = aluno\"></td><td>{{aluno.nome}}</td></tr></table><a ui-sref=\"aluno.details( { alunoId : vm.alunoSelecionado.id } )\"><button class=\"btn btn-info\">Editar {{vm.alunoSelecionado.nome}}</button></a> <button class=\"btn btn-danger\" ng-click=vm.delete(vm.alunoSelecionado) ng-disabled=!true>Excluir</button></div></div></div></div>");
$templateCache.put("./app/views/aula/aula-create.html","<div class=col-lg-8><h1 class=page-header>{{vm.title}}</h1><ol class=breadcrumb><li><i class=\"fa fa-home\"></i> <a ui-sref=home>Inicio</a></li><li class=active><i class=\"fa fa-calendar\"></i> Aulas</li></ol><div class=jumbotron><form name=vm.aulaForm class=jumbotron><input class=form-control type=date ng-model=vm.aula.data name=data ng-required=true ng-minlength=10><br><input class=form-control type=text ng-model=vm.aula.turma name=turma ng-hide=true ng-required=true><br><select class=form-control ng-model=vm.aula.turma ng-options=\"turma.descricao for turma in vm.turmas\"><option value>Selecione a Turma</option></select><br><button class=\"btn btn-primary\" ng-click=vm.save() ng-disabled=vm.aulaForm.$invalid>Salvar</button> <button class=\"btn btn-success\" ng-click=vm.clearFields()>Limpar</button></form></div></div>");
$templateCache.put("./app/views/aula/aula-list.html","<div class=col-lg-8><h1 class=page-header>{{vm.title}}</h1><ol class=breadcrumb><li><i class=\"fa fa-home\"></i> <a ui-sref=home>Inicio</a></li><li class=active><i class=\"fa fa-calendar\"></i> Aulas</li></ol><div><div class=jumbotron><div><input class=form-control type=text ng-model=vm.criterioDeBusca placeholder=\"O que você está procurando?\"><table class=table><tr><th></th><th>Data da aula</th></tr><tr ng-class ng-repeat=\"aula in vm.aulas | filter: vm.criterioDeBusca\"><td><input type=checkbox ng-click=\"vm.aulaSelecionada = aula\"></td><td>{{aula.dataAula | date: \'dd/MM/yyyy\'}}</td></tr></table><button class=\"btn btn-danger\" ng-click=vm.delete(vm.aulaSelecionada) ng-disabled=!true>Excluir</button></div></div></div></div>");
$templateCache.put("./app/views/authentication/login.html","<div class=col-lg-2><h1 class=page-header>{{vm.title}}</h1><ol class=breadcrumb><li><i class=\"fa fa-home\"></i> <a ui-sref=home>Inicio</a></li><li class=active><i class=\"fa fa-user-md\"></i> Entrar</li></ol><div class=jumbotron><form name=vm.aulaForm class=jumbotron><input type=text class=form-control placeholder=Username data-ng-model=vm.loginData.userName required autofocus><br><input type=password class=form-control placeholder=Password data-ng-model=vm.loginData.password required><br><button class=\"btn btn-lg btn-default btn-block\" type=submit data-ng-click=vm.login()>Entrar</button><div data-ng-hide=\"vm.message == \'\'\" class=\"alert alert-danger\">{{vm.message}}</div></form></div></div>");
$templateCache.put("./app/views/authentication/signup.html","<div class=col-lg-2><h1 class=page-header>{{vm.title}}</h1><ol class=breadcrumb><li><i class=\"fa fa-home\"></i> <a ui-sref=home>Inicio</a></li><li class=active><i class=\"fa fa-sign-in\"></i> Cadastro</li></ol><div class=\"jumbotron class1\"><form name=vm.aulaForm class=jumbotron><input type=text class=form-control placeholder=\"First Name\" data-ng-model=vm.registration.firstName required autofocus><br><input type=text class=form-control placeholder=\"Last Name\" data-ng-model=vm.registration.lastName required><br><input type=text class=form-control placeholder=Username data-ng-model=vm.registration.userName required><br><input type=email class=form-control placeholder=Email data-ng-model=vm.registration.email required><br><input type=password class=form-control placeholder=Password data-ng-model=vm.registration.password required><br><input type=password class=form-control placeholder=\"Confirm Password\" data-ng-model=vm.registration.confirmPassword required><br><button class=\"btn btn-lg btn-default btn-block\" type=submit data-ng-click=vm.signUp()>Salvar</button><div data-ng-hide=\"vm.message == \'\'\" data-ng-class=\"(vm.savedSuccessfully) ? \'alert alert-success\' : \'alert alert-danger\'\">{{vm.message}}</div></form></div></div>");
$templateCache.put("./app/views/chamada/chamada.html","<div class=col-lg-8><h1 class=page-header>{{vm.title}}</h1><ol class=breadcrumb><li><i class=\"fa fa-home\"></i> <a ui-sref=home>Inicio</a></li><li class=active><i class=\"fa fa-check\"></i> Realizar Chamada</li></ol><form name=vm.chamadaForm class=jumbotron><select class=form-control ng-model=vm.chamada.turma ng-options=\"turma.descricao for turma in vm.turmas\" ng-click=vm.populateAulas(vm.chamada.turma) ng-disabled=!vm.turmas[0] ng-required=true ng-selected=\"vm.selected == true\"><option>Selecione a Turma</option></select><br><select class=form-control ng-model=vm.chamada.aula ng-options=\"aula.dataAula | date: \'dd/MM/yyyy\' for aula in vm.aulas\" ng-disabled=!vm.aulas[0] ng-click=vm.getChamada() ng-required=true><option>Selecione a aula de hoje</option></select><br><div ng-show=\"vm.chamadaForm.aula.$error.required && vm.chamadaForm.aula.$dirty\" class=\"alert alert-danger\">Por favor, selecione aula de hoje!</div><div ng-show=\"vm.turmaSelected && vm.aulas.length == 0\" class=\"alert alert-danger\">Essa turma não possui aulas cadastradas!</div><div ng-show=\"vm.turmaSelected && vm.aulaSelected && vm.alunos.length == 0\" class=\"alert alert-danger\">Essa turma não possui alunos cadastrados!</div><table class=table><tr><th>Presença</th><th>Alunos</th></tr><tr ng-repeat=\"aluno in vm.alunos\"><td><div class=switcher ng-class=\"{\'on\': aluno.status}\" ng-click=\"aluno.status = !aluno.status\"><div class=switcherHandler></div><input type=checkbox class=switcherInput ng-model=aluno.status></div></td><td><h4>{{aluno.nome}}</h4></td></tr></table><button class=\"btn btn-success\" ng-click=vm.save() ng-disabled=vm.chamadaForm.$invalid>Chamada Realizada!</button></form></div>");
$templateCache.put("./app/views/layout/home.html","<div id=page-wrapper><div class=\"container-fluid container-user\"><div class=row><div class=col-lg-10><h1>Diário</h1><h4><em>Academia do Programador</em></h4><hr><ol class=breadcrumb><li class=active><i class=\"fa fa-home\"></i> Início</li></ol><div class=\"panel panel-default\"><div class=panel-heading>Diario da Academia</div><div class=panel-body><div class=\"alert alert-primary\">Gerenciador da academia do programador. É possivel gerenciar:</div><ndd-panel title=Alunos icon=fa-users ui-sref=aluno.list></ndd-panel><ndd-panel title=Turmas icon=fa-university ui-sref=turma.list></ndd-panel><ndd-panel title=Aulas icon=fa-calendar ui-sref=aula.list></ndd-panel><ndd-panel title=Chamada icon=fa-check ui-sref=chamada.create></ndd-panel></div></div><div class=\"panel panel-default\"><div class=panel-heading>Sobre a academia do programador</div><div class=panel-body><div class=\"alert alert-success\"><strong>Objetivo do curso:</strong> É um curso que forma desenvolvedores para a empresa NDDigital. Anualmente a empresa garimpa talentos tanto para área de desenvolvimento como para outros setores da empresa.</div></div></div></div></div></div></div>");
$templateCache.put("./app/views/turma/turma-create.html","<div class=col-lg-8><h1 class=page-header>{{vm.title}}</h1><ol class=breadcrumb><li><i class=\"fa fa-home\"></i> <a ui-sref=home>Inicio</a></li><li class=active><i class=\"fa fa-university\"></i> Turmas</li></ol><div><form name=vm.turmaForm class=jumbotron><input class=form-control type=text value=\"Academia do Programador\" name=descricao ng-required=true ng-disabled=true><br><input class=form-control type=number value=2000 ng-model=vm.turma.ano name=ano ng-required=true ng-minlength=4 ng-maxlength=4><br><div ng-show=\"vm.turmaForm.ano.$error.required && vm.turmaForm.ano.$dirty\" class=\"alert alert-danger\">Por favor, preencha o campo ano com 4 números! (ex:2000)</div><button class=\"btn btn-primary\" ng-click=vm.save() ng-disabled=vm.turmaForm.$invalid>Salvar</button> <button class=\"btn btn-success\" ng-click=vm.clearFields() ng-disabled=!vm.turmaForm.ano.$dirty>Limpar</button></form></div></div>");
$templateCache.put("./app/views/turma/turma-details.html","<div class=col-lg-8><h1 class=page-header>{{vm.title}}</h1><ol class=breadcrumb><li><i class=\"fa fa-home\"></i> <a ui-sref=home>Inicio</a></li><li class=active><i class=\"fa fa-university\"></i> Turmas</li></ol><div><form name=vm.turmaForm class=jumbotron><input class=form-control type=text value=\"Academia do Programador\" name=descricao ng-required=true ng-disabled=true><br><input class=form-control type=number value=2000 ng-model=vm.turma.ano name=ano ng-required=true ng-disabled=false><br><div ng-show=\"vm.turmaForm.ano.$error.required && vm.turmaForm.ano.$dirty\" class=\"alert alert-danger\">Por favor, preencha o campo ano!</div><div ng-show=\"vm.turmaForm.ano.minlength && vm.alunoForm.ano.$error.$dirty\" class=\"alert alert-danger\">O campo ano deve ter 4 digitos!</div><button class=\"btn btn-primary\" ng-click=vm.save() ng-disabled=vm.turmaForm.$invalid>Salvar</button> <button class=\"btn btn-success\" ng-click=vm.clearFields()>Limpar</button></form></div></div>");
$templateCache.put("./app/views/turma/turma-list.html","<div class=col-lg-8><h1 class=page-header>{{vm.title}}</h1><ol class=breadcrumb><li><i class=\"fa fa-home\"></i> <a ui-sref=home>Inicio</a></li><li class=active><i class=\"fa fa-university\"></i> Turmas</li></ol><div><div class=jumbotron><div><input class=form-control type=text ng-model=vm.criterioDeBusca placeholder=\"O que você está procurando?\"><table class=table><tr><th></th><th>Descrição</th></tr><tr ng-class ng-repeat=\"turma in vm.turmas | filter: vm.criterioDeBusca\"><td><input type=checkbox ng-click=\"vm.turmaSelecionada = turma\"></td><td>{{turma.descricao}}</td></tr></table><a ui-sref=\"turma.details( { turmaId : vm.turmaSelecionada.id } )\"><button class=\"btn btn-info\">Editar {{vm.turmaSelecionada.nome}}</button></a> <button class=\"btn btn-danger\" ng-click=vm.delete(vm.turmaSelecionada) ng-disabled=!true>Excluir</button></div></div></div></div>");
$templateCache.put("./app/views/manager/group/manager-group-edit.html","<div class=\"container-user fadeIn enter-fadeIn\"><div class=row><h2 style=\"margin-top: 0;\">Permissões {{vm.group.name}}</h2><hr></div><div class=row><ndd-checkbox array=vm.permissions compare=vm.group.permissions callback=vm.save></ndd-checkbox></div></div>");
$templateCache.put("./app/views/manager/group/manager-group.html","<div class=\"col-sm-12 clear-padding\"><div class=container-user><div class=row><h1 class=page-header>Grupos</h1><ol class=breadcrumb><li><i class=\"fa fa-home\"></i> <a ui-sref=home>Inicio</a></li><li><i class=\"fa fa-wrench\"></i> <a style=\"cursor: pointer\">Gerenciador</a></li><li class=active><i class=\"fa fa-users\"></i> Grupos</li></ol></div><br></div></div><div class=\"col-sm-6 clear-padding\"><div class=container-user><div class=row><div class=\"col-sm-7 input-search\"><div class=input-group><div class=input-group-btn><button disabled type=button class=\"btn btn-default\" style=cursor:default;><i class=\"fa fa-search\"></i></button></div><input type=text class=\"form-control ng-pristine ng-valid ng-touched\" ng-model=nameFilter aria-label></div></div></div><br><div class=row><div class=col-sm-12 style=\"padding-left: 2%;\"><div class=list-group ng-repeat=\"group in vm.groups | filter: nameFilter\"><a style=\"cursor: pointer\" ng-click=vm.showGroup(group) class=list-group-item>{{group.name}}</a></div><input type=text class=form-control value ng-show=vm.creating ng-blur=vm.new() autofocus ng-model=vm.newGroup.name></div></div><div class=row><hr><div class=\"col-sm-12 text-center\"><button class=\"btn btn-success\" ng-click=\"vm.creating = !vm.creating\"><i class=\"fa fa-plus\"></i></button> <button class=\"btn btn-danger\" ng-click=vm.modal() data-toggle=modal data-target=#modelRemoveGroup ng-disabled=!vm.selectedGroup><i class=\"fa fa-times\"></i></button></div></div></div></div><div class=col-sm-6><div ui-view class=\"fader-animation container-group\"></div></div><ndd-modal target=modelRemoveGroup label={{vm.titleModelRemove}} callback=vm.remove>{{vm.bodyModelRemove}}</ndd-modal>");
$templateCache.put("./app/views/manager/permission/manager-permission.html","<div class=\"col-sm-12 clear-padding\"><div class=container-user><div class=row><h1 class=page-header>Permissões</h1><ol class=breadcrumb><li><i class=\"fa fa-home\"></i> <a ui-sref=home>Inicio</a></li><li><i class=\"fa fa-wrench\"></i> <a style=\"cursor: pointer\">Gerenciador</a></li><li class=active><i class=\"fa fa-users\"></i> Permissões</li></ol></div><br></div></div>");
$templateCache.put("./app/views/manager/user/manager-user-edit.html","<div class=row><div class=col-sm-4><i class=\"fa fa-3x fa-chevron-circle-left\" style=cursor:pointer ui-sref=manager.user></i></div><div class=col-sm-8>&nbsp;</div></div><div class=container-user><div class=row><h1 class=page-header>Edição de Usuário</h1><ol class=breadcrumb><li><i class=\"fa fa-home\"></i> <a ui-sref=home>Inicio</a></li><li><i class=\"fa fa-wrench\"></i> <a style=\"cursor: pointer\">Gerenciador</a></li><li class=active><i class=\"fa fa-user\"></i> <a ui-sref=manager.user>Usuario</a></li><li class=active><i class=\"fa fa-pencil\"></i> <a ui-sref=manager.useredit>Edição de Usuario</a></li></ol></div><br><div class=row><div class=\"col-sm-7 clear-padding\"><div class=\"col-xs-12 clear-padding\"><label for=fullname>Nome</label> <input type=text ng-model=vm.user.fullName class=form-control id=fullname><br></div><div class=\"col-xs-12 clear-padding\"><div class=\"col-xs-9 clear-padding\"><label for=username>Nome de usuário</label> <input type=text ng-model=vm.user.userName class=form-control id=username></div><div class=\"col-xs-3 clear-padding\"><label for=level>Level</label> <input type=number ng-model=vm.user.level class=form-control id=level></div></div></div><div class=\"col-sm-5 text-center\"><label>Grupos</label><ndd-checkbox array=vm.groups compare=vm.user.groups callback></ndd-checkbox></div><div class=\"col-sm-12 clear-padding text-center\" style=\"padding-top: 5%;\"><div class=footer><button class=\"btn btn-success\" data-toggle=modal data-target=#modelEditUser><i class=\"fa fa-user-plus fa-2x\"></i></button> <button class=\"btn btn-info\" ng-click=vm.clear()><i class=\"fa fa-undo fa-2x\"></i></button></div></div></div></div><ndd-modal target=modelEditUser label={{vm.titleModelEdit}} callback=vm.editUser>{{vm.bodyModelEdit}}</ndd-modal>");
$templateCache.put("./app/views/manager/user/manager-user-list.html","<div class=container-user><div class=row><h1 class=page-header>{{vm.title}}</h1><ol class=breadcrumb><li><i class=\"fa fa-home\"></i> <a ui-sref=home>Inicio</a></li><li><i class=\"fa fa-wrench\"></i> <a style=\"cursor: pointer\">Gerenciador</a></li><li class=active><i class=\"fa fa-user\"></i>Usuario</li></ol></div><br><div class=row><div class=col-md-5 style=\"padding-left: 0\"><div class=input-group><div class=input-group-btn><button disabled type=button class=\"btn btn-default\" style=cursor:default;><i class=\"fa fa-search\"></i></button></div><input type=text class=\"form-control ng-pristine ng-valid ng-touched\" ng-model=nameFilter aria-label></div><div class=col-md-7>&nbsp;</div></div></div><br><div class=row><table class=\"table table-hover table-responsive table-condensed\"><thead><tr><th>Usuario</th><th>Login</th><th>Email</th><th>Level</th><th>Data de Inscrição</th><th>&nbsp;</th><th>&nbsp;</th></tr></thead><tbody><tr ng-repeat=\"user in vm.users | filter: nameFilter\"><td>{{user.fullName}}</td><td>{{user.userName}}</td><td>{{user.email}}</td><td>{{user.level}}</td><td>{{user.joinDate | date:\'dd/MM/yyyy\'}}</td><td class=text-right><button class=\"btn btn-info\" ng-click=vm.edit(user)><i class=\"fa fa-pencil-square-o\"></i></button></td><td><button class=\"btn btn-danger\" ng-click=vm.modal(user) data-toggle=modal data-target=#modelRemoveUser><i class=\"fa fa-user-times\"></i></button></td></tr></tbody></table><pagination ng-model=vm.currentPage total-items=vm.countUsers max-size=vm.maxSize boundary-links=true></pagination></div></div><ndd-modal target=modelRemoveUser label={{vm.titleModelRemove}} callback=vm.remove>{{vm.bodyModelRemove}}</ndd-modal>");}]);