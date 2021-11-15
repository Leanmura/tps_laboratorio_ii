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

namespace FormVoleyStadistics
{
    public partial class FrmVoleyStadistics : Form
    {
        private FrmJugadores frmJugadores;
        public List<JugadorDeVoley> listaDeJugadores;
        public List<Entrenador> listaEntrenadores;

        public FrmVoleyStadistics()
        {
            InitializeComponent();
            this.frmJugadores = new FrmJugadores();//listaDeJugadores);
            this.frmJugadores.listaDeJugadores = new List<JugadorDeVoley>();
        }


        private void btnJugadores_Click(object sender, EventArgs e)
        {
            this.frmJugadores.ShowDialog();
            //AbrirFrmJugadores();//this.frmJugadores.listaDeJugadores);
        }

        #region Metodos privados
        //private DialogResult AbrirFrmJugadores()//List<JugadorDeVoley> listaDeJugadores)
        //{
        //    return this.frmJugadores.ShowDialog();
        //}
        #endregion

        private void btnEntrenadores_Click(object sender, EventArgs e)
        {

        }
    }
}
