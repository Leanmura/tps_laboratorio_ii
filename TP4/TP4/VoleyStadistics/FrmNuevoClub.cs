using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FormVoleyStadistics
{
    public partial class FrmNuevoClub : FrmNuevoEquipo
    {
        #region Atributos 
        private Club nuevoClub;
        private Club clubAModificar;
        private List<JugadorDeVoley> listaJugadoresDisponibles;
        private List<JugadorDeVoley> listaJugadoresMiClub;

        public Club NuevoClub
        {
            get
            {
                return this.nuevoClub;
            }
            set
            {
                this.nuevoClub = value;
            }
        }
        public Club ClubAModificar
        {
            get
            {
                return this.clubAModificar;
            }
            set
            {
                this.clubAModificar = value;
            }

        }

        #endregion

        public FrmNuevoClub(List<JugadorDeVoley> listaJugadoresDisponibles)
        {
            InitializeComponent();
            this.btnCrear.Visible = true;
            this.btnModificar.Visible = false;
            this.listaJugadoresDisponibles = listaJugadoresDisponibles;
            this.listaJugadoresMiClub = new List<JugadorDeVoley>();
            this.cmbLocalidad.Items.AddRange(Enum.GetNames(typeof(EPais)));
            this.cmbLocalidad.SelectedIndex = 0;

        }
        public FrmNuevoClub(List<JugadorDeVoley> listaJugadoresDisponibles, Club clubAModificar) : this(listaJugadoresDisponibles)
        {
            this.btnCrear.Visible = false;
            this.btnModificar.Visible = true;
            this.clubAModificar = clubAModificar;
            this.listaJugadoresMiClub = clubAModificar.listaDeJugadores;
            this.cmbLocalidad.SelectedIndex = (int)clubAModificar.Localidad;
            this.txtNombre.Text = clubAModificar.Nombre;
            this.txtLiga.Text = clubAModificar.Liga;
        }

        private void FrmNuevoClub_Load(object sender, EventArgs e)
        {
            this.RefrescarDataGrid();
        }

        protected void RefrescarDataGrid()
        {
            if (this.listaJugadoresDisponibles.Count > 0)
            {
                this.dataGridDisponibles.DataSource = null;
                //this.dataGridDisponibles.Rows.Clear();
                this.dataGridDisponibles.DataSource = this.listaJugadoresDisponibles;
                this.dataGridDisponibles.Columns["Nombre"].DisplayIndex = 1;
                this.dataGridDisponibles.Columns["Apellido"].DisplayIndex = 2;
                this.dataGridDisponibles.Columns["Id"].HeaderText = "ID";
                this.dataGridDisponibles.Columns["FechaNacimiento"].HeaderText = "Fecha de nacimiento";
                this.dataGridDisponibles.Columns["PaisDeNacimiento"].HeaderText = "Pais";
            }
            else
            {
                this.dataGridDisponibles.DataSource = null;
            }
            if (this.listaJugadoresMiClub.Count > 0)
            {
                this.dataGridMiClub.DataSource = null;
                this.dataGridMiClub.DataSource = this.listaJugadoresMiClub;
                this.dataGridMiClub.Columns["Nombre"].DisplayIndex = 1;
                this.dataGridMiClub.Columns["Apellido"].DisplayIndex = 2;
                this.dataGridMiClub.Columns["Id"].HeaderText = "ID";
                this.dataGridMiClub.Columns["FechaNacimiento"].HeaderText = "Fecha de nacimiento";
                this.dataGridMiClub.Columns["PaisDeNacimiento"].HeaderText = "Pais";

            }
            else
            {
                this.dataGridMiClub.DataSource = null;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.listaJugadoresMiClub.Count < Club.cantidadMaximaDeJugadores)
            {
                if (this.dataGridDisponibles.CurrentRow != null)
                {
                    int indice = this.listaJugadoresDisponibles.IndexOf((JugadorDeVoley)dataGridDisponibles.CurrentRow.DataBoundItem);
                    if (indice != -1)
                    {
                        JugadorDeVoley jugadorAdd = this.listaJugadoresDisponibles[indice]; // guardo la referencia de este jugador
                        this.listaJugadoresMiClub.Add(jugadorAdd);
                        this.listaJugadoresDisponibles.Remove(jugadorAdd);
                        this.RefrescarDataGrid();

                    }

                }
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.dataGridMiClub.CurrentRow != null)
            {
                int indice = this.listaJugadoresMiClub.IndexOf((JugadorDeVoley)dataGridMiClub.CurrentRow.DataBoundItem);
                if (indice != -1)
                {
                    JugadorDeVoley jugadorRemove = this.listaJugadoresMiClub[indice]; // guardo la referencia de este jugador
                    this.listaJugadoresDisponibles.Add(jugadorRemove);
                    this.listaJugadoresMiClub.Remove(jugadorRemove);
                    this.RefrescarDataGrid();

                }
            }
        }

        private void dataGridDisponibles_DataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                this.nuevoClub = new Club();
                this.cargarDatos(this.NuevoClub);
               
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
                this.cargarDatos(this.ClubAModificar);
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error. Faltan datos o hay datos mal ingresados.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Carga los datos del club creado o modificado
        /// </summary>
        /// <param name="club"> Cllub a crear o modificar </param>
        private void cargarDatos(Club club)
        {
            if (!(this.listaJugadoresMiClub.Count >= 6))
            {
                throw new ArgumentException("La lista no tiene jugadores suficientes"); // cambiar por eventos
            }
            club.listaDeJugadores = this.listaJugadoresMiClub;
            club.Nombre = this.txtNombre.Text;
            club.Liga = this.txtLiga.Text;
            club.Localidad = (EPais)this.cmbLocalidad.SelectedIndex;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FrmNuevoClub_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.listaJugadoresDisponibles.Clear();
        }
    }
}
