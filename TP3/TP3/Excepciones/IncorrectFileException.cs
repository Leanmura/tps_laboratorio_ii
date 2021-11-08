using System;

namespace Excepciones
{
    public class IncorrectFileException : Exception
    {
        public IncorrectFileException(string mensaje)
            : base(mensaje)
        {

        }
    }
}
