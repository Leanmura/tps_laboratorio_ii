using System;
using Entidades;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Entrenador e1 = new Entrenador("Jose", "Deus", EPais.Brasil, DateTime.Parse("18/08/2000"));
            Club c1 = new Club("Madrid", e1, EPais.Argentina, "Metro");
            JugadorDeVoley j1 = new JugadorDeVoley("Manuel", "Larie", EPais.Francia, DateTime.Parse("28/02/1990"), 67, 1.87, EPosicion.Libero);
            JugadorDeVoley j2 = new JugadorDeVoley("Emanuel", "Lae", EPais.Japon, DateTime.Parse("3/01/1920"), 62, 1.8, EPosicion.Punta);
            JugadorDeVoley j3 = new JugadorDeVoley("Jose", "Larie", EPais.Argentina, DateTime.Parse("28/02/1990"), 67, 1.87, EPosicion.Libero);
            Nacional n1 = new Nacional(EPais.Argentina, e1);

            n1 += j1;
            n1 += j2;
            n1 += j3;

            Console.WriteLine(n1.ToString());

            c1 += j1;
            c1 += j2;
            if(c1.AgregarJugador(j3))
            { }
            else { Console.WriteLine("No se pudo agregar."); }

            if(c1 == j3)
            {
                Console.WriteLine("j1 esta en c1. ");
            }
            else
            {
                Console.WriteLine("j1 NO esta en c1.");
            }

           // Console.WriteLine(c1.listaDeJugadores[0].ToString());
            Console.WriteLine(c1.ToString());


            Console.ReadLine();

        }
    }
}
