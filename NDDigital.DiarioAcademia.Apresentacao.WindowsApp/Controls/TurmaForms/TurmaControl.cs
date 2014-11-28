using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Aplicacao.DTOs;

namespace NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.TurmaForms
{
    public partial class TurmaControl : UserControl
    {
        private Aplicacao.Services.ITurmaService _turmaService;

        public TurmaControl()
        {
            InitializeComponent();
        }       

        public TurmaControl(ITurmaService turmaService) : this()
        {
            _turmaService = turmaService;
        }

        public void RefreshGrid()
        {
            var turmas = _turmaService.GetAll();

            listTurmas.Items.Clear();

            foreach (var turma in turmas)
            {
                listTurmas.Items.Add(turma);
            }
        }

        public TurmaDTO GetTurma()
        {
            TurmaDTO turmaSelecionada = listTurmas.SelectedItem as TurmaDTO;

            return turmaSelecionada;
        }
    }
}
