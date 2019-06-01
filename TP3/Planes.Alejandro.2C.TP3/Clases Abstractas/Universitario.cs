using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
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

            datos.AppendLine(this.legajo.ToString());

            return datos.ToString();
        }

        public static bool operator !=(Universitario universitarioUno, Universitario universitarioDos)
        {
            return !(universitarioUno == universitarioDos);
        }

        public static bool operator ==(Universitario universitarioUno, Universitario universitarioDos)
        {
            if(universitarioUno.legajo == universitarioDos.legajo && universitarioUno.Dni == universitarioDos.Dni &&
               universitarioUno.GetType() == universitarioDos.GetType())
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
        {

        }

        #endregion
    }
}
