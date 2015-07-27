using System;

namespace NDDigital.DiarioAcademia.Dominio.Exceptions
{
    public class AulaNaoEncontrada : ApplicationException
    {
        public AulaNaoEncontrada(string msg)
            : base(msg)
        {
        }
    }
}