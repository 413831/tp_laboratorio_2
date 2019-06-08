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
        private Queue<Universidad.EClases> clasesDelDia;
        static Random random;

        #region Métodos

        static void _randomClases()
        {
            Universidad.EClases random.Next(0, 3)];
        }

        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder("");

            datos.AppendLine(base.MostrarDatos());

            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                datos.AppendLine(clase.ToString());
            }
            return datos.ToString();
        }

        public static bool operator !=(Profesor profesor, Universidad.EClases clase)
        {

        }

        public static bool operator ==(Profesor profesor, Universidad.EClases clase)
        {

        }

        protected override string ParticiparEnClase()
        {
            StringBuilder clases = new StringBuilder("CLASES DEL DÍA ");

            foreach(Universidad.EClases clase in clasesDelDia)
            {
                clases.Append(clase.ToString());
            }
            return clases.ToString();
        }

        static Profesor()
        {
            random = new Random();
        }

        public Profesor()
        {

        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = 
        }

        public override string ToString()
        {
            StringBuilder datos = new StringBuilder("");

            datos.AppendLine(this.)
        }



        #endregion
    }
}
