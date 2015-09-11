namespace NDDigital.DiarioAcademia.WebApi.Filters
{
    public static class Claim
    {
        #region Aluno

        public const string Aluno =
              Aluno_List
            + Aluno_Details
            + Aluno_Create;

        public const string Aluno_List = ".02";
        public const string Aluno_Details = ".03";
        public const string Aluno_Create = ".04";

        #endregion Aluno

        #region Aluno

        public const string Aula =
              Aula_List
            + Aula_Create;

        public const string Aula_List = ".05";
        public const string Aula_Create = ".06";

        #endregion Aluno

        #region Chamada

        public const string Chamada =
              Chamada_Create;

        public const string Chamada_Create = ".09";

        #endregion Chamada

        #region Manager

        public const string Manager =
              Manager_User
            + Manager_Group
            + Manager_Permission;

        #region User

        public const string Manager_User =
            Manager_User_List
            + Manager_User_Edit
            + Manager_User_Group_Edit;

        public const string Manager_User_List = ".10";
        public const string Manager_User_Edit = ".11";
        public const string Manager_User_Group_Edit = ".12";

        #endregion User

        #region Group

        public const string Manager_Group =
            Manager_Group_List
            + Manager_Group_Edit
            + Manager_Group_Permission_Edit;

        public const string Manager_Group_List = ".13";
        public const string Manager_Group_Edit = ".14";
        public const string Manager_Group_Permission_Edit = ".15";

        #endregion Group

        #region Group

        public const string Manager_Permission =
            Manager_Permission_List;

        public const string Manager_Permission_List = ".16";

        #endregion Group

        #endregion Manager

        #region Turma

        public const string Turma =
              Turma_List
            + Turma_Details
            + Turma_Create;

        public const string Turma_List = ".17";
        public const string Turma_Details = ".18";
        public const string Turma_Create = ".19";

        #endregion Turma

        #region Custom

        public const string Custom =
              Custon_Excluir_Aluno
            + Custon_Adicionar_Turma;

        public const string Custon_Excluir_Aluno = ".20";
        public const string Custon_Adicionar_Turma = ".21";

        #endregion Custom
    }
}