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
    public partial class FrmNuevoJugador : Form
    {
        private JugadorDeVoley nuevoJugador;
        private int id;

        public JugadorDeVoley NuevoJugador
        {
            get
            {
                return this.nuevoJugador; // con esta propiedad podemos acceder al jugador creado en esta instancia
            }
        }

        public FrmNuevoJugador(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                nuevoJugador = new JugadorDeVoley(this.txtNombre.Text, this.txtApellido.Text,
                    (EPais)this.cmbNacionalidad.SelectedIndex, this.dateTimeFechaNacimiento.Value,
                    double.Parse(this.txtPeso.Text), double.Parse(this.txtAltura.Text),
                    (EPosicion)this.cmbPosicion.SelectedIndex);

                nuevoJugador.Id = this.id;
                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error. Faltan datos o hay datos mal ingresados.");
            }
        }

        private void FrmNuevoJugador_Load(object sender, EventArgs e)
        {
            lblId.Text = "Jugador #" + this.id;
            cmbPosicion.Items.AddRange(Enum.GetNames(typeof(EPosicion)));
            cmbPosicion.SelectedIndex = 0;
            cmbNacionalidad.Items.AddRange(Enum.GetNames(typeof(EPais)));
            cmbNacionalidad.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


    }
}
