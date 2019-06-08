using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        };

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public Universidad.EClases ClaseQueToma
        {
            get
            {
                return this.claseQueToma;
            }
            set
            {
                this.claseQueToma = value;
            }
        }

        public EEstadoCuenta EstadoCuenta
        {
            get
            {
                return this.estadoCuenta;
            }
            set
            {
                this.estadoCuenta = value;
            }
        }

        #region Métodos

        public Alumno()
        {}

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.ClaseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.EstadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder("");
                                                       // Muestro apellido, nombre y nacionalidad
            datos.AppendLine(base.MostrarDatos());  // Muestro legajo

            if(this.EstadoCuenta == 0)
            {
                datos.AppendFormat("ESTADO DE CUENTA: Cuenta al día"); // Muestro estado de cuenta
            }
            else
            {
                datos.AppendFormat("ESTADO DE CUENTA: {0}",this.EstadoCuenta.ToString()); // Muestro estado de cuenta
            }
            datos.AppendLine(this.ParticiparEnClase()); // Muestro clase que toma 

            return datos.ToString();
        }

        public static bool operator !=(Alumno alumno, Universidad.EClases clase)
        {
            if (alumno.ClaseQueToma != clase)
            {
                return true;
            }
            return false;
        }

        public static bool operator ==(Alumno alumno, Universidad.EClases clase)
        {
            if(alumno.ClaseQueToma == clase && alumno.EstadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder clase = new StringBuilder("\nTOMA CLASES DE ");

            clase.Append(this.ClaseQueToma.ToString());

            return clase.ToString();
        }

        public override string ToString()
        {
            StringBuilder datos = new StringBuilder("");

            datos.AppendLine(this.MostrarDatos());

            return datos.ToString();
        }

        #endregion
    }
}