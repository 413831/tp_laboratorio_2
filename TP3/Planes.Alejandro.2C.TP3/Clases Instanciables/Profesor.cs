using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using Excepciones;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<EClases> clasesDelDia;
        private Random random;

        #region Métodos

        static void _randomClases()
        {

        }

        protected override string MostrarDatos()
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(Profesor profesor, EClases clase)
        {

        }

        public static bool operator ==(Profesor profesor, EClases clase)
        {

        }

        protected override string ParticiparEnClase()
        {
            throw new NotImplementedException();
        }

        public Profesor()
        {

        }

        private Profesor()
        {

        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }



        #endregion
    }
}
