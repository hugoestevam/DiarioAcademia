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
    public partial class ChamadaDialog : Form
    {

        private ChamadaDTO _chamada;

        public ChamadaDTO Chamada
        {
            get { return _chamada; }
            set 
            {
                _chamada = value;

                labelData.Text = _chamada.Data.ToString("dd/MM/yyyy");

                labelAnoTurma.Text = _chamada.AnoTurma.ToString();

                listAlunos.Items.Clear();

                for (int i = 0; i < _chamada.Alunos.Count(); i++)
                {
                    ChamadaAlunoDTO aluno = _chamada.Alunos[i];

                    listAlunos.Items.Add(aluno);

                    listAlunos.SetItemCheckState(i, aluno.Status == "C" ? CheckState.Checked : CheckState.Unchecked);
                }
            }
        }

        public ChamadaDialog()
        {
            InitializeComponent();                   
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
        }

        private void listAlunos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var items = listAlunos.Items;

            ChamadaAlunoDTO itemSelecionado = _chamada.Alunos[e.Index];
            
            itemSelecionado.Status = e.NewValue == CheckState.Checked ? "C" : "F";
        }

    }
}