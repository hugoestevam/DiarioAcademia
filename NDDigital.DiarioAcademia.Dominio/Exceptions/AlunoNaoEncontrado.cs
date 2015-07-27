using System;

namespace NDDigital.DiarioAcademia.Dominio.Exceptions
{
    public class AlunoNaoEncontrado : ApplicationException
    {
        public AlunoNaoEncontrado(string msg)
            : base(msg)
        {
        }
    }
}