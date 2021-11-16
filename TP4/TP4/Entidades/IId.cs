using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IId<T> where T: class
    {
        int Id
        {
            get;
            set;
        }
        int GenerarId(List<T> lista);
    }
}
