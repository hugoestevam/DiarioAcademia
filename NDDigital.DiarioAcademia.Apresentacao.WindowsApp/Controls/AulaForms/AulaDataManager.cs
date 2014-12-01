using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.Shared;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uniplac.Sindicontrata.Infraestrutura.AcessoDadosRepositories;

namespace NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.AulaForms
{
    public class AulaDataManager : DataManager
    {
        private IAulaService _aulaService;

        private ITurmaService _turmaService;                       

        private AlunoService _alunoService;

        private AulaControl _control;

        public AulaDataManager()
        {
            var factory = new DatabaseFactory();

            var unitOfWork = new UnitOfWork(factory);

            var aulaRepository = new AulaRepository(factory);

            var turmaRepository = new TurmaRepository(factory);

            var alunoRepository = new AlunoRepository(factory);

            _aulaService = new AulaService(aulaRepository, alunoRepository, turmaRepository, unitOfWork);

            _alunoService = new AlunoService(alunoRepository, turmaRepository, unitOfWork);

            _turmaService = new TurmaService(turmaRepository, unitOfWork);
           
            _control = new AulaControl(_aulaService);
        }

        public override void AddData()
        {
            var turmas = _turmaService.GetAll();

            var dialog = new AulaDialog(turmas);

            dialog.Aula = new AulaDTO();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _aulaService.Add(dialog.Aula);

                _control.RefreshGrid();
            }
        }

        public override void UpdateData()
        {
            AulaDTO aulaSelecionada = _control.GetAulaSelecionada();

            if (aulaSelecionada == null)
            {
                MessageBox.Show("Nenhuma Aula selecionada. Selecionar uma Aula antes de solicitar a edição");
                return;
            }

            var turmas = _turmaService.GetAll();

            var dialog = new AulaDialog(turmas);

            dialog.Aula = aulaSelecionada;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _aulaService.Update(dialog.Aula);

                _control.RefreshGrid();
            }
        }

        public override void DeleteData()
        {
            AulaDTO aulaSelecionada = _control.GetAulaSelecionada();

            if (aulaSelecionada == null)
            {
                MessageBox.Show("Nenhuma Aula selecionada. Selecionar uma Aula antes de solicitar a exclusão");
                return;
            }

            if (MessageBox.Show("Deseja remover a Aula selecionada?", "", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                try
                {
                    _aulaService.Delete(aulaSelecionada.Id);

                    _control.RefreshGrid();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public override void RegistraPresenca()
        {
            AulaDTO aulaSelecionada = _control.GetAulaSelecionada();

            if (aulaSelecionada == null)
            {
                MessageBox.Show("Nenhuma Aula selecionada. Selecionar uma Aula antes para Registrar a presença dos alunos");
                return;
            }

            var turma = _turmaService.GetById(aulaSelecionada.TurmaId);

            var alunos = _alunoService.GetAllByTurma(turma.Ano);
          
            var dialog = new PresencaDialog(alunos);

            var presencas = new RegistroPresencaDTO();
            presencas.AnoTurma = turma.Ano;
            presencas.DataAula = aulaSelecionada.Data;

            dialog.RegistroPresenca = presencas;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _aulaService.RegistraPresenca(presencas);
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
            return "Cadastro de Aulas";
        }

        public override ToolTipMessage GetToolTipMessage()
        {
            return new ToolTipMessage
            {
                Add = "Adiciona uma nova Aula",
                Delete = "Exclui a Aula selecionada",
                Edit = "Atualiza a Aula selecionada",
                RegistraPresenca = "Registra presença dos alunos na aula selecionda"
            };
        }

        public override StateButtons GetStateButtons()
        {
            return new StateButtons
            {
                Add = true,
                Delete = true,
                Update = true,
                RegistraPresenca=true
            };
        }
    }
}
