using System;
using Entidades;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Entrenador e1 = new Entrenador("Jose", "Deus", EPais.Brasil, DateTime.Parse("18/08/2000"));
            Entrenador e2 = new Entrenador("Josue", "God", EPais.Argentina, DateTime.Parse("18/08/2000"));

            Club c1 = new Club("Madrid", e1, EPais.Argentina, "Metro");
            JugadorDeVoley j1 = new JugadorDeVoley("Manuel", "Gonzalez", EPais.Francia, DateTime.Parse("28/02/1990"), 67, 1.66, EPosicion.Libero);
            JugadorDeVoley j2 = new JugadorDeVoley("Emanuel", "Liam", EPais.Japon, DateTime.Parse("3/01/1920"), 62, 1.55, EPosicion.Punta);
            JugadorDeVoley j3 = new JugadorDeVoley("Jose", "Rodriguez", EPais.Argentina, DateTime.Parse("28/02/1990"), 65, 1.65, EPosicion.Central);
            JugadorDeVoley j4 = new JugadorDeVoley("Esteban", "Lopez", EPais.EEUU, DateTime.Parse("28/02/1990"), 61, 1.85, EPosicion.Armador);
            JugadorDeVoley j5 = new JugadorDeVoley("Maria", "Lae", EPais.Iran, DateTime.Parse("3/01/1920"), 62, 1.34, EPosicion.Opuesto);
            JugadorDeVoley j6 = new JugadorDeVoley("Pablo", "Mirta", EPais.Polonia, DateTime.Parse("28/02/1990"), 45, 1.45, EPosicion.Libero);
            JugadorDeVoley j7 = new JugadorDeVoley("Nahuel", "Karim", EPais.Rusia, DateTime.Parse("28/02/1990"), 78, 1.23, EPosicion.Libero);
            JugadorDeVoley j8 = new JugadorDeVoley("Leandro", "Lee", EPais.Italia, DateTime.Parse("3/01/1920"), 123, 1.76, EPosicion.Punta);
            JugadorDeVoley j9 = new JugadorDeVoley("Ramon", "Jose", EPais.Brasil, DateTime.Parse("28/02/1990"), 75, 1.84, EPosicion.Libero);
            JugadorDeVoley j10 = new JugadorDeVoley("Luigi", "William", EPais.Francia, DateTime.Parse("28/02/1990"), 67, 1.47, EPosicion.Libero);
            JugadorDeVoley j11 = new JugadorDeVoley("Fabian", "Kaka", EPais.Japon, DateTime.Parse("3/01/1920"), 45, 1.56, EPosicion.Punta);
            JugadorDeVoley j12 = new JugadorDeVoley("Josue", "Messi", EPais.Argentina, DateTime.Parse("28/02/1990"), 54, 1.87, EPosicion.Libero);
            JugadorDeVoley j13 = new JugadorDeVoley("Tomas", "Tevez", EPais.Rusia, DateTime.Parse("28/02/1990"), 87, 1.47, EPosicion.Libero);
            JugadorDeVoley j14 = new JugadorDeVoley("walter", "Paermo", EPais.Italia, DateTime.Parse("3/01/1920"), 78, 1.6, EPosicion.Punta);
            JugadorDeVoley j15 = new JugadorDeVoley("Delfina", "Alegre", EPais.Brasil, DateTime.Parse("28/02/1990"), 90, 1.97, EPosicion.Libero);
            Nacional n1 = new Nacional(EPais.Argentina, e1);

            // utilizo el metodo Mostrar, que internamente utiliza la sobrecarga del ToString
            Console.WriteLine(j1.Mostrar());

            if(j1 == j2) // No son iguales, compara por id y para todas as instancias es distinto
            {
                Console.WriteLine("Son Iguales");
            }
            else
            {
                Console.WriteLine("No son iguales");
            }

            j2.IdJugador = 1;
            if (j1 == j2) // son iguales, ya que modifico el id del jugador 1
            {
                Console.WriteLine("Son Iguales");
            }
            else
            {
                Console.WriteLine("No son iguales");
            }

            if (j1.Equals( j2)) // sobrecarga del equals(igual que el ==), por lo tanto son iguales
            {
                Console.WriteLine("Son Iguales");
            }
            else
            {
                Console.WriteLine("No son iguales");
            }

            if (e1 == e2) // No son iguales, compara por id y para todas as instancias es distinto
            {
                Console.WriteLine("Son Iguales");
            }
            else
            {
                Console.WriteLine("No son iguales");
            }

            if (e2.Equals(e1)) // sobrecarga del equals(igual que el ==), por lo tanto son distintos
            {
                Console.WriteLine("Son Iguales");
            }
            else
            {
                Console.WriteLine("No son iguales");
            }
            Console.WriteLine(e2.Mostrar());

            // n1 es argentina, entonces para que se puede agregar los jugadores deben ser argentinos
            n1 += j1; // j1 es frances
            n1 += j2; // j2 es japones
            n1 += j3; // j3 es argentino
            n1 += j12; // j12 es argentino

            Console.WriteLine(n1.ToString());

            c1 += j1;
            try
            {
                c1.AgregarJugador(j2); // como j2 tiene el mismo id que j1 arroja una excepcion, ya que no se pudo cargar
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            j2.IdJugador = 2;
            try
            {
                c1.AgregarJugador(j2); // como j2 tiene el mismo id que j1 arroja una excepcion, ya que no se pudo cargar
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            c1 += j3;
            c1 += j4;
            c1 += j5;
            c1 += j6;
            c1 += j7;
            c1 += j8;
            c1 += j9;
            c1 += j10;
            c1 += j11;
            c1 += j12;
            c1 += j13;
            c1 += j14;
            c1 += j15; // no hy mas lugar, no se va a agregar



            if (c1 == j3) // no esta
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
