using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace IO
{
    public class ExtTxt : Archivo, IArchivo<string>
    {
        protected override string Extension
        {
            get
            {
                return ".txt";
            }
        }

        public void Guardar(string ruta, string contenido)
        {
            if (ValidarArchivo(ruta) && ValidarExtension(ruta))
            {
                GuardarArchivo(ruta, contenido);
            }
        }

        public void GuardarComo(string ruta, string contenido)
        {
            if (ValidarExtension(ruta))
            {
                GuardarArchivo(ruta, contenido);
            }
        }

        private void GuardarArchivo(string ruta, string contenido)
        {
            using (StreamWriter streamWriter = new StreamWriter(ruta))
            {
                streamWriter.WriteLine(contenido);
            }
        }

        public string Leer(string ruta)
        {
            string retorno = string.Empty;
            if (ValidarArchivo(ruta) && ValidarExtension(ruta))
            {
                using (StreamReader streamReader = new StreamReader(ruta))
                {
                    retorno = streamReader.ReadToEnd();
                }
            }

            return retorno;
        }
    }
}

