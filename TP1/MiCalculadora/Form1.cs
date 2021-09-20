using Entidades;
using System;
using System.Text;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            return Calculadora.Operar(new Operando(numero1), new Operando(numero2), operador[0]);
        }

        private void Limpiar()
        {
            //this.txtNumero1.Text = "";
            this.txtNumero1.Clear();
            //this.txtNumero2.Text = "";
            this.txtNumero2.Clear();
            this.cmbOperador.SelectedIndex = 0;
            //this.lblResultado.Text = "";
            this.lblResultado.ResetText();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }


        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, (string)this.cmbOperador.SelectedItem);
            this.lblResultado.Text = resultado.ToString();
            StringBuilder sb = new StringBuilder();
            string operador = (string)cmbOperador.SelectedItem;
            if (txtNumero1.Text != "" && txtNumero2.Text != "" && lblResultado.Text != "")
            {
                if((string)cmbOperador.SelectedItem == " ")
                {
                    operador = "+";
                }
                sb.AppendFormat("{0} {1} {2} = {3}", txtNumero1.Text, operador, txtNumero2.Text, lblResultado.Text);
                lstOperaciones.Items.Add(sb.ToString());
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.No)
            {
                e.Cancel = true;
            }

        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando operando = new Operando();
            lblResultado.Text = operando.DecimalBinario(lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando operando = new Operando();
            lblResultado.Text = operando.BinarioDecimal(lblResultado.Text);
        }
    }
}
