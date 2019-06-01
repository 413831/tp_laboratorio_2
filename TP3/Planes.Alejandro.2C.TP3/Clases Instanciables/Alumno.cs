using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
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

        #region Métodos

        public Alumno()
        {}

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder("");

            datos.AppendLine(this.claseQueToma.ToString());
            datos.AppendLine(this.estadoCuenta.ToString());

            return datos.ToString();
        }

        public static bool operator !=(Alumno alumno, Universidad.EClases clase)
        {
            if (alumno.claseQueToma != clase)
            {
                return true;
            }
            return false;
        }

        public static bool operator ==(Alumno alumno, Universidad.EClases clase)
        {
            if(alumno.claseQueToma == clase && alumno.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder clase = new StringBuilder("TOMA CLASE DE ");

            clase.Append(this.claseQueToma.ToString());

            return clase.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion
    }
}
