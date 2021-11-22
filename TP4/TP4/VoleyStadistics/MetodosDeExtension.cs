using Entidades;
using System.Collections.Generic;

namespace FormVoleyStadistics
{
    public static class MetodosDeExtension
    {
        /// <summary>
        /// Determina la cantidad de clubes que son de X pais
        /// </summary>
        /// <param name="c"></param>
        /// <param name="pais"> pais del cual queremos calcular la cantidad de clubes</param>
        /// <param name="listaClubes"> lista de clubes la cual vamos a examinar</param>
        /// <returns> retorna la cantidad de apariciones </returns>
        public static int CantClubesPais(this Club c, EPais pais, List<Club> listaClubes)
        {
            int cantidad = 0;
            foreach (Club item in listaClubes)
            {
                if (item.Localidad == pais)
                {
                    cantidad++;
                }
            }
            return cantidad;
        }

        /// <summary>
        /// Determina la cantidad de jugadores que hay en X posicion en tal club
        /// </summary>
        /// <param name="c"></param>
        /// <param name="posicion"> posicion que queremos evaluar </param>
        /// <param name="indiceClub"> indice del club que queremos buscar</param>
        /// <param name="listaClubes"> lista de clubes en la cual vamos a buscar </param>
        /// <returns> retorna la cantidad de apariciones </returns>
        public static int CantJugadoresPosicionClub(this Club c, EPosicion posicion, int indiceClub, List<Club> listaClubes)
        {
            int cantidad = 0;
            Club club = listaClubes[indiceClub];
            foreach (JugadorDeVoley item in club.listaDeJugadores)
            {
                if (item.Posicion == posicion)
                {
                    cantidad++;
                }
            }
            return cantidad;
        }

        /// <summary>
        /// Determina la cantidad de jugadores extranjeros que hay en X club
        /// </summary>
        /// <param name="c"></param>
        /// <param name="indiceClub"> indice del club que queremos averiguar</param>
        /// <param name="listaClubes"> lista de lois clubes </param>
        /// <returns> retorna la cantidad de apariciones </returns>
        public static int CantJugadoresExtranjerosClub(this Club c, int indiceClub, List<Club> listaClubes)
        {
            int cantidad = 0;
            Club club = listaClubes[indiceClub];
            EPais localidadClub = club.Localidad;
            foreach (JugadorDeVoley item in club.listaDeJugadores)
            {
                if (item.PaisDeNacimiento != localidadClub)
                {
                    cantidad++;
                }
            }
            return cantidad;
        }
    }
}
