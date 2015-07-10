using System;

namespace NDDigital.DiarioAcademia.Dominio
{
    public class AulaNaoEncontrada : ApplicationException
    {
        public AulaNaoEncontrada(string msg)
            : base(msg)
        {
        }
    }
}