using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace FormVoleyStadistics
{
    public partial class FrmJugadores : Form
    {
        private static string rutaArchivo;

        public List<JugadorDeVoley> listaDeJugadores;
        private FrmNuevoJugador frmNuevoJugador;

        static FrmJugadores()
        {
            string nombreArchivo = "listaDeJugadores.xml";
            string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            FrmJugadores.rutaArchivo = Path.Combine(rutaEscritorio, nombreArchivo);
        }

        public FrmJugadores(List<JugadorDeVoley> listaDeJugadores)
        {
            InitializeComponent();
            this.listaDeJugadores = listaDeJugadores;
            frmNuevoJugador = new FrmNuevoJugador();
        }

        private void FrmJugadores_Load(object sender, EventArgs e)
        {
            this.RefrescarDataGrid();
            //this.dataGridJugadores.DataSource = this.listaDeJugadores;
        }

        private void btnNuevoJugador_Click(object sender, EventArgs e)
        {
            if (this.AbrirFrmNuevoJugador() == DialogResult.OK)
            {
                this.lblMensaje.Visible = true;
                this.lblMensaje.ForeColor = System.Drawing.Color.Black;
                this.lblMensaje.Text = "Jugador Creado Correctamente.";
                this.listaDeJugadores.Add(frmNuevoJugador.NuevoJugador);
                this.RefrescarDataGrid();

            }
        }

        private void dataGridJugadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                this.btnModificar.Visible = true;
                this.btnEliminar.Visible = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog frm = new SaveFileDialog();
            frm.ShowDialog();
            this.GuardarDatos();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (File.Exists(FrmJugadores.rutaArchivo))
            {
                try
                {
                    CargarDatos();
                    this.RefrescarDataGrid();
                }

                catch (Exception ev)
                {
                    this.lblMensaje.ForeColor = System.Drawing.Color.Red;
                    this.lblMensaje.Text = this.lblMensaje.Text = ev.Message; //"ERROR: no se pudo cargar los datos.";
                    this.lblMensaje.Visible = true;
                }
            }
        }




        #region Metodos privados
        private DialogResult AbrirFrmNuevoJugador()
        {
            this.lblMensaje.Visible = false;
            frmNuevoJugador = new FrmNuevoJugador();
            return frmNuevoJugador.ShowDialog();
        }

        private void RefrescarDataGrid()
        {
            if(this.listaDeJugadores.Count > 0)
            {
                 this.dataGridJugadores.DataSource = null;
                this.dataGridJugadores.DataSource = this.listaDeJugadores;
            }
        }

        private void GuardarDatos()
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(rutaArchivo, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer((typeof(List<JugadorDeVoley>)));
                    ser.Serialize(writer, listaDeJugadores);
                    this.lblMensaje.Visible = true;
                    this.lblMensaje.ForeColor = System.Drawing.Color.Black;
                    this.lblMensaje.Text = "Los datos se guardaron correctamente.";

                }
            }
            catch (Exception e)
            {
                this.lblMensaje.ForeColor = System.Drawing.Color.Red;
                this.lblMensaje.Text = e.Message; //"ERROR: no se pudo guardar los datos.";
                this.lblMensaje.Visible = true;
            }
        }

        private void CargarDatos()
        {
                using (XmlTextReader reader = new XmlTextReader(rutaArchivo))
                {
                    XmlSerializer ser = new XmlSerializer((typeof(List<JugadorDeVoley>)));
                    this.listaDeJugadores = ser.Deserialize(reader) as List<JugadorDeVoley>;
                    this.lblMensaje.Visible = true;
                    this.lblMensaje.ForeColor = System.Drawing.Color.Black;
                    this.lblMensaje.Text = "Los datos se cargaron correctamente.";
                }
        }
        #endregion
    }
}
