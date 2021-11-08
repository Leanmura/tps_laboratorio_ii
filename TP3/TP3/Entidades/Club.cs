using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Club: Equipo
    {
        #region Atributos
        private EPais localidad;
        private string liga;
        #endregion

        #region Propiedades
        public EPais Localidad
        {
            get
            {
                return this.localidad;
            }
            set
            {
                this.localidad = value;
            }
        }
        public string Liga
        {
            get
            {
                return this.liga;
            }
            set
            {
                this.liga = value;
            }
        }
        #endregion

        #region Constructor
        public Club(string nombre, Entrenador entrenador, EPais localidad, string liga)
            : base(nombre, entrenador)
        {
            this.Liga = liga;
            this.Localidad = localidad;
        }
        #endregion

        #region Sobrecargas
        public override bool AgregarJugador(JugadorDeVoley jugador)
        {
            bool retorno = false;
            if (jugador is not null && this != jugador)
            {
                if(this.listaDeJugadores.Count < Equipo.cantidadMaximaDeJugadores)
                {
                    this.listaDeJugadores.Add(jugador);
                    retorno = true;

                }
                else
                {
                    throw new ArgumentException("Club lleno");
                }

            }
            else
            {
                throw new ArgumentException("Jugador no valido.");
            }
            return retorno;
        }
        public static Club operator +(Club club, JugadorDeVoley jugador)
        {
            club.AgregarJugador(jugador);
            return club;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine(this.Localidad.ToString());
            sb.AppendLine(this.Liga);
            return sb.ToString();
        }
        #endregion




    }
}
