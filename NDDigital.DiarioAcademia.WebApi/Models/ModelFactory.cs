using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using System;
using System.Collections.Generic;

using System.Net.Http;

using System.Web.Http.Routing;

namespace NDDigital.DiarioAcademia.WebApi.Models
{
    public class ModelFactory
    {
        private UrlHelper _UrlHelper;
        private UserRepository _UserRepository;

        public ModelFactory(HttpRequestMessage request, UserRepository appUserManager)
        {
            _UrlHelper = new UrlHelper(request);
            _UserRepository = appUserManager;
        }

        public UserReturnModel Create(User appUser)
        {
            return new UserReturnModel
            {
                Url = _UrlHelper.Link("GetUserById", new { id = appUser.Id }),
                Id = appUser.Id,
                UserName = appUser.UserName,
                FullName = string.Format("{0} {1}", appUser.FirstName, appUser.LastName),
                Email = appUser.Email,
                EmailConfirmed = appUser.EmailConfirmed,
                Level = appUser.Level,
                Roles = _UserRepository.GetRolesAsync(appUser.Id).Result,
                Claims = _UserRepository.GetClaimsAsync(appUser.Id).Result
            };
        }

        public class UserReturnModel
        {
            public string Url { get; set; }
            public string Id { get; set; }
            public string UserName { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public bool EmailConfirmed { get; set; }
            public int Level { get; set; }
            public DateTime JoinDate { get; set; }
            public IList<string> Roles { get; set; }
            public IList<System.Security.Claims.Claim> Claims { get; set; }
        }
    }
}