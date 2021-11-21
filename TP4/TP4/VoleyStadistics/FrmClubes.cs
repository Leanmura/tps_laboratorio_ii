﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FormVoleyStadistics
{
    public partial class FrmClubes : FrmPlantilla
    {
        private FrmNuevoClub frmNuevoClub;
        public List<Club> listaClubes;
        private List<JugadorDeVoley> listaJugadores;
        private List<JugadorDeVoley> listaJugadoresDisponibles;
        private Club clubAModificar;
        //private ExtXml<List<Club>> extXml; // se crea atributo de clase generica
        //private ExtJson<List<Club>> extJson;

        public FrmClubes(List<JugadorDeVoley> listaJugadores)
        {
            InitializeComponent();
            this.listaJugadores = listaJugadores;
            this.listaJugadoresDisponibles = new List<JugadorDeVoley>();


            //this.extXml = new ExtXml<List<Club>>(); // se instacia la clase generica
            //this.extJson = new ExtJson<List<Club>>();
        }

        protected void FrmPlantilla_Load(object sender, EventArgs e)
        {
            this.listaClubes = new List<Club>();
            this.RefrescarDataGrid();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            bool add = true;

            foreach (JugadorDeVoley j in this.listaJugadores) // recorro la lista de jugadores
            {
                foreach (Club c in this.listaClubes) // recorro la lista de clubes
                {
                    if (c.Contains(j)) // me fijo que jugadores no estan en algun club
                    {
                        add = false;
                        break;
                    }
                }
                if(add)
                {
                   this.listaJugadoresDisponibles.Add(j);
                }
            }
            this.frmNuevoClub = new FrmNuevoClub(this.listaJugadoresDisponibles);
            if (this.frmNuevoClub.ShowDialog() == DialogResult.OK)
            {
                if (this.listaClubes.Contains(this.frmNuevoClub.NuevoClub))
                {
                    this.lblMensaje.ForeColor = System.Drawing.Color.Red;
                    this.lblMensaje.Text = "Error. El club ya esta en la lista."; // podria ser en otro hilo, dejandolo por 3 segundos
                }
                else
                {
                    this.lblMensaje.Visible = true;
                    this.lblMensaje.ForeColor = System.Drawing.Color.Black;
                    this.lblMensaje.Text = "Club Creado Correctamente.";
                    this.listaClubes.Add(this.frmNuevoClub.NuevoClub);
                }
                this.RefrescarDataGrid();

            }
        }

        protected void RefrescarDataGrid()
        {
            if (this.listaClubes.Count > 0)
            {
                this.dataGrid.DataSource = null;
                this.dataGrid.DataSource = this.listaClubes;
                this.dataGrid.Columns["nombre"].DisplayIndex = 0;
                this.dataGrid.Columns["nombre"].HeaderText = "Equipo";
                this.dataGrid.Columns["localidad"].HeaderText = "Localidad";
                this.dataGrid.Columns["liga"].HeaderText = "Liga";
            }
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) // hago visible los botones de modificar y eliminar
            {
                this.btnModificar.Visible = true;
                this.btnEliminar.Visible = true;
                // Recuperar del data grid
                // busco el indice de la lista, de la persona que es igual a la seleccionada en el datagrid
                int indice = this.listaClubes.IndexOf((Club)dataGrid.CurrentRow.DataBoundItem);
                this.clubAModificar = this.listaClubes[indice]; // guardo la referencia de este jugador
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.AbrirFrmModificarClub(this.clubAModificar) == DialogResult.OK)
            {
                this.lblMensaje.Visible = true;
                this.lblMensaje.ForeColor = System.Drawing.Color.Black;
                this.lblMensaje.Text = "Jugador Modificado Correctamente.";
                // this.listaDeJugadores.Add(this.frmNuevoJugador.NuevoJugador);
                this.RefrescarDataGrid();

            }
        }

        private DialogResult AbrirFrmModificarClub(Club clubAModificar)
        {
            this.lblMensaje.Visible = false;
            this.frmNuevoClub = new FrmNuevoClub(this.listaJugadoresDisponibles, clubAModificar);
            return this.frmNuevoClub.ShowDialog();
        }

        //protected override void GuardarComo()
        //{
        //    this.UltimoArchivo = SeleccionarUbicacionGuardado();
        //    switch (Path.GetExtension(this.UltimoArchivo))
        //    {
        //        case ".json":
        //            this.extJson.GuardarComo(this.UltimoArchivo, this.lista);
        //            break;
        //        case ".xml":
        //            this.extXml.GuardarComo(this.UltimoArchivo, this.lista);
        //            break;
        //    }
        //}

        //protected override void Guardar()
        //{
        //    switch (Path.GetExtension(this.UltimoArchivo))
        //    {
        //        case ".json":
        //            this.extJson.Guardar(this.UltimoArchivo, this.lista);
        //            break;
        //        case ".xml":
        //            this.extXml.Guardar(this.UltimoArchivo, this.lista);
        //            break;
        //    }
        //}
    }
}
