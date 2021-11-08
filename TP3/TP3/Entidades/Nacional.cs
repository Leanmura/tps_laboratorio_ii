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

        public Nacional(EPais pais, Entrenador entrenador, int copasDelMundo)
            : base(pais.ToString(), entrenador)
        {
            this.CopasDelMundo = copasDelMundo;
        }
        public Nacional(EPais pais, Entrenador entrenador):this(pais, entrenador, 0)
        {  

        }
        #endregion

        #region Sobrecargas
        public override bool AgregarJugador(JugadorDeVoley jugador)
        {
            bool retorno = false;
            if (jugador is not null && this != jugador && 
                this.Nombre == jugador.PaisDeNacimiento.ToString() && 
                this.listaDeJugadores.Count <= Equipo.cantidadMaximaDeJugadores)
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
            sb.AppendLine(this.CopasDelMundo.ToString());
            return sb.ToString();
        }
        #endregion
    }
}
