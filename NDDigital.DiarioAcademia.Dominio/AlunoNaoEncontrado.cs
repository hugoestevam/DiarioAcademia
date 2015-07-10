using System;

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