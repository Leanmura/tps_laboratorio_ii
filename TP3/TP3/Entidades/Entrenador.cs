using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Entrenador: Persona
    {
        #region Atributos
        private bool isExJugador;
        private int idEntrenador;
        private static int nextId;

        #endregion

        #region Propiedades
        public static int NextId
        {
            get { return Entrenador.nextId + 1; }
        }
        public int IdEntrenador
        {
            get
            {
                return this.idEntrenador;
            }
            set
            {
                this.idEntrenador = value;
            }
        }
        public bool IsExJugador
        {
            get
            {
                return this.isExJugador;
            }
            set
            {
                this.isExJugador = value;
            }
        }
        #endregion


        #region Constructor
        public Entrenador():base()
        {

        }
        public Entrenador(string nombre, string apellido, EPais paisDeNacimiento, DateTime fechaNacimiento)
             : base(nombre, apellido, paisDeNacimiento, fechaNacimiento)
        {
            this.IdEntrenador = Interlocked.Increment(ref Entrenador.nextId); ;
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Compara por el ID de los entrenadores
        /// </summary>
        /// <param name="e1"> Primer entrenador </param>
        /// <param name="e2"> Segunda entrenador </param>
        /// <returns>Si tienen el mismo ID devuelve True, sino devuelve False</returns>
        public static bool operator ==(Entrenador e1, Entrenador e2)
        {
            return e1.IdEntrenador == e2.IdEntrenador;
        }

        public static bool operator !=(Entrenador e1, Entrenador e2)
        {
            return !(e1 == e2);
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Entrenador)
            {
                retorno = (Entrenador)obj == this;
            }
            return retorno;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string exJugador;
            if(this.IsExJugador)
            {
                exJugador = "Si";
            }
            else
            {
                exJugador = "No";
            }
            sb.Append(this.IdEntrenador + " " + base.ToString() + ", Exjugador: " + exJugador);

            return sb.ToString();
        }

        public override string Mostrar()
        {
            return this.ToString();
        }
        #endregion
    }
}
