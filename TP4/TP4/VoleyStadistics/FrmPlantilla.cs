using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IO;
using Entidades;
using System.Threading;

namespace FormVoleyStadistics
{
    public partial class FrmPlantilla: Form
    {
        private static string rutaArchivo;

        // private FrmNuevo frmNuevo; // atributo de cada hijo

        protected OpenFileDialog openFileDialog;
        protected SaveFileDialog saveFileDialog;
        protected string ultimoArchivo;
        protected Task taskMostrar;
        //// private T jugadorModificar;
        //// private static int maxId;

        protected string UltimoArchivo
        {
            get
            {
                return ultimoArchivo;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.ultimoArchivo = value;
                }
            }
        }

        //    // public static int MaxId { get => maxId; set => maxId = value; }

        static FrmPlantilla()
        {
            string nombreArchivo = "lista.xml";
            string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            FrmPlantilla.rutaArchivo = Path.Combine(rutaEscritorio, nombreArchivo);
        }

        public FrmPlantilla()
        {
            InitializeComponent();
            this.openFileDialog = new OpenFileDialog();
            this.openFileDialog.Filter = "Archivo XML|*.xml|Archivo JSON|*.json";
            this.saveFileDialog = new SaveFileDialog();
            this.saveFileDialog.Filter = "Archivo XML|*.xml|Archivo JSON|*.json";

        }

        //protected void btnGuardar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!File.Exists(this.UltimoArchivo))
        //        {
        //            this.GuardarComo();
        //        }
        //        else
        //        {
        //            this.Guardar();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.lblMensaje.ForeColor = System.Drawing.Color.Red;
        //        this.lblMensaje.Text = ex.Message; //"ERROR: no se pudo guardar los datos.";
        //        this.lblMensaje.Visible = true;
        //    }
        //    this.lblMensaje.ForeColor = System.Drawing.Color.Black;
        //    this.lblMensaje.Text = "Guardado correctamente.";
        //    this.lblMensaje.Visible = true;
        //    //this.GuardarDatos();
        //}

        ////    protected virtual void btnCargar_Click(object sender, EventArgs e)
        ////    {
        ////        DialogResult confirmacion = DialogResult.Yes;
        ////        //if (this.lista.Count > 0)
        ////        //{
        ////        //    confirmacion = MessageBox.Show("Solo se cargaran los jugadores con distinto ID, nombre, apellido y nacionalidad", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        ////        //}
        ////        if (confirmacion == DialogResult.Yes && this.openFileDialog.ShowDialog() == DialogResult.OK)
        ////        {
        ////            this.ultimoArchivo = this.openFileDialog.FileName;

        ////            try
        ////            {
        ////                List<T> listaAux = new List<T>();
        ////                switch (Path.GetExtension(this.UltimoArchivo))
        ////                {
        ////                    case ".xml":
        ////                        listaAux = this.extXml.Leer(UltimoArchivo);// metodo de la clase generica


        ////                        break;
        ////                    case ".json":
        ////                        listaAux = this.extJson.Leer(this.UltimoArchivo);// metodo de la clase generica
        ////                        break;
        ////                }
        ////                // CopyWithNewId(listaAux); // COPIA LOS JUGADORES DE LA LISTA, QUE NO SEAN LA MISMA PERSONA, DEL ARCHIVO A LA BASE DE DATOS Y A LA LISTA DEL FORM
        ////                //this.RefrescarDataGrid();
        ////            }
        ////            catch (Exception ex)
        ////            {
        ////                this.lblMensaje.ForeColor = System.Drawing.Color.Red;
        ////                this.lblMensaje.Text = this.lblMensaje.Text = ex.Message; //"ERROR: no se pudo cargar los datos.";
        ////                this.lblMensaje.Visible = true;
        ////            }
        ////        }
        ////    }

        protected string SeleccionarUbicacionGuardado()
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
        protected void MostrarLbl(string texto)
        {

            if (this.lblMensaje.InvokeRequired)
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

    }
}
