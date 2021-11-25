namespace IO
{
    /// <summary>
    /// Implementacion de generics e interfaz para el manejo de la serializacion de archvios .xml y .json
    /// </summary>
    /// <typeparam name="T"> generic </typeparam>
    public interface IArchivo<T>
    {
        void Guardar(string ruta, T contenido);
        void GuardarComo(string ruta, T contenido);
        T Leer(string ruta);
    }
}
