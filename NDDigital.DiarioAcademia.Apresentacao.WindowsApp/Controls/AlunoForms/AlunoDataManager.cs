using Infrastructure.DAO.ORM.Common;
using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.Shared;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.IoC;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories;
using System;
using System.Windows.Forms;

namespace NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.AlunoForms
{
    public class AlunoDataManager : DataManager
    {
        private IAlunoService _alunoService;
        private ITurmaService _turmaService;

        private AlunoControl _control;

        public AlunoDataManager() //TODO: IOC
        {
            var factory = new EntityFrameworkFactory();//Container.Get<UnitOfWorkFactory>();

            var unitOfWork = new EntityFrameworkUnitOfWork(factory);//Container.Get<IUnitOfWork>();

            var alunoRepository = new AlunoRepositoryEF(factory); ;//Container.Get<IAlunoRepository>();

            var turmaRepository = Container.Get<ITurmaRepository>();

            _turmaService = new TurmaService(turmaRepository, unitOfWork);

            _alunoService = new AlunoService(alunoRepository, turmaRepository, unitOfWork);

            _control = new AlunoControl(_alunoService);
        }

        public override void AddData()
        {
            var turmas = _turmaService.GetAll();

            var dialog = new AlunoDialog(turmas);

            dialog.Aluno = new AlunoDTO();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _alunoService.Add(dialog.Aluno);

                _control.RefreshGrid();
            }
        }

        public override void UpdateData()
        {
            AlunoDTO aluno = _control.GetAluno();

            if (aluno == null)
            {
                MessageBox.Show("Nenhum aluno selecionado. Selecionar um aluno antes de solicitar a edição");
                return;
            }

            var turmas = _turmaService.GetAll();

            var dialog = new AlunoDialog(turmas);

            dialog.Aluno = aluno;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _alunoService.Update(dialog.Aluno);
                _control.RefreshGrid();
            }
        }

        public override void DeleteData()
        {
            AlunoDTO aluno = _control.GetAluno();

            if (aluno == null)
            {
                MessageBox.Show("Nenhum aluno selecionado. Selecionar um aluno antes de solicitar a exclusão");
                return;
            }

            if (MessageBox.Show("Deseja remover o aluno selecionado?", "", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                try
                {
                    _alunoService.Delete(aluno.Id);

                    _control.RefreshGrid();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public override UserControl GetControl()
        {
            if (_control != null)
                _control.RefreshGrid();

            return _control;
        }

        public override string GetDescription()
        {
            return "Cadastro de Alunos";
        }

        public override ToolTipMessage GetToolTipMessage()
        {
            return new ToolTipMessage
            {
                Add = "Adiciona um novo aluno",
                Delete = "Exclui o aluno selecionado",
                Edit = "Atualiza o aluno selecionado",
                RegistraPresenca = "Registra presenças",
                Report = "Gera relatório de alunos"
            };
        }

        public override StateButtons GetStateButtons()
        {
            return new StateButtons
            {
                Add = true,
                Delete = true,
                Update = true,
                Report = true
            };
        }
    }
}