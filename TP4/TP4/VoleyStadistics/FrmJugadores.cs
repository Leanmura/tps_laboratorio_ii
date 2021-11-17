using Entidades;
using IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FormVoleyStadistics
{
    public partial class FrmJugadores : Form
    {
        private static string rutaArchivo;

        public List<JugadorDeVoley> listaDeJugadores;
        private FrmNuevoJugador frmNuevoJugador;

        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private string ultimoArchivo;
        private ExtXml<List<JugadorDeVoley>> extXml; // se crea atributo de clase generica
        private ExtJson<List<JugadorDeVoley>> extJson;
        private JugadorDeVoley jugadorModificar;

        private string UltimoArchivo
        {
            get
            {
                return ultimoArchivo;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    ultimoArchivo = value;
                }
            }
        }

        static FrmJugadores()
        {
            string nombreArchivo = "listaDeJugadores.xml";
            string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            FrmJugadores.rutaArchivo = Path.Combine(rutaEscritorio, nombreArchivo);
        }

        public FrmJugadores()//List<JugadorDeVoley> listaDeJugadores)
        {
            InitializeComponent();
            //this.listaDeJugadores = listaDeJugadores;
            //this.frmNuevoJugador = new FrmNuevoJugador();
            this.openFileDialog = new OpenFileDialog();
            this.openFileDialog.Filter = "Archivo XML|*.xml|Archivo JSON|*.json";
            this.saveFileDialog = new SaveFileDialog();
            this.saveFileDialog.Filter = "Archivo XML|*.xml|Archivo JSON|*.json";
            this.extXml = new ExtXml<List<JugadorDeVoley>>(); // se instacia la clase generica
            this.extJson = new ExtJson<List<JugadorDeVoley>>();

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
                this.listaDeJugadores.Add(this.frmNuevoJugador.NuevoJugador);
                this.RefrescarDataGrid();

            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!File.Exists(this.UltimoArchivo))
            {
                this.GuardarComo();
            }
            else
            {
                this.Guardar();
            }
            //this.GuardarDatos();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = DialogResult.Yes;
            //if (this.listaDeJugadores.Count > 0)
            //{
            //    confirmacion = MessageBox.Show("Solo se cargaran los jugadores con distinto ID, nombre, apellido y nacionalidad", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //}
            if (confirmacion == DialogResult.Yes && this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.ultimoArchivo = this.openFileDialog.FileName;

                try
                {
                    List<JugadorDeVoley> listaAux = new List<JugadorDeVoley>();
                    switch (Path.GetExtension(this.UltimoArchivo))
                    {
                        case ".xml":
                            listaAux = this.extXml.Leer(UltimoArchivo);// metodo de la clase generica


                            break;
                        case ".json":
                            listaAux = this.extJson.Leer(UltimoArchivo);// metodo de la clase generica
                            break;
                    }
                    CopyWithNewId(listaAux);
                    this.RefrescarDataGrid();
                }
                catch (Exception ex)
                {
                    this.lblMensaje.ForeColor = System.Drawing.Color.Red;
                    this.lblMensaje.Text = this.lblMensaje.Text = ex.Message; //"ERROR: no se pudo cargar los datos.";
                    this.lblMensaje.Visible = true;
                }
            }
        }

        /// <summary>
        /// Copia los jugadores de la lista pasada como parametro a la 
        /// lista de jugadores del form asignandole un id valido, solo si son diferente persona.
        /// </summary>
        /// <param name="listaAux"> lista a copiar</param>
        private void CopyWithNewId(List<JugadorDeVoley> listaAux)
        {
            foreach (JugadorDeVoley item in listaAux) // esto podria hacerse en un hilo 
            {
                if (!this.listaDeJugadores.Contains(item))
                {
                    item.Id = item.GenerarId(this.listaDeJugadores); // le cambio el id a uno valido para la lista en la que lo voy a añadir
                    this.listaDeJugadores.Add(item);
                }
            }
        }

        private void dataGridJugadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) // hago visible los botones de modificar y eliminar
            {
                this.btnModificar.Visible = true;
                this.btnEliminar.Visible = true;
                // Recuperar del data grid
                this.jugadorModificar = (JugadorDeVoley)dataGridJugadores.CurrentRow.DataBoundItem;
                // Modificar(auxJugador); // cuando clickee el boton modificar
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.AbrirFrmNuevoJugador() == DialogResult.OK)
            {
                this.lblMensaje.Visible = true;
                this.lblMensaje.ForeColor = System.Drawing.Color.Black;
                this.lblMensaje.Text = "Jugador Modificado Correctamente.";
                // this.listaDeJugadores.Add(this.frmNuevoJugador.NuevoJugador);
                this.RefrescarDataGrid();

            }
        }

        #region Metodos privados
        private DialogResult AbrirFrmNuevoJugador()
        {
            int id = new JugadorDeVoley().GenerarId(this.listaDeJugadores);
            this.lblMensaje.Visible = false;
            this.frmNuevoJugador = new FrmNuevoJugador(id);
            return this.frmNuevoJugador.ShowDialog();
        }

        /// <summary>
        /// Actualiza el data grid solo si la lista de jugadores tiene algo 
        /// </summary>
        private void RefrescarDataGrid()
        {
            if (this.listaDeJugadores.Count > 0)
            {
                this.dataGridJugadores.DataSource = null;
                this.dataGridJugadores.DataSource = this.listaDeJugadores;
            }
        }

        //private void GuardarDatos() hecho en una libreria de clase
        //{
        //    try
        //    {
        //        using (XmlTextWriter writer = new XmlTextWriter(rutaArchivo, Encoding.UTF8))
        //        {
        //            XmlSerializer ser = new XmlSerializer((typeof(List<JugadorDeVoley>)));
        //            ser.Serialize(writer, listaDeJugadores);
        //            this.lblMensaje.Visible = true;
        //            this.lblMensaje.ForeColor = System.Drawing.Color.Black;
        //            this.lblMensaje.Text = "Los datos se guardaron correctamente.";

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        this.lblMensaje.ForeColor = System.Drawing.Color.Red;
        //        this.lblMensaje.Text = e.Message; //"ERROR: no se pudo guardar los datos.";
        //        this.lblMensaje.Visible = true;
        //    }
        //}

        //private void CargarDatos()
        //{
        //        using (XmlTextReader reader = new XmlTextReader(rutaArchivo))
        //        {
        //            XmlSerializer ser = new XmlSerializer((typeof(List<JugadorDeVoley>)));
        //            this.listaDeJugadores = ser.Deserialize(reader) as List<JugadorDeVoley>;
        //            this.lblMensaje.Visible = true;
        //            this.lblMensaje.ForeColor = System.Drawing.Color.Black;
        //            this.lblMensaje.Text = "Los datos se cargaron correctamente.";
        //        }
        //

        /// <summary>
        /// Guarda un archivo permitiendo escoger el lugar y nombre con el que se guardara.
        /// </summary>
        private void GuardarComo()
        {
            this.UltimoArchivo = SeleccionarUbicacionGuardado();

            try
            {
                switch (Path.GetExtension(this.UltimoArchivo))
                {
                    case ".json":
                        this.extJson.GuardarComo(this.UltimoArchivo, this.listaDeJugadores);
                        break;
                    case ".xml":
                        this.extXml.GuardarComo(this.UltimoArchivo, this.listaDeJugadores);
                        break;
                }
            }
            catch (Exception e)
            {
                this.lblMensaje.ForeColor = System.Drawing.Color.Red;
                this.lblMensaje.Text = e.Message; //"ERROR: no se pudo guardar los datos.";
                this.lblMensaje.Visible = true;
            }
        }

        /// <summary>
        /// Guarda un archvio ya guardado anteriormente.
        /// </summary>
        private void Guardar()
        {
            try
            {
                switch (Path.GetExtension(this.UltimoArchivo))
                {
                    case ".json":
                        this.extJson.Guardar(this.UltimoArchivo, this.listaDeJugadores);
                        break;
                    case ".xml":
                        this.extXml.Guardar(this.UltimoArchivo, this.listaDeJugadores);
                        break;
                }
            }
            catch (Exception e)
            {
                this.lblMensaje.ForeColor = System.Drawing.Color.Red;
                this.lblMensaje.Text = e.Message; //"ERROR: no se pudo guardar los datos.";
                this.lblMensaje.Visible = true;
            }
        }

        private string SeleccionarUbicacionGuardado()
        {
            string retorno = string.Empty;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                retorno = this.saveFileDialog.FileName;
            }
            return retorno;
        }

        #endregion


    }
}
