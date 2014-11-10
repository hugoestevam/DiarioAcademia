using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.WebServices.br.com.correios.ws;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Infraestrutura.WebServices
{
    public class EnderecoRepository : IEnderecoRepository
    {
        public Endereco GetEnderecoByCep(string cep)
        {
            //faz a chamada no web services                   

            //converte o xml em um objeto Endereco

            //e retorna o objeto
            return new Endereco();
        }
    }
}
