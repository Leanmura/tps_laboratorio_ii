using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Equipo
    {
        #region Atributos
        private string nombre;
        public List<JugadorDeVoley> listaDeJugadores;
        public static int cantidadMaximaDeJugadores;
        //private Entrenador entrenador;

        #endregion

        #region Propiedades
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                value = Equipo.ValidarEquipo(value);
                this.nombre = value;
            }
        }

        //public Entrenador Entrenador
        //{
        //    get
        //    {
        //        return this.entrenador;
        //    }
        //    set
        //    {
        //        if(value is not null)
        //        {
        //            this.entrenador = value;
        //        }
        //        else
        //        {
        //            throw new NullReferenceException();
        //        }
        //    }
        //}

        #endregion

        #region Constructor
        static Equipo()
        {
            Equipo.cantidadMaximaDeJugadores = 14;
        }

        public Equipo()
        {
            this.listaDeJugadores = new List<JugadorDeVoley>();
        }

        protected Equipo(string nombre) : this()
        {
            this.nombre = nombre;
            //this.entrenador = entrenador;
        }
        #endregion

        #region Metodos

        public abstract bool AgregarJugador(JugadorDeVoley jugador);

        /// <summary>
        /// Determina si un equipo contiene a X jugador
        /// </summary>
        /// <param name="jugador"> Jugador que queremos buscar</param>
        /// <returns> Retorna True si esta en el equipo, sino False</returns>
        public bool Contains(JugadorDeVoley jugador)
        {
            bool retorno = false;
            if (this.listaDeJugadores.Contains(jugador))
            {
                retorno = true;
            }
            return retorno;
        }


        /// <summary>
        /// Valida que no sea null o vacio, Sino arroja una excepcion.
        /// </summary>
        /// <param name="value"> Palabra a validar </param>
        /// <returns> Palabra valida formateada </returns>
        protected static string ValidarEquipo(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("La palabra contiene simbolos, espacios o esta vacia."); // cambiar por eventos
            }
            return value;
        }

        /// <summary>
        /// Valida que sea un numero del enumerado EPais. Sino arroja una excepcion.
        /// </summary>
        /// <param name="value"> Valor a validar</param>
        protected static void ValidarPais(EPais value)
        {
            if (!((int)value >= 0 && (int)value <= 8))
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        #endregion

        #region Sobrecargas

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Nombre: "+ this.Nombre);
            //sb.AppendLine("Entrenador: " + this.Entrenador.ToString());
            sb.AppendLine("Lista de jugadores: " );

            foreach (JugadorDeVoley item in this.listaDeJugadores)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        #endregion


    }
}
