using System;
using System.IO;
using Excepciones;

namespace IO
{
    public abstract class Archivo
    {
        protected abstract string Extension { get;  }

        public bool ValidarArchivo(string ruta)
        {
            if (!File.Exists(ruta))
            {
                throw new IncorrectFileException("El archivo no se encontró.");
            }

            return true;
        }

        public bool ValidarExtension(string ruta)
        {
            if (Path.GetExtension(ruta) != this.Extension)
            {
                throw new IncorrectFileException($"El archivo no tiene la extensión {this.Extension}.");
            }

            return true;
        }
    }
}
