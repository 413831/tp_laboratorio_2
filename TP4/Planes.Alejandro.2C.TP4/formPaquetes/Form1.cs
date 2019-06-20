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

namespace formPaquetes
{
    public partial class Form1 : Form
    {
        private Correo correo;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.correo = new Correo();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);

            try
            {
                paquete.InformaEstado += this.paq_InformaEstado; // Asocio el método al manejador de eventos
                this.correo += paquete;
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado); // Llamo a delegado de clase Paquete
                this.Invoke(d, new object[] { sender, e }); // Invoco al método actual a través del delegado
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        private void ActualizarEstados()
        {
            lstEstadoIngresado.Text = "";
            lstEstadoEnViaje.Text = "";
            lstEstadoEntregado.Text = "";

            foreach(Paquete paquete in this.correo.Paquetes)
            {
                switch(paquete.Estado)
                {
                    case Paquete.EEstado.Ingresado :
                        lstEstadoIngresado.Text += paquete.ToString();
                        break;
                    case Paquete.EEstado.EnViaje :
                        lstEstadoEnViaje.Text += paquete.ToString();
                        break;
                    case Paquete.EEstado.Entregado :
                        lstEstadoEntregado.Text += paquete.ToString();
                        break;
                }
            }
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            string rutaArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\salida.txt";

            if(!Object.Equals(elemento,null))
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento); // REVISAR CON ToString()

                try
                {
                    rtbMostrar.Text.Guardar(rutaArchivo);
                }
                catch(Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }
    }
}
