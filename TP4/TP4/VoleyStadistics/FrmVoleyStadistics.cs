using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

// si tira error con la modificacion de la base de datos, reiniciar el programa para actualizar ids

namespace FormVoleyStadistics
{
    public partial class FrmVoleyStadistics : Form
    {
        private FrmJugadores frmJugadores;
        public List<JugadorDeVoley> listaDeJugadores;
        public static int maxId;
        private FrmClubes frmClubes;
        public List<Club> listaDeClubes;

        static FrmVoleyStadistics()
        {
           FrmVoleyStadistics.maxId = 0;
         }

        public FrmVoleyStadistics()
        {
            InitializeComponent();
            this.frmJugadores = new FrmJugadores(); 
            this.frmJugadores.listaDeJugadores = JugadorDeVoley.ReadAll(); // cargo en la lista de jugadores del frmJugadores los datos de la base de datos
            this.listaDeJugadores = this.frmJugadores.listaDeJugadores; // copio la referencia en un atributo de esta instancia

            this.frmClubes = new FrmClubes(this.listaDeJugadores); 
            this.frmClubes.listaClubes = new List<Club>();
            this.listaDeClubes = this.frmClubes.listaClubes;
        }

        private void btnJugadores_Click(object sender, EventArgs e)
        {
            this.frmJugadores.ShowDialog();
        }

        private void btnClubes_Click(object sender, EventArgs e)
        {
            this.frmClubes.ShowDialog();
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            FrmEstadisticas frmEstaditicas = new FrmEstadisticas(this.listaDeClubes, this.listaDeJugadores);
            frmEstaditicas.ShowDialog();
        }
    }
}
