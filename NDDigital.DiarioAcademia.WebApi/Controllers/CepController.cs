using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.CepServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NDDigital.DiarioAcademia.WebApi.Controllers
{
    public class CepController : ApiController
    {

        // GET: api/Cep/5
        public Endereco Get(string id)
        {
            var _webService = new CepWebService();

            return _webService.PreencheEndereco(id);
        }
    }
}
