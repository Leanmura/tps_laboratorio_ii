
namespace FormVoleyStadistics
{
    partial class FrmNuevoClub
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbLocalidad = new System.Windows.Forms.ComboBox();
            this.lblLiga = new System.Windows.Forms.Label();
            this.txtLiga = new System.Windows.Forms.TextBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.dataGridDisponibles = new System.Windows.Forms.DataGridView();
            this.dataGridMiClub = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDisponibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMiClub)).BeginInit();
            this.SuspendLayout();
            // 
            // btnModificar
            // 
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.Size = new System.Drawing.Size(158, 25);
            this.lblNombre.Text = "Nombre del club ";
            // 
            // lblEquipo
            // 
            this.lblEquipo.Location = new System.Drawing.Point(822, 47);
            this.lblEquipo.Size = new System.Drawing.Size(71, 21);
            this.lblEquipo.Text = "Mi Club: ";
            // 
            // btnRemove
            // 
            this.btnRemove.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRemove.Location = new System.Drawing.Point(684, 217);
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAdd.Location = new System.Drawing.Point(684, 145);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(1021, 405);
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.FormattingEnabled = true;
            this.cmbLocalidad.Location = new System.Drawing.Point(101, 393);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(119, 23);
            this.cmbLocalidad.TabIndex = 30;
            this.cmbLocalidad.Text = "Localidad";
            // 
            // lblLiga
            // 
            this.lblLiga.AutoSize = true;
            this.lblLiga.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLiga.Location = new System.Drawing.Point(12, 364);
            this.lblLiga.Name = "lblLiga";
            this.lblLiga.Size = new System.Drawing.Size(46, 21);
            this.lblLiga.TabIndex = 31;
            this.lblLiga.Text = "Liga: ";
            // 
            // txtLiga
            // 
            this.txtLiga.Location = new System.Drawing.Point(64, 364);
            this.txtLiga.Name = "txtLiga";
            this.txtLiga.PlaceholderText = "Liga";
            this.txtLiga.Size = new System.Drawing.Size(246, 23);
            this.txtLiga.TabIndex = 32;
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLocalidad.Location = new System.Drawing.Point(12, 395);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(83, 21);
            this.lblLocalidad.TabIndex = 33;
            this.lblLocalidad.Text = "Localidad: ";
            // 
            // dataGridDisponibles
            // 
            this.dataGridDisponibles.AllowUserToResizeColumns = false;
            this.dataGridDisponibles.AllowUserToResizeRows = false;
            this.dataGridDisponibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridDisponibles.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDisponibles.Location = new System.Drawing.Point(12, 71);
            this.dataGridDisponibles.MultiSelect = false;
            this.dataGridDisponibles.Name = "dataGridDisponibles";
            this.dataGridDisponibles.ReadOnly = true;
            this.dataGridDisponibles.RowHeadersVisible = false;
            this.dataGridDisponibles.RowTemplate.Height = 25;
            this.dataGridDisponibles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridDisponibles.Size = new System.Drawing.Size(634, 285);
            this.dataGridDisponibles.TabIndex = 34;
            this.dataGridDisponibles.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridDisponibles_DataError);
            // 
            // dataGridMiClub
            // 
            this.dataGridMiClub.AllowUserToResizeColumns = false;
            this.dataGridMiClub.AllowUserToResizeRows = false;
            this.dataGridMiClub.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridMiClub.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridMiClub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMiClub.Location = new System.Drawing.Point(822, 71);
            this.dataGridMiClub.MultiSelect = false;
            this.dataGridMiClub.Name = "dataGridMiClub";
            this.dataGridMiClub.ReadOnly = true;
            this.dataGridMiClub.RowHeadersVisible = false;
            this.dataGridMiClub.RowTemplate.Height = 25;
            this.dataGridMiClub.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridMiClub.Size = new System.Drawing.Size(634, 285);
            this.dataGridMiClub.TabIndex = 35;
            // 
            // FrmNuevoClub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1468, 467);
            this.Controls.Add(this.dataGridMiClub);
            this.Controls.Add(this.dataGridDisponibles);
            this.Controls.Add(this.lblLocalidad);
            this.Controls.Add(this.txtLiga);
            this.Controls.Add(this.lblLiga);
            this.Controls.Add(this.cmbLocalidad);
            this.Name = "FrmNuevoClub";
            this.Text = "FrmClub";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmNuevoClub_FormClosing);
            this.Load += new System.EventHandler(this.FrmNuevoClub_Load);
            this.Controls.SetChildIndex(this.btnModificar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.txtNombre, 0);
            this.Controls.SetChildIndex(this.lblNombre, 0);
            this.Controls.SetChildIndex(this.lblDisponibles, 0);
            this.Controls.SetChildIndex(this.lblEquipo, 0);
            this.Controls.SetChildIndex(this.btnRemove, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.btnCrear, 0);
            this.Controls.SetChildIndex(this.cmbLocalidad, 0);
            this.Controls.SetChildIndex(this.lblLiga, 0);
            this.Controls.SetChildIndex(this.txtLiga, 0);
            this.Controls.SetChildIndex(this.lblLocalidad, 0);
            this.Controls.SetChildIndex(this.dataGridDisponibles, 0);
            this.Controls.SetChildIndex(this.dataGridMiClub, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDisponibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMiClub)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLocalidad;
        private System.Windows.Forms.Label lblLiga;
        protected System.Windows.Forms.TextBox txtLiga;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.DataGridView dataGridDisponibles;
        private System.Windows.Forms.DataGridView dataGridMiClub;
    }
}