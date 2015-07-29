using System;
using System.Runtime.Serialization;

namespace NDDigital.DiarioAcademia.Dominio.Exceptions
{
    [Serializable]
    public class PresencaException : System.Exception
    {
        public PresencaException(string message) 
            : base(message)
        {
        }
    }
}