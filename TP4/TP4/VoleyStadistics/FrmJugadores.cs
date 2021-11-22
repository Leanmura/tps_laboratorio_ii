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
        private static int maxId;

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

        public static int MaxId { get => maxId; set => maxId = value; }

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
            if (FrmJugadores.MaxId == 0)
            {
                FrmJugadores.MaxId = new JugadorDeVoley().GenerarId(this.listaDeJugadores, 0);
            }
            this.RefrescarDataGrid();

            //this.dataGridJugadores.DataSource = this.listaDeJugadores;
        }

        private void btnNuevoJugador_Click(object sender, EventArgs e)
        {
            if (this.AbrirFrmNuevoJugador() == DialogResult.OK)
            {
                if (this.listaDeJugadores.Contains(this.frmNuevoJugador.NuevoJugador))
                {
                    MessageBox.Show("Error. Ya existe un jugador identico.");
                }
                else
                {
                    this.lblMensaje.Visible = true;
                    this.lblMensaje.ForeColor = System.Drawing.Color.Black;
                    this.lblMensaje.Text = "Jugador Creado Correctamente.";
                    FrmJugadores.MaxId = this.frmNuevoJugador.NuevoJugador.Id + 1;
                    this.listaDeJugadores.Add(this.frmNuevoJugador.NuevoJugador);
                    if (!JugadorDeVoley.Insert(this.frmNuevoJugador.NuevoJugador))
                    {
                        this.lblMensaje.ForeColor = System.Drawing.Color.Red;
                        this.lblMensaje.Text = "Error no se pudo guardar en la base de datos."; // podria ser en otro hilo, dejandolo por 3 segundos
                    }

                }
                this.RefrescarDataGrid();

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(this.UltimoArchivo))
                {
                    this.GuardarComo();
                }
                else
                {
                    this.Guardar();
                }
            }
            catch (Exception ex)
            {
                this.lblMensaje.ForeColor = System.Drawing.Color.Red;
                this.lblMensaje.Text = ex.Message; //"ERROR: no se pudo guardar los datos.";
                this.lblMensaje.Visible = true;
            }
            this.lblMensaje.ForeColor = System.Drawing.Color.Black;
            this.lblMensaje.Text = "Guardado correctamente.";
            this.lblMensaje.Visible = true;
            //this.GuardarDatos();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {

            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
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
                            listaAux = this.extJson.Leer(this.UltimoArchivo);// metodo de la clase generica
                            break;
                    }
                    CopyWithNewId(listaAux); // COPIA LOS JUGADORES DE LA LISTA, QUE NO SEAN LA MISMA PERSONA, DEL ARCHIVO A LA BASE DE DATOS Y A LA LISTA DEL FORM
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


        private void dataGridJugadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) // hago visible los botones de modificar y eliminar
            {
                this.btnModificar.Visible = true;
                this.btnEliminar.Visible = true;
                // Recuperar del data grid
                // busco el indice de la lista, de la persona que es igual a la seleccionada en el datagrid
                int indice = this.listaDeJugadores.IndexOf((JugadorDeVoley)dataGridJugadores.CurrentRow.DataBoundItem);
                this.jugadorModificar = this.listaDeJugadores[indice]; // guardo la referencia de este jugador
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            if (this.AbrirFrmModificarJugador(this.jugadorModificar) == DialogResult.OK)
            {
                this.lblMensaje.Visible = true;
                this.lblMensaje.ForeColor = System.Drawing.Color.Black;
                this.lblMensaje.Text = "Jugador Modificado Correctamente.";
                if (!JugadorDeVoley.Update(this.jugadorModificar))
                {
                    MessageBox.Show("Error no se pudo actualizar la base de datos.");
                }
                // this.listaDeJugadores.Add(this.frmNuevoJugador.NuevoJugador);
                this.RefrescarDataGrid();

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.listaDeJugadores.Count == 1)
            {
                MessageBox.Show("La lista no puede quedar vacia.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Esta seguro que quiere eliminar este jugador?", "Mensaje de confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.listaDeJugadores.Remove(this.jugadorModificar);
                    this.lblMensaje.Visible = true;
                    this.lblMensaje.ForeColor = System.Drawing.Color.Black;
                    this.lblMensaje.Text = "Jugador Borrado Correctamente.";
                    if (!JugadorDeVoley.Delete(this.jugadorModificar))
                    {
                        MessageBox.Show("Error no se pudo actualizar la base de datos.");
                    }

                    this.RefrescarDataGrid();
                }

            }
        }

        #region Metodos privados
        /// <summary>
        /// Copia los jugadores de la lista pasada como parametro a la 
        /// lista de jugadores del form (y tamb a la base de datos) 
        /// asignandole un id valido, solo si son diferente persona.
        /// </summary>
        /// <param name="listaAux"> lista a copiar</param>
        private void CopyWithNewId(List<JugadorDeVoley> listaAux)
        {
            List<JugadorDeVoley> dataBase = JugadorDeVoley.ReadAll();
            foreach (JugadorDeVoley item in listaAux)
            {

                    if (!this.listaDeJugadores.Contains(item))
                    {
                        if (!JugadorDeVoley.Insert(item)) // los añado a la base de datos
                        {
                            MessageBox.Show("Error no se pudo guardar en la base de datos.");
                        }
                        dataBase = JugadorDeVoley.ReadAll();
                        int index;
                        index = dataBase.IndexOf(item);
                        if (index != -1)
                        {
                            this.listaDeJugadores.Add(dataBase[index]);

                        }
                    }
                //item.Id = item.GenerarId(this.listaDeJugadores, FrmJugadores.MaxId); // le cambio el id a uno valido para la lista en la que lo voy a añadir
                //this.listaDeJugadores.Add(item); // los añado a la lista del formulario

            }
        }

        private DialogResult AbrirFrmNuevoJugador()
        {
            int id = FrmJugadores.MaxId; //new JugadorDeVoley().GenerarId(this.listaDeJugadores, FrmJugadores.maxId);
            this.lblMensaje.Visible = false;
            this.frmNuevoJugador = new FrmNuevoJugador(id);
            return this.frmNuevoJugador.ShowDialog();
        }

        // encapsulo la instanciacion de FrmNuevoJugador(jugadorAModificar), para no confundir. creo que deberia hacer un nuevo form que herede de este o cambiarle el nombre
        private DialogResult AbrirFrmModificarJugador(JugadorDeVoley jugadorAModificar)
        {
            this.lblMensaje.Visible = false;
            this.frmNuevoJugador = new FrmNuevoJugador(jugadorAModificar);
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
                this.dataGridJugadores.Columns["Nombre"].DisplayIndex = 1;
                this.dataGridJugadores.Columns["Apellido"].DisplayIndex = 2;
                this.dataGridJugadores.Columns["Id"].HeaderText = "ID";
                this.dataGridJugadores.Columns["FechaNacimiento"].HeaderText = "Fecha de nacimiento";
                this.dataGridJugadores.Columns["PaisDeNacimiento"].HeaderText = "Pais";
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

        /// <summary>
        /// Guarda un archvio ya guardado anteriormente.
        /// </summary>
        private void Guardar()
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
