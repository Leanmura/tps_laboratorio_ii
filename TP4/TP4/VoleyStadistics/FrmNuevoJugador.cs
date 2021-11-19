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
        private JugadorDeVoley jugadorAModificar;

        private int id;

        public JugadorDeVoley NuevoJugador
        {
            get
            {
                return this.nuevoJugador; // con esta propiedad podemos acceder al jugador creado en esta instancia
            }
        }

        public FrmNuevoJugador()
        {
            InitializeComponent();
            cmbPosicion.Items.AddRange(Enum.GetNames(typeof(EPosicion)));
            cmbNacionalidad.Items.AddRange(Enum.GetNames(typeof(EPais)));
        }

        public FrmNuevoJugador(int id):this()
        {
            this.btnCrear.Visible = true;
            this.btnModificar.Visible = false;
            this.id = id;

            cmbPosicion.SelectedIndex = 0;
            cmbNacionalidad.SelectedIndex = 0;
        }

        public FrmNuevoJugador(JugadorDeVoley jugadorAModificar):this()
        {
            this.btnCrear.Visible = false;
            this.btnModificar.Visible = true;
            this.jugadorAModificar = jugadorAModificar;
            this.id = this.jugadorAModificar.Id;
            this.txtNombre.Text = this.jugadorAModificar.Nombre;
            this.txtApellido.Text = this.jugadorAModificar.Apellido;
            this.dateTimeFechaNacimiento.Value = this.jugadorAModificar.FechaNacimiento;
            cmbNacionalidad.SelectedIndex = (int)this.jugadorAModificar.PaisDeNacimiento;
            cmbPosicion.SelectedIndex = (int)this.jugadorAModificar.Posicion;
            this.txtAltura.Text = this.jugadorAModificar.Altura.ToString();
            this.txtPeso.Text = this.jugadorAModificar.Peso.ToString();

        }

        private void FrmNuevoJugador_Load(object sender, EventArgs e)
        {
            lblId.Text = "Jugador #" + this.id;

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                this.nuevoJugador = new JugadorDeVoley();

                this.nuevoJugador.Id = this.id;

                this.nuevoJugador.Nombre = this.txtNombre.Text;
                this.nuevoJugador.Apellido = this.txtApellido.Text;
                this.nuevoJugador.PaisDeNacimiento = (EPais)this.cmbNacionalidad.SelectedIndex;
                this.nuevoJugador.FechaNacimiento = this.dateTimeFechaNacimiento.Value;
                this.nuevoJugador.Peso = double.Parse(this.txtPeso.Text);
                this.nuevoJugador.Altura = double.Parse(this.txtAltura.Text);
                this.nuevoJugador.Posicion = (EPosicion)this.cmbPosicion.SelectedIndex;
                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error. Faltan datos o hay datos mal ingresados.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // this.jugadorAModificar.Nombre;

                this.jugadorAModificar.Nombre = this.txtNombre.Text;
                this.jugadorAModificar.Apellido = this.txtApellido.Text;
                this.jugadorAModificar.PaisDeNacimiento = (EPais)this.cmbNacionalidad.SelectedIndex;
                this.jugadorAModificar.FechaNacimiento = this.dateTimeFechaNacimiento.Value;
                this.jugadorAModificar.Peso = double.Parse(this.txtPeso.Text);
                this.jugadorAModificar.Altura = double.Parse(this.txtAltura.Text);
                this.jugadorAModificar.Posicion = (EPosicion)this.cmbPosicion.SelectedIndex;
                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error. Faltan datos o hay datos mal ingresados.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
