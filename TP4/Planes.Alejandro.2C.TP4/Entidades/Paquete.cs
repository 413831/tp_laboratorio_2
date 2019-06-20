using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object paquete, EventArgs e);
        public event DelegadoEstado InformaEstado;

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
            try
            {
                do
                {
                    this.Estado++; // REVISAR
                    Thread.Sleep(1000); // CAMBIAR A 4000
                    this.InformaEstado(this, null);

                } while (this.Estado != EEstado.Entregado);

                PaqueteDAO.Insertar(this);
            }
            catch(SqlException exception) // Lanzo otra vez la exception
            {
                throw exception;
            }
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}\n", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
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
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }

        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine(this.TrackingID);
            datos.AppendLine(this.DireccionEntrega);
            datos.AppendLine(this.Estado.ToString());

            return datos.ToString();
        }
        #endregion

    }
}
