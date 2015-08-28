using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
