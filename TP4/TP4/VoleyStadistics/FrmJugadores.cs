using Entidades;
using IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormVoleyStadistics
{
    public partial class FrmJugadores : Form
    {
        #region Atributos

        public List<JugadorDeVoley> listaDeJugadores;
        private FrmNuevoJugador frmNuevoJugador;
        private JugadorDeVoley jugadorModificar;

        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private string ultimoArchivo;
        private ExtXml<List<JugadorDeVoley>> extXml; // se crea atributo de clase generica
        private ExtJson<List<JugadorDeVoley>> extJson;
        private static int maxId;

        private Task taskMostrar;
        #endregion

        #region Propiedades
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

        #endregion

        #region Constructor
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

        #endregion

        #region Manejadores
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
                    this.lblMensaje.ForeColor = System.Drawing.Color.Black;
                    this.taskMostrar = new Task(() => MostrarLbl("Jugador Creado Correctamente."));
                    this.taskMostrar.Start();
                    FrmJugadores.MaxId = this.frmNuevoJugador.NuevoJugador.Id + 1;
                    this.listaDeJugadores.Add(this.frmNuevoJugador.NuevoJugador);
                    if (!JugadorDeVoley.Insert(this.frmNuevoJugador.NuevoJugador))
                    {
                        this.lblMensaje.ForeColor = System.Drawing.Color.Red;
                        this.taskMostrar = new Task(() => MostrarLbl("Error no se pudo guardar en la base de datos."));
                        this.taskMostrar.Start();
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
                this.taskMostrar = new Task(() => MostrarLbl(ex.Message));
                this.taskMostrar.Start();

            }
            this.lblMensaje.ForeColor = System.Drawing.Color.Black;
            this.taskMostrar = new Task(() => MostrarLbl("Guardado correctamente."));
            this.taskMostrar.Start();

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
                    this.taskMostrar = new Task(() => MostrarLbl(ex.Message));
                    this.taskMostrar.Start();
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
                this.lblMensaje.ForeColor = System.Drawing.Color.Black;
                this.taskMostrar = new Task(() => MostrarLbl("Jugador Modificado Correctamente."));
                this.taskMostrar.Start();
                if (!JugadorDeVoley.Update(this.jugadorModificar))
                {
                    MessageBox.Show("Error no se pudo actualizar la base de datos.");
                }
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
                    this.lblMensaje.ForeColor = System.Drawing.Color.Black;
                    this.taskMostrar = new Task(() => MostrarLbl("Jugador Borrado Correctamente."));
                    this.taskMostrar.Start();
                    if (!JugadorDeVoley.Delete(this.jugadorModificar))
                    {
                        MessageBox.Show("Error no se pudo actualizar la base de datos.");
                    }

                    this.RefrescarDataGrid();
                }

            }
        }

        #endregion

        #region Metodos privados
        /// <summary>
        /// Copia los jugadores de la lista pasada como parametro a la 
        /// lista de jugadores del form (y tamb a la base de datos) 
        /// , solo si son diferente persona.
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
            }
        }

        private DialogResult AbrirFrmNuevoJugador()
        {
            int id = FrmJugadores.MaxId; //new JugadorDeVoley().GenerarId(this.listaDeJugadores, FrmJugadores.maxId);
            this.frmNuevoJugador = new FrmNuevoJugador(id);
            return this.frmNuevoJugador.ShowDialog();
        }

        // encapsulo la instanciacion de FrmNuevoJugador(jugadorAModificar), para no confundir. creo que deberia hacer un nuevo form que herede de este o cambiarle el nombre
        private DialogResult AbrirFrmModificarJugador(JugadorDeVoley jugadorAModificar)
        {
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

        /// <summary>
        /// abre una ventana, para seleccionar la carpeta de guardado
        /// </summary>
        /// <returns> retorna la direccion del archivo </returns>
        private string SeleccionarUbicacionGuardado()
        {
            string retorno = string.Empty;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                retorno = this.saveFileDialog.FileName;
            }
            return retorno;
        }

        /// <summary>
        /// Muestra el lblMensaje en un nuevo hilo por 3 segundos
        /// </summary>
        /// <param name="texto"> texto a mostrar en el label </param>
        private void MostrarLbl(string texto)
        {
           
            if(this.lblMensaje.InvokeRequired)
            {
                Action<string> delegado = this.MostrarLbl;
               // Callback d = new Callback(this.MostrarLbl);
                object[] objs = new object[] { texto };
                this.Invoke(delegado, objs);
                Thread.Sleep(3000);
                objs = new object[] { "" };
                this.Invoke(delegado, objs);
            }
            else
            {
                this.lblMensaje.Text = texto;
            }
        }
        #endregion
    }
}
