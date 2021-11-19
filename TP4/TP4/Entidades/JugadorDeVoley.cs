using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class JugadorDeVoley: Persona, IId<JugadorDeVoley>
    {
        #region Atributos

        private double peso;
        private double altura;
        private EPosicion posicion;

        #endregion

        #region Propiedades
        public int Id { get;set;} // de la interfaz

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
            this.altura = altura;
            this.peso = peso;
            this.posicion = posicion;
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

        public int GenerarId(List<JugadorDeVoley> lista, int maxId)
        {
            foreach (JugadorDeVoley item in lista)
            {
                if (item.Id > maxId)
                {
                    maxId = item.Id;
                }
            }
            return maxId+1;
        }

        public static List<JugadorDeVoley> ReadAll()
        {
            //cambiar el tipo de retorno segun nuestra clase
            List<JugadorDeVoley> listJugadorDeVoleys = new List<JugadorDeVoley>();
            try
            {
                Persona.connection.Open();
                Persona.command.CommandText = "SELECT ID, NOMBRE, APELLIDO, ID_PAIS, FECHA_NACIMIENTO, PESO, ALTURA, ID_POSICION FROM JUGADOR_DE_VOLEY";
                Persona.dataReader = Persona.command.ExecuteReader();

                while (Persona.dataReader.Read()) // lee los registros (fila a fila)
                {
                    JugadorDeVoley item = new JugadorDeVoley();
                    item.Id = (int)dataReader[0];
                    item.Nombre = dataReader[1].ToString();
                    item.Apellido = dataReader[2].ToString();
                    item.PaisDeNacimiento = (EPais)dataReader[3];
                    item.FechaNacimiento = DateTime.Parse(dataReader[4].ToString());
                    item.Peso = (double)dataReader[5];
                    item.Altura = (double)dataReader[6];
                    item.Posicion = (EPosicion)dataReader[7];
                    listJugadorDeVoleys.Add(item);
                    
                }
            }
            catch (Exception)
            {
                // hacer algo con la exepcion
                throw;
            }
            finally
            {
                Persona.CloseConnection();
            }
            return listJugadorDeVoleys;
        }

        // cambiar el objeto segun la clase
        public static bool Insert(JugadorDeVoley item)
        {
            bool rta = true;
            int filasAfectadas;
            try
            {
                Persona.connection.Open();
                Persona.command.Parameters.Clear();
                Persona.command.Parameters.AddWithValue("@nombre", item.Nombre);
                Persona.command.Parameters.AddWithValue("@apellido", item.Apellido);
                Persona.command.Parameters.AddWithValue("@pais", (int)item.PaisDeNacimiento);
                Persona.command.Parameters.AddWithValue("@fecha", item.FechaNacimiento);
                Persona.command.Parameters.AddWithValue("@posicion", (int)item.Posicion);
                Persona.command.Parameters.AddWithValue("@peso", item.Peso);
                Persona.command.Parameters.AddWithValue("@altura", item.Altura);

                Persona.command.CommandText = "INSERT INTO JUGADOR_DE_VOLEY" +
                    "( NOMBRE, APELLIDO, ID_PAIS, FECHA_NACIMIENTO, PESO, ALTURA, ID_POSICION)" +
                    " VALUES(@nombre, @apellido, @pais, @fecha, @peso, @altura, @posicion)"; // hay que poner todos los campos que no aceptan NULL
                filasAfectadas = Persona.command.ExecuteNonQuery();
                if (filasAfectadas == 0)
                {
                    rta = false;
                }

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

        public static bool Update(JugadorDeVoley item)
        {
            bool rta = true;
            int filasAfectadas;
            try
            {
                Persona.connection.Open();
                Persona.command.Parameters.Clear();
                Persona.command.Parameters.AddWithValue("@id", item.Id); // necesitamos el id para ver cual actualizamos
                Persona.command.Parameters.AddWithValue("@nombre", item.Nombre);
                Persona.command.Parameters.AddWithValue("@apellido", item.Apellido);
                Persona.command.Parameters.AddWithValue("@pais", (int)item.PaisDeNacimiento);
                Persona.command.Parameters.AddWithValue("@fecha", item.FechaNacimiento);
                Persona.command.Parameters.AddWithValue("@posicion", (int)item.Posicion);
                Persona.command.Parameters.AddWithValue("@peso", item.Peso);
                Persona.command.Parameters.AddWithValue("@altura", item.Altura);

                Persona.command.CommandText = "UPDATE dbo.JUGADOR_DE_VOLEY " +
                    "SET NOMBRE = @nombre, APELLIDO = @apellido, ID_PAIS = @pais, FECHA_NACIMIENTO = @fecha, " +
                    "PESO = @peso, ALTURA = @altura, ID_POSICION = @posicion " + // no hace falta cambiar todos los datos, solo los que modificamos
                    "WHERE ID= @id";
                filasAfectadas = Persona.command.ExecuteNonQuery();
                if (filasAfectadas == 0)
                {
                    rta = false;
                }
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

        public static bool Delete(JugadorDeVoley item)
        {
            bool rta = true;
            int filasAfectadas;
            try
            {
                Persona.connection.Open();
                Persona.command.Parameters.Clear();
                Persona.command.Parameters.AddWithValue("@id", item.Id);
                Persona.command.CommandText = "DELETE FROM JUGADOR_DE_VOLEY WHERE ID = @id";
                filasAfectadas = Persona.command.ExecuteNonQuery();
                if (filasAfectadas == 0)
                {
                    rta = false;
                }

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
        #endregion

        #region Sobrecargas

        /// <summary>
        /// Compara por el ID de los Jugadores
        /// </summary>
        /// <param name="j1"> Primer Jugador </param>
        /// <param name="j2"> Segundo Jugador </param>
        /// <returns>Si tienen el mismo ID devuelve True, sino devuelve False</returns>
        //public static bool operator ==(JugadorDeVoley j1, JugadorDeVoley j2)
        //{
        //    return  j1.Nombre == j2.Nombre && j1.Apellido == j2.Apellido && j1.PaisDeNacimiento == j2.PaisDeNacimiento ;
        //}

        //public static bool operator !=(JugadorDeVoley j1, JugadorDeVoley j2)
        //{
        //    return !(j1 == j2);
        //}

        //public override bool Equals(object obj)
        //{
        //    bool retorno = false;
        //    if (obj is JugadorDeVoley)
        //    {
        //        retorno = (JugadorDeVoley)obj == this;
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
            sb.Append("ID: "+ this.Id + ", " + base.ToString() + ", Peso: " + this.Peso + ", Altura: " + this.Altura + ", " + this.Posicion);

            return sb.ToString();
        }

        public override string Mostrar()
        {
            return this.ToString();
        }
        #endregion

    }
}
