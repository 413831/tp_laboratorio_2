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
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
        {

        }

        protected override string MostrarDatos()
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(Alumno alumno, Universidad.EClases clase)
        {

        }

        public static bool operator ==(Alumno alumno, Universidad.EClases clase)
        {

        }

        protected override string ParticiparEnClase()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        #endregion
    }
}
