using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region Métodos

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder("");

            datos.AppendFormat(base.ToString());
            datos.AppendFormat("LEGAJO: {0}",this.legajo.ToString());

            return datos.ToString();
        }

        public static bool operator !=(Universitario universitarioUno, Universitario universitarioDos)
        {
            return !(universitarioUno == universitarioDos);
        }

        public static bool operator ==(Universitario universitarioUno, Universitario universitarioDos)
        {
            if(universitarioUno.GetType() == universitarioDos.GetType() && universitarioUno.legajo == universitarioDos.legajo
                || universitarioUno.Dni == universitarioDos.Dni)
            {
                return true;
            }
            return false;
        }

        protected abstract string ParticiparEnClase();

        public Universitario()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion
    }
}
