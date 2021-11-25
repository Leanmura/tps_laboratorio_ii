using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Se lanza cuando el numero no es valido
    /// </summary>
    public class InvalidNumberExeption:Exception
    {
        public InvalidNumberExeption()
            :base("Numero invalido")
        {

        }
    }
}
