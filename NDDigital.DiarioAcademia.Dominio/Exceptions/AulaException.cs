using System;
using System.Runtime.Serialization;

namespace NDDigital.DiarioAcademia.Dominio.Exceptions
{
    [Serializable]
    public class AulaException : ApplicationException
    {
        public AulaException(string msg)
            : base(msg)
        {
        }
    }
}