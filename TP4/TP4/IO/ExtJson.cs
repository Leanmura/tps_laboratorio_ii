using System;
using System.IO;
using System.Text.Json;

namespace IO
{
    public class ExtJson<T> : Archivo, IArchivo<T>
            where T : class
    {
        protected override string Extension
        {
            get
            {
                return ".json";
            }
        }

        public void Guardar(string ruta, T contenido)
        {
            if (ValidarArchivo(ruta) && ValidarExtension(ruta))
            {
                Serializar(ruta, contenido);
            }
        }

        public void GuardarComo(string ruta, T contenido)
        {
            if (ValidarExtension(ruta))
            {
                Serializar(ruta, contenido);
            }
        }

        private void Serializar(string ruta, T contenido)
        {
            using (StreamWriter streamWriter = new StreamWriter(ruta))
            {
                string json = JsonSerializer.Serialize(contenido);
                streamWriter.Write(json);
            }
        }

        public T Leer(string ruta)
        {
            T retorno = null;
            if (ValidarArchivo(ruta) && ValidarExtension(ruta))
            {
                using (StreamReader streamReader = new StreamReader(ruta))
                {
                    string json = streamReader.ReadToEnd(); 
                        retorno = JsonSerializer.Deserialize<T>(json);
                }
            }

            return retorno;
        }
    }
}
