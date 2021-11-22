using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        static Persona()
        {
            // cambiar el nombre de la tabla
            Persona.connectionString = @"Server=localhost;Database=TP4_DB;Trusted_Connection=True;";
            //Persona.connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EMPRESA_DB; Integrated Security=True;";
            Persona.connection = new SqlConnection(Persona.connectionString);
            Persona.command = new SqlCommand();
            Persona.command.Connection = Persona.connection;
            Persona.command.CommandType = CommandType.Text;

        }

        protected Persona()
        {

        }
        protected Persona(string nombre, string apellido, EPais paisDeNacimiento, DateTime fechaNacimiento):this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.paisDeNacimiento = paisDeNacimiento;
            this.fechaNacimiento = fechaNacimiento;
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

            sb.Append( "Nombre: " + this.Nombre + ", Apellido: " + this.Apellido + 
                ", Pais de nacimeinto: " + this.PaisDeNacimiento + ", Fecha de Naicimiento:" +
                this.FechaNacimiento.ToShortDateString());

            return sb.ToString();
        }

        /// <summary>
        /// Una persona es igual a otra si todos sus atributos son iguales
        /// </summary>
        /// <param name="p1"> Primera persona </param>
        /// <param name="p2"> Segunda persona </param>
        /// <returns>si son identicas devuelve True, sino devuelve False</returns>
        public static bool operator ==(Persona p1, Persona p2)
        {
            return p1.Nombre == p2.Nombre && p1.Apellido == p2.Apellido && p1.PaisDeNacimiento == p2.PaisDeNacimiento && p1.FechaNacimiento == p2.FechaNacimiento;
        }

        public static bool operator !=(Persona p1, Persona p2)
        {
            return !(p1 == p2);
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Persona)
            {
                retorno = (Persona)obj == this;
            }
            return retorno;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        /// <summary>
        /// Valida que sea un sustantivo propio, y pone en mayuscula el primer caracter. Sino arroja una excepcion.
        /// </summary>
        /// <param name="value"> Palabra a validar </param>
        /// <returns> Palabra valida formateada </returns>
        private static string ValidarSustPropio(string value)
        {
            value = value.ToLower().Trim();
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("La palabra contiene simbolos, espacios o esta vacia."); // cambiar por eventos
            }
            foreach (char item in value)
            {
                if (!(char.IsLetter(item)))
                {
                    throw new ArgumentException("La palabra contiene numeros.");
                }
            }
            
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

        #region SQL

        #region Atributos

        protected static string connectionString;
        protected static SqlConnection connection;
        protected static SqlCommand command;
        protected static SqlDataReader dataReader;
        #endregion

        #region MétodosSQL

        public static bool ConnectionTest()
        {
            bool rta = true;

            try
            {
                Persona.connection.Open();
            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                Persona.CloseConnection();
            }

            return rta;
        }

        protected static void CloseConnection()
        {
            if (Persona.connection.State == ConnectionState.Open)
            {
                Persona.connection.Close();
            }
        }
        #endregion

        #endregion
    }


}
