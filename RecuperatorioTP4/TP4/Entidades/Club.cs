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
                Equipo.ValidarPais(value);
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
                value = Equipo.ValidarEquipo(value);
                this.liga = value;
            }
        }
        #endregion

        #region Constructor
        public Club ():base()
        {

        }
        public Club(string nombre, EPais localidad, string liga)
            :base(nombre)
        {
            this.liga = liga;
            this.localidad = localidad;
        }
        #endregion

        #region Sobrecargas

        public static bool operator ==(Club c1, Club c2)
        {
            bool retorno = false;
            if (c1.Nombre == c2.Nombre && c1.Localidad == c2.Localidad)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Club c1, Club c2)
        {
            return !(c1 == c2);
        }

        public static Club operator +(Club club, JugadorDeVoley jugador)
        {
            try
            {
                club.AgregarJugador(jugador);

            }
            catch(ArgumentException) 
            {
                
            }
            return club;
        }

        public override bool AgregarJugador(JugadorDeVoley jugador)
        {
            bool retorno = false;
            if (jugador is not null && !this.Contains(jugador))
            {
                if(this.listaDeJugadores.Count < Equipo.cantidadMaximaDeJugadores)
                {
                    this.listaDeJugadores.Add(jugador);
                    retorno = true;

                }
                else
                {
                    throw new ArgumentException("Club lleno"); // se puede cambiar por evento
                }

            }
            else
            {
                throw new ArgumentException("Jugador no valido.");
            }
            return retorno;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine("Pais: " + this.Localidad.ToString());
            sb.AppendLine("Liga: "+this.Liga);
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Club)
            {
                retorno = (Club)obj == this;
            }
            return retorno;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion


    }
}
