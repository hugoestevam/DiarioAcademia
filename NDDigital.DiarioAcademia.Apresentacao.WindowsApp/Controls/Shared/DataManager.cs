using System;
using System.Windows.Forms;

namespace NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.Shared
{
    public abstract class DataManager
    {
        /// <summary>
        /// É responsável por chamar o diálogo de inserção, caso o usuário confirme o cadastro clicando em ok,
        /// esta função chama o método na camada de serviço responsável pela inserção de um novo registro.
        /// Este método é chamado no formulário Principal, dentro do evento btnAdd_click
        /// </summary>
        public abstract void AddData();

        /// <summary>
        /// É responsável por chamar o diálogo de exclusão, caso o usuário confirme clicando em ok,
        /// esta função chama o método na camada de serviço responsável pela exclusão de um registro existente na base de dados.
        /// Este método é chamado no formulário Principal, dentro do evento btnDelete_Click
        /// </summary>
        public abstract void DeleteData();

        /// <summary>
        /// É responsável por chamar o diálogo de atualização, caso o usuário confirme clicando em ok,
        /// esta função chama o método na camada de serviço responsável pela alteração das informações de um registro 
        /// existente na base de dados.
        /// Este método é chamado no formulário Principal, dentro do evento btnEdit_Click
        /// </summary>
        public abstract void UpdateData();

        /// <summary>
        /// É responsável por chamar o diálogo de exclusão, caso o usuário confirme clicando em ok,
        /// esta função chama o método na camada de serviço responsável pela exclusão de um registro existente na base de dados.
        /// Este método é chamado no formulário Principal, dentro do evento btnDelete_Click
        /// </summary>
        public abstract UserControl GetControl();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract string GetDescription();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract ToolTipMessage GetToolTipMessage();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract StateButtons GetStateButtons();


        /// <summary>
        /// 
        /// </summary>
        public virtual void RegistraPresenca() {  }


    }
}