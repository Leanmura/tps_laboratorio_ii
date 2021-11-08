using System;
using System.IO;
using Excepciones;

namespace IO
{
    public abstract class Archivo
    {
        protected abstract string Extension { get;  }

        /// <summary>
        /// Valida si el archivo existe
        /// </summary>
        /// <param name="ruta"> Ruta del archivo </param>
        /// <returns> Retorna true en caso de ser valido, sino arroja una IncorrectFileExcepction</returns>
        public bool ValidarArchivo(string ruta)
        {
            if (!File.Exists(ruta))
            {
                throw new IncorrectFileException("El archivo no se encontró.");
            }

            return true;
        }

        /// <summary>
        /// Valida la extension del archivo
        /// </summary>
        /// <param name="ruta"> Ruta del archivo </param>
        /// <returns> Retorna true en caso de ser valido, sino arroja una IncorrectFileExcepction</returns>
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
