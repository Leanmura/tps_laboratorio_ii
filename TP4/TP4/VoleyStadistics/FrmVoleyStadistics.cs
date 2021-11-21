﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

// si tira error con la modificacion de la base de datos, reiniciar el programa para actualizar ids

namespace FormVoleyStadistics
{
    public partial class FrmVoleyStadistics : Form
    {
        private FrmJugadores frmJugadores;
        public List<JugadorDeVoley> listaDeJugadores;
        public static int maxId;
        private FrmClubes frmClubes;

        static FrmVoleyStadistics()
        {
           FrmVoleyStadistics.maxId = 0;
         }

        public FrmVoleyStadistics()
        {
            InitializeComponent();
            this.frmJugadores = new FrmJugadores();//listaDeJugadores);
            this.frmJugadores.listaDeJugadores = JugadorDeVoley.ReadAll();//new List<JugadorDeVoley>();
            this.listaDeJugadores = this.frmJugadores.listaDeJugadores;

        }


        private void btnJugadores_Click(object sender, EventArgs e)
        {
            this.frmJugadores.ShowDialog();
            //AbrirFrmJugadores();//this.frmJugadores.listaDeJugadores);
        }

        private void btnClubes_Click(object sender, EventArgs e)
        {
            this.frmClubes = new FrmClubes(this.listaDeJugadores);
            this.frmClubes.ShowDialog();
        }

        #region Metodos privados
        //private DialogResult AbrirFrmJugadores()//List<JugadorDeVoley> listaDeJugadores)
        //{
        //    return this.frmJugadores.ShowDialog();
        //}
        #endregion
    }
}
