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
