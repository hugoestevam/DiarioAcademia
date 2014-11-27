using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDDigital.DiarioAcademia.Dominio
{
    public class AlunoNaoEncontrado : ApplicationException
    {
        public AlunoNaoEncontrado(string msg) 
            : base(msg)
        {

        }
    }
}
