
namespace NDDigital.DiarioAcademia.Aplicacao.Services.Security
{
    public interface IAuthorizationService
    {
        void AddPermissionsToGroup(int id, string[] permissions);

        void RemovePermissionsFromGroup(int id, string[] permissions);

        void AddGroupToUser(string username, int[] groups);

        void RemoveGroupFromUser(string username, int[] groups);

    }
}
