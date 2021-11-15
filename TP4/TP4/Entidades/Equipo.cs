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
        protected static int cantidadMaximaDeJugadores;
        private Entrenador entrenador;

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
                this.nombre = value;
            }
        }
        public Entrenador Entrenador
        {
            get
            {
                return this.entrenador;
            }
            set
            {
                if(value is not null)
                {
                    this.entrenador = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

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

        protected Equipo(string nombre,  Entrenador entrenador): this()
        {
            this.Nombre = nombre;
            this.Entrenador = entrenador;
        }
        #endregion

        #region Metodos

        public abstract bool AgregarJugador(JugadorDeVoley jugador);
        #endregion
        
        #region Sobrecargas
        /// <summary>
        /// Determina si un jugador esta en un equipo
        /// </summary>
        /// <param name="equipo"> Equipo donde queremos buscar</param>
        /// <param name="jugador"> Jugador que queremos buscar</param>
        /// <returns> Retorna True si esta en el equipo, sino False</returns>
        public static bool operator ==(Equipo equipo, JugadorDeVoley jugador)
        {
            bool retorno = false;
            if(equipo.listaDeJugadores.Contains(jugador))
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Equipo equipo, JugadorDeVoley jugador)
        {
            return !(equipo == jugador);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Nombre: "+this.Nombre);
            sb.AppendLine("Entrenador: " + this.Entrenador.ToString());
            sb.AppendLine("Lista de jugadores: " );

            foreach (JugadorDeVoley item in this.listaDeJugadores)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion


    }
}
