using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public class Universitario : Persona
    {
        private int legajo;

        #region Métodos

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        protected abstract string MostrarDatos()
        {

        }

        public static bool operator !=(Universitario universitarioUno, Universitario universitarioDos)
        {

        }

        public static bool operator ==(Universitario universitarioUno, Universitario universitarioDos)
        {

        }
        
        protected abstract string ParticiparEnClase()
        {

        }

        public Universitario()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {

        }

        #endregion
    }
}
