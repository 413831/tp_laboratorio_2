using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        static int flagControl = 0;//Flag de control para conversion de decimal a binario

        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            txtNumero1.Text = "0";
            txtNumero2.Text = "0";
            cmbOperador.Text = "";
            lblResultado.Text = "0";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "0";
            txtNumero2.Text = "0";
            cmbOperador.Text = "";
            lblResultado.Text = "0";
            flagControl = 0; // Reset de variable estática
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero primerNumero;
            Numero segundoNumero;
            String operador = cmbOperador.Text;

            try
            {
                primerNumero = new Numero(txtNumero1.Text);
                segundoNumero = new Numero(txtNumero2.Text);
                lblResultado.Text = Convert.ToString(Calculadora.Operar(primerNumero, segundoNumero, operador));
            }
            catch(Exception exception)
            {
                lblResultado.Text = exception.Message;
                lblResultado.Text = "Valor inválido.";
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero resultadoDecimal = new Numero();
            
            if(flagControl != 1)
            {
                lblResultado.Text = resultadoDecimal.DecimalBinario(lblResultado.Text);
                flagControl = 1;
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero resultadoBinario = new Numero();

            if (flagControl != 2)
            {
                lblResultado.Text = resultadoBinario.BinarioDecimal(lblResultado.Text);
                flagControl = 2;
            }
        }

    }
}
