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
        
        public FrmVoleyStadistics()
        {
            InitializeComponent();
            this.listaDeJugadores = new List<JugadorDeVoley>();
        }


        private void btnJugadores_Click(object sender, EventArgs e)
        {
            AbrirFrmJugadores(this.listaDeJugadores);
        }

        #region Metodos privados
        private DialogResult AbrirFrmJugadores(List<JugadorDeVoley> listaDeJugadores)
        {
            frmJugadores = new FrmJugadores(listaDeJugadores);
            return frmJugadores.ShowDialog();
        }
        #endregion
    }
}
