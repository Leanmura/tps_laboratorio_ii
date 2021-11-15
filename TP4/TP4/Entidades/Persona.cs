using System;
using System.Text;
using System.Threading;

namespace Entidades
{
    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        private EPais paisDeNacimiento;
        private DateTime fechaNacimiento; // DateTime.Parse("DD/MM/YYYY")


        #region Propiedades
        public string Nombre
        {
            get { return this.nombre; }
            set 
            {
                this.nombre = Persona.ValidarSustPropio(value);
            }
        }
        public string Apellido
        {
            get { return this.apellido; }
            set
            {
                this.apellido = Persona.ValidarSustPropio(value);
            }
        }
        public EPais PaisDeNacimiento
        {
            get { return this.paisDeNacimiento; }
            set
            {
                Persona.ValidarPais(value);
                this.paisDeNacimiento = value;
            }
        }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }

        #endregion

        #region Constructores
        protected Persona()
        {

        }
        protected Persona(string nombre, string apellido, EPais paisDeNacimiento, DateTime fechaNacimiento):this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.PaisDeNacimiento = paisDeNacimiento;
            this.FechaNacimiento = fechaNacimiento;
        }



        #endregion
        #region Metodos
        /// <summary>
        /// Muestra todos los datos de la Persona
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return this.ToString();
        }
        #endregion

        #region Sobrecargas
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append( "Nomnbre: " + this.Nombre + ", Apellido: " + this.Apellido + 
                ", Pais de nacimeinto: " + this.PaisDeNacimiento + ", Fecha de Naicimiento:" +
                this.FechaNacimiento.ToShortDateString());

            return sb.ToString();
        }

        ///// <summary>
        ///// Compara por el ID de las personas 
        ///// </summary>
        ///// <param name="p1"> Primera persona </param>
        ///// <param name="p2"> Segunda persona </param>
        ///// <returns>Si tienen el mismo ID devuelve True, sino devuelve False</returns>
        //public static bool operator ==(Persona p1, Persona p2)
        //{
        //    return p1.Id == p2.Id;
        //}

        //public static bool operator !=(Persona p1, Persona p2)
        //{
        //    return !(p1 == p2);
        //}

        //public override bool Equals(object obj)
        //{
        //    bool retorno = false;
        //    if(obj is Persona)
        //    {
        //        retorno = (Persona)obj == this;
        //    }
        //    return retorno;
        //}

        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}
        #endregion

        /// <summary>
        /// Valida que sea un sustantivo propio, y pone en mayuscula el primer caracter. Sino arroja una excepcion.
        /// </summary>
        /// <param name="value"> Palabra a validar </param>
        /// <returns> Palabra valida formateada </returns>
        private static string ValidarSustPropio(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("La palabra contiene simbolos, espacios o esta vacia.");
            }
            foreach (char item in value)
            {
                if (!(char.IsLetter(item)))
                {
                    throw new ArgumentException("La palabra contiene numeros.");
                }
            }
            value = value.Replace(value[0], char.ToUpper(value[0]));
            return value;
        }

        /// <summary>
        /// Valida que sea un numero del enumerado EPais. Sino arroja una excepcion.
        /// </summary>
        /// <param name="value"> Valor a validar</param>
        private static void ValidarPais(EPais value)
        {
            if (!((int)value >= 0 && (int)value <= 8))
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }


}
