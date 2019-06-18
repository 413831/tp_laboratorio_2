using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete
    {
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        };

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #region Propiedades

        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        #endregion

        #region Métodos

        public void MockCicloDeVida()
        {

            Thread.Sleep(4000);
            this.Estado++; // REVISAR
            this.InformaEstado(this, null);

        }
        /*
         * 2. MostrarDatos utilizará string.Format con el siguiente formato "{0} para {1}", p.trackingID,
            p.direccionEntrega para compilar la información del paquete.
        */
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}", this.TrackingID, this.DireccionEntrega);
        }

        public static bool operator !=(Paquete paqueteUno, Paquete paqueteDos)
        {
            return !(paqueteUno == paqueteDos);
        }

        public static bool operator ==(Paquete paqueteUno, Paquete paqueteDos)
        {
            if(paqueteUno.TrackingID == paqueteDos.TrackingID)
            {
                return true;
            }
            return false;
        }

        public Paquete(string direccionEntrega, string trackingID)
        {

        }

        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine(this.TrackingID);
            datos.AppendLine(this.DireccionEntrega);
            datos.AppendLine(this.Estado.ToString());

            return datos.ToString();
        }

        public delegate void DelegadoEstado(object paquete, EventArgs e);
        public event DelegadoEstado InformaEstado;


        #endregion

    }
}
