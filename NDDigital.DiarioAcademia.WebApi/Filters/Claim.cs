namespace NDDigital.DiarioAcademia.WebApi.Filters
{
    public static class Claim
    {
        #region Aluno

        public const string Aluno = ".02"
            +  Aluno_List
            + Aluno_Details
            + Aluno_Create;

        public const string Aluno_List = ".03";
        public const string Aluno_Details = ".04";
        public const string Aluno_Create = ".05";

        #endregion Aluno

        #region Aula

        public const string Aula = ".06"
            + Aula_List
            + Aula_Create;

        public const string Aula_List = ".07";
        public const string Aula_Create = ".08";

        #endregion Aula

        #region Chamada

        public const string Chamada =
              Chamada_Create;

        public const string Chamada_Create = ".11";

        #endregion Chamada

        #region Manager

        public const string Manager = ".12"
            + Manager_User
            + Manager_Group
            + Manager_Permission;

        #region User

        public const string Manager_User =
            Manager_User_List
            + Manager_User_Edit
            + Manager_User_Group_Edit;

        public const string Manager_User_List = ".13";
        public const string Manager_User_Edit = ".14";
        public const string Manager_User_Group_Edit = ".15";

        #endregion User

        #region Group

        public const string Manager_Group =
            Manager_Group_List
            + Manager_Group_Edit
            + Manager_Group_Permission_Edit;

        public const string Manager_Group_List = ".16";
        public const string Manager_Group_Edit = ".17";
        public const string Manager_Group_Permission_Edit = ".18";

        #endregion Group

        #region Group

        public const string Manager_Permission =
            Manager_Permission_List;

        public const string Manager_Permission_List = ".19";

        #endregion Group

        #endregion Manager

        #region Turma

        public const string Turma = ".20"
            + Turma_List
            + Turma_Details
            + Turma_Create;

        public const string Turma_List = ".21";
        public const string Turma_Details = ".22";
        public const string Turma_Create = ".23";

        #endregion Turma

        #region Custom

        public const string Custom =
              Custon_Excluir_Aluno
            + Custon_Delete_Turma;

        public const string Custon_Excluir_Aluno = ".24";
        public const string Custon_Delete_Turma = ".25";

        #endregion Custom
    }
}