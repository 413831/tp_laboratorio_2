using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        #region Métodos

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        public void FinEntregas()
        {
            foreach(Thread hilo in this.mockPaquetes)
            {
                if(hilo.IsAlive)
                {
                    hilo.Abort();
                }
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            string datos = "";

            foreach(Paquete paquete in ((Correo)elementos).Paquetes)
            {
                datos += String.Format("{0} para {1} ({2})", paquete.TrackingID, paquete.DireccionEntrega, paquete.Estado.ToString());
            }
            return datos;
        }

        public static Correo operator + (Correo correo, Paquete paquete)
        {
            Thread hiloMock;

            foreach(Paquete paquetito in correo.Paquetes)
            {
                if(paquete == paquetito)
                {
                    throw new TrackingIdRepetidoException("Tracking ID Repetido.");
                }
            }

            hiloMock = new Thread(paquete.MockCicloDeVida); // Creo el hilo del mock del paquete
            hiloMock.Start(); // Inicio el hilo del mock del paquete

            correo.Paquetes.Add(paquete); // Agrego el paquete al listado de correo
            correo.mockPaquetes.Add(hiloMock); // Agrego el hilo del método del paquete
            return correo;
        }
        #endregion
    }
}
