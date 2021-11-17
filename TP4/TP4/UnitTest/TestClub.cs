using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades; 


namespace UnitTest
{
    [TestClass]
    public class TestClub
    {
        [TestMethod]
        public void AgregarJugador_Should_AgregarElJugador()
        {
            // arrange - act - addert

            // Arrange -> Simulacion de los datos
            JugadorDeVoley jugador = new JugadorDeVoley("Manuel", "Larie", EPais.Francia, DateTime.Parse("28/02/1990"), 67, 1.87, EPosicion.Libero) ;
            Entrenador entrenador = new Entrenador("Jose", "Deus", EPais.Brasil, DateTime.Parse("18/08/2000"), true);
            Club club = new Club("Madrid", entrenador, EPais.Argentina, "Metro");

            // Act -> llamada a la funcionalidad a testiar
            club.AgregarJugador(jugador);

            // Assert -> comprobacion de resultados
            Assert.AreSame(club.listaDeJugadores[0], jugador);


        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void AgregarJugador_Should_ThrowArgumentExeption_JugadorNull()
        {

            // Arrange -> Simulacion de los datos
            JugadorDeVoley jugador = null;
            Entrenador entrenador = new Entrenador("Jose", "Deus", EPais.Brasil, DateTime.Parse("18/08/2000"), true);
            Club club = new Club("Madrid", entrenador, EPais.Argentina, "Metro");

            // Act -> llamada a la funcionalidad a testiar
            club.AgregarJugador(jugador);

        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void AgregarJugador_Should_ThrowArgumentExeption_JugadorYaEsta()
        {

            // Arrange -> Simulacion de los datos
            JugadorDeVoley jugador = new JugadorDeVoley("Manuel", "Larie", EPais.Francia, DateTime.Parse("28/02/1990"), 67, 1.87, EPosicion.Libero);
            Entrenador entrenador = new Entrenador("Jose", "Deus", EPais.Brasil, DateTime.Parse("18/08/2000"), true);
            Club club = new Club("Madrid", entrenador, EPais.Argentina, "Metro");
            club.AgregarJugador(jugador);

            // Act -> llamada a la funcionalidad a testiar
            club.AgregarJugador(jugador);
        }

    }
}
