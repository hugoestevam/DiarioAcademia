using System;
using System.Runtime.Serialization;

namespace NDDigital.DiarioAcademia.Dominio.Exceptions
{
    [Serializable]
    public class TurmaException : Exception
    {
        public TurmaException(string message)
            : base(message)
        {
        }
    }
}