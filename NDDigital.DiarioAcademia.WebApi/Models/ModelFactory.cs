using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Repositories;
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
            };
        }

        public class UserReturnModel
        {
            public string Url { get; set; }
            public string Id { get; set; }
            public string UserName { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public bool IsAdmin { get; set; }

            public IList<Permission> Permissions { get; set; }
        }
    }
}