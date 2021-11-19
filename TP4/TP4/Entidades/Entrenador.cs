using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public delegate void AsignarId(object sender, EventArgs e);

    public class Entrenador : Persona, IId<Entrenador>
    {
        public event AsignarId AsignarIdEvent;

        #region Atributos
        private bool isExJugador;

        #endregion

        #region Propiedades
        public int Id
        {
            get;
            set;
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
        public Entrenador() : base()
        {

        }
        public Entrenador(string nombre, string apellido, EPais paisDeNacimiento, DateTime fechaNacimiento, bool isExJugado)
             : base(nombre, apellido, paisDeNacimiento, fechaNacimiento)
        {
            this.isExJugador = isExJugado;
            //this.AsignarIdEvent(this, EventArgs.Empty);
            //this.idEntrenador = Interlocked.Increment(ref Entrenador.nextId); ;
        }

        #endregion

        #region Sobrecargas

        ///// <summary>
        ///// Compara por el ID de los entrenadores
        ///// </summary>
        ///// <param name="e1"> Primer entrenador </param>
        ///// <param name="e2"> Segunda entrenador </param>
        ///// <returns>Si tienen el mismo ID devuelve True, sino devuelve False</returns>
        //public static bool operator ==(Entrenador e1, Entrenador e2)
        //{
        //    return e1.Id == e2.Id;
        //}

        //public static bool operator !=(Entrenador e1, Entrenador e2)
        //{
        //    return !(e1 == e2);
        //}

        //public override bool Equals(object obj)
        //{
        //    bool retorno = false;
        //    if (obj is Entrenador)
        //    {
        //        retorno = (Entrenador)obj == this;
        //    }
        //    return retorno;
        //}

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string exJugador;
            if (this.IsExJugador)
            {
                exJugador = "Si";
            }
            else
            {
                exJugador = "No";
            }
            sb.Append("ID: " + this.Id + ", " + base.ToString() + ", Exjugador: " + exJugador);

            return sb.ToString();
        }

        public override string Mostrar()
        {
            return this.ToString();
        }
        #endregion

        #region Metodos

        public int GenerarId(List<Entrenador> lista, int maxId)
        {
            foreach (Entrenador item in lista)
            {
                if (item.Id > maxId)
                {
                    maxId = item.Id;
                }

            }
            return maxId + 1;
        }
        #endregion

    }
}
