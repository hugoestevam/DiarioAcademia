
var DiarioAcademia = DiarioAcademia || {};
(function (ns) {

    ns.Turma = function (ano,nome) {
        this.id = ++ns.Turma.id;
        this.ano = ano;
        this.nome = nome;
    };
    ns.Turma.id = 0;

})(DiarioAcademia);