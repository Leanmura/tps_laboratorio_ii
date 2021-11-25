using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    public class Nacional: Equipo
    {
        #region Atributos
        private int copasDelMundo;
        #endregion

        #region Propiedades
        public int CopasDelMundo
        {
            get
            {
                return this.copasDelMundo;
            }
            set
            {
                if(value < 0)
                {
                    throw new InvalidNumberExeption(); // lanzo excepcion propia
                }
                else
                {
                    this.copasDelMundo = value;
                }
            }
        }

        #endregion

        #region Constructor

        public Nacional():base()
        {

        }

        public Nacional(EPais pais, int copasDelMundo)
            : base(pais.ToString())
        {
            this.CopasDelMundo = copasDelMundo;
        }
        public Nacional(EPais pais):this(pais, 0)
        {  

        }
        #endregion

        #region Sobrecargas
        public override bool AgregarJugador(JugadorDeVoley jugador)
        {
            bool retorno = false;
            if (jugador is not null && !this.Contains( jugador) && 
                this.Nombre == jugador.PaisDeNacimiento.ToString() && 
                this.listaDeJugadores.Count < Equipo.cantidadMaximaDeJugadores)
            {
                this.listaDeJugadores.Add(jugador);

                retorno = true;
            }
            return retorno;
        }

        public static Nacional operator +(Nacional nacional, JugadorDeVoley jugador)
        {
            nacional.AgregarJugador(jugador);
            return nacional;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine("Copas del mundo: "+ this.CopasDelMundo.ToString());
            return sb.ToString();
        }

        public static bool operator ==(Nacional n1, Nacional n2)
        {
            bool retorno = false;
            if (n1.Nombre == n2.Nombre)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Nacional n1, Nacional n2)
        {
            return !(n1 == n2);
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Nacional)
            {
                retorno = (Nacional)obj == this;
            }
            return retorno;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
