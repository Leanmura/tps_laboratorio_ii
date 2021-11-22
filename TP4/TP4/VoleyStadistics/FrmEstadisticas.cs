using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormVoleyStadistics
{
    public partial class FrmEstadisticas : Form
    {
        private List<Club> listaClubes;
        private List<JugadorDeVoley> listaJugadores;
        public FrmEstadisticas(List<Club> listaClubes, List<JugadorDeVoley> listaJugadores)
        {
            InitializeComponent();
            this.listaClubes = listaClubes;
            this.listaJugadores = listaJugadores;
        }

        private void FrmEstadisticas_Load(object sender, EventArgs e)
        {
            List<string> listaNombres = new List<string>();
            //this.cmbLocalidad.SelectedIndex = 0;
            cmbLocalidad.Items.AddRange(Enum.GetNames(typeof(EPais)));
            cmbPosicion.Items.AddRange(Enum.GetNames(typeof(EPosicion)));
            cmbPosicion.SelectedIndex = 0; 
            cmbLocalidad.SelectedIndex = 0;
            foreach (Club item in this.listaClubes)
            {
                listaNombres.Add(item.Nombre);
            }
            cmbClubes1.Items.AddRange(listaNombres.ToArray());
            cmbClubes2.Items.AddRange(listaNombres.ToArray());
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            int cantidad = this.CantClubesPais((EPais)this.cmbLocalidad.SelectedIndex);
            this.lblMensaje.Text = "Cantidad de clubes en " + this.cmbLocalidad.Text + ": " + cantidad;
        }

        private void btnImprimir2_Click(object sender, EventArgs e)
        {
            int cantidad;
            if(this.cmbClubes1.SelectedIndex == -1)
            {
                MessageBox.Show("No selecciono ningun club.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cantidad = this.CantJugadoresPosicionClub((EPosicion)this.cmbPosicion.SelectedIndex, this.cmbClubes1.SelectedIndex);
                this.lblMensaje.Text = "Cantidad de jugadores " + this.cmbPosicion.Text + " en " + this.cmbClubes1.Text + ": " + cantidad;

            }
        }

        private void btnImprimir3_Click(object sender, EventArgs e)
        {
            int cantidad;
            if (this.cmbClubes2.SelectedIndex == -1)
            {
                MessageBox.Show("No selecciono ningun club.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cantidad = this.CantJugadoresExtranjerosClub(this.cmbClubes2.SelectedIndex);
                this.lblMensaje.Text = "Cantidad de jugadores extranjeros en " + this.cmbClubes2.Text + ": " + cantidad;
            }
        }



        private int CantClubesPais(EPais pais)
        {
            int cantidad = 0;
            foreach (Club item in this.listaClubes)
            {
                if(item.Localidad == pais)
                {
                    cantidad++;
                }
            }
            return cantidad;
        }

        private int CantJugadoresPosicionClub(EPosicion posicion, int indiceClub)
        {
            int cantidad = 0;
            Club club = this.listaClubes[indiceClub];
            foreach (JugadorDeVoley item in club.listaDeJugadores)
            {
                if(item.Posicion == posicion)
                {
                    cantidad++;
                }
            }
            return cantidad;
        }

        private int CantJugadoresExtranjerosClub(int indiceClub)
        {
            int cantidad = 0 ;
            Club club = this.listaClubes[indiceClub];
            EPais localidadClub = club.Localidad;
            foreach (JugadorDeVoley item in club.listaDeJugadores)
            {
                if(item.PaisDeNacimiento != localidadClub)
                {
                    cantidad++;
                }
            }
            return cantidad;
        }

    }
}
