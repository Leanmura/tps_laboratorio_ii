using System;

namespace Excepciones
{
    /// <summary>
    /// Se lanza cuando el archivo no es correcto
    /// </summary>
    public class IncorrectFileException : Exception
    {
        public IncorrectFileException(string mensaje)
            : base(mensaje)
        {

        }
    }
}
