using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.AulaForms
{
    public partial class PresencaDialog : Form
    {

        private RegistroPresencaDTO _registroPresenca;

        public RegistroPresencaDTO RegistroPresenca
        {
            get { return _registroPresenca; }
            set 
            {
                _registroPresenca = value;

                labelData.Text = _registroPresenca.DataAula.ToString("dd/MM/yyyy");

                labelAnoTurma.Text = _registroPresenca.AnoTurma.ToString();
            }
        }

        public PresencaDialog(List<AlunoDTO> alunos)
        {
            InitializeComponent();

            listAlunos.Items.Clear();

            for (int i = 0; i < alunos.Count(); i++)
            {
                AlunoDTO aluno = alunos[i];

                listAlunos.Items.Add(aluno);

                //listAlunos.SetItemCheckState(i, item.EstaFechado() ? CheckState.Checked : CheckState.Unchecked);
            }            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
        }

    }
}
