using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class JugadorDeVoley: Persona
    {
        #region Atributos
        private int idJugador;
        private double peso;
        private double altura;
        private EPosicion posicion;
        private static int nextId;
        #endregion

        #region Propiedades
        public static int NextId
        {
            get { return JugadorDeVoley.nextId + 1; }
        }
        public int IdJugador
        {
            get
            {
                return this.idJugador;
            }
            set
            {
                this.idJugador = value;
            }
        }
        public double Peso
        {
            get
            {
                return this.peso;
            }
            set
            {
                JugadorDeVoley.ValidarPeso(value);
                this.peso = value;
            }
        }
        public double Altura
        {
            get
            {
                return this.altura;
            }
            set
            {
                JugadorDeVoley.ValidarAltura(value);
                this.altura = value;
            }
        }
        public EPosicion Posicion
        {
            get
            {
                return this.posicion;
            }
            set
            {
                JugadorDeVoley.ValidarPosicion(value);
                this.posicion = value;
            }
        }
        #endregion

        #region Constructores
        public JugadorDeVoley() : base()
        {

        }
        public JugadorDeVoley(string nombre, string apellido, EPais paisDeNacimiento,
             DateTime fechaNacimiento, double peso, double altura, EPosicion posicion)
            : base(nombre, apellido, paisDeNacimiento, fechaNacimiento)
        {
            this.IdJugador = Interlocked.Increment(ref JugadorDeVoley.nextId); ;
            this.Altura = altura;
            this.Peso = peso;
            this.Posicion = posicion;
        }

        #endregion


        #region Metodos

        /// <summary>
        /// Valida que sea un numero entre 20Kg-200Kg. Sino arroja una excepcion.
        /// </summary>
        /// <param name="value"> Valor a validar</param>
        private static void ValidarPeso(double value)
        {
            if (!(value >= 20 && value <= 200))
            {
                throw new ArgumentOutOfRangeException("Rango de Peso invalido(20Kg-200Kg).");
            }
        }

        /// <summary>
        /// Valida que sea un numero entre 1m-3m. Sino arroja una excepcion.
        /// </summary>
        /// <param name="value"> Valor a validar</param>
        private static void ValidarAltura(double value)
        {
            if (!(value >= 1 && value <= 3))
            {
                throw new ArgumentOutOfRangeException("Rango de Altura invalida(1m-3m).");
            }
        }

        /// <summary>
        /// Valida que sea un numero del enumerado EPosicion. Sino arroja una excepcion.
        /// </summary>
        /// <param name="value"> Valor a validar</param>
        private static void ValidarPosicion(EPosicion value)
        {
            if (!((int)value >= 0 && (int)value <= 4))
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Compara por el ID de los Jugadores
        /// </summary>
        /// <param name="j1"> Primer Jugador </param>
        /// <param name="j2"> Segundo Jugador </param>
        /// <returns>Si tienen el mismo ID devuelve True, sino devuelve False</returns>
        public static bool operator ==(JugadorDeVoley j1, JugadorDeVoley j2)
        {
            return j1.IdJugador == j2.IdJugador;
        }

        public static bool operator !=(JugadorDeVoley j1, JugadorDeVoley j2)
        {
            return !(j1 == j2);
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is JugadorDeVoley)
            {
                retorno = (JugadorDeVoley)obj == this;
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
            sb.Append(this.IdJugador + " " + base.ToString() + ", " + this.Peso + ", " + this.Altura + ", " + this.Posicion);

            return sb.ToString();
        }

        public override string Mostrar()
        {
            return this.ToString();
        }
        #endregion

    }
}
