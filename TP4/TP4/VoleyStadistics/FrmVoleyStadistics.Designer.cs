﻿
namespace FormVoleyStadistics
{
    partial class FrmVoleyStadistics
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVoleyStadistics));
            this.btnJugadores = new System.Windows.Forms.Button();
            this.btnEstadisticas = new System.Windows.Forms.Button();
            this.btnClubes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnJugadores
            // 
            this.btnJugadores.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnJugadores.Location = new System.Drawing.Point(12, 12);
            this.btnJugadores.Name = "btnJugadores";
            this.btnJugadores.Size = new System.Drawing.Size(281, 61);
            this.btnJugadores.TabIndex = 0;
            this.btnJugadores.Text = "Jugadores";
            this.btnJugadores.UseVisualStyleBackColor = true;
            this.btnJugadores.Click += new System.EventHandler(this.btnJugadores_Click);
            // 
            // btnEstadisticas
            // 
            this.btnEstadisticas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEstadisticas.Location = new System.Drawing.Point(12, 146);
            this.btnEstadisticas.Name = "btnEstadisticas";
            this.btnEstadisticas.Size = new System.Drawing.Size(281, 61);
            this.btnEstadisticas.TabIndex = 2;
            this.btnEstadisticas.Text = "Estadisticas";
            this.btnEstadisticas.UseVisualStyleBackColor = true;
            // 
            // btnClubes
            // 
            this.btnClubes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClubes.Location = new System.Drawing.Point(12, 79);
            this.btnClubes.Name = "btnClubes";
            this.btnClubes.Size = new System.Drawing.Size(281, 61);
            this.btnClubes.TabIndex = 4;
            this.btnClubes.Text = "Clubes";
            this.btnClubes.UseVisualStyleBackColor = true;
            this.btnClubes.Click += new System.EventHandler(this.btnClubes_Click);
            // 
            // FrmVoleyStadistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 217);
            this.Controls.Add(this.btnClubes);
            this.Controls.Add(this.btnEstadisticas);
            this.Controls.Add(this.btnJugadores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmVoleyStadistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voley Stadistics";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnJugadores;
        private System.Windows.Forms.Button btnEstadisticas;
        private System.Windows.Forms.Button btnClubes;
    }
}

