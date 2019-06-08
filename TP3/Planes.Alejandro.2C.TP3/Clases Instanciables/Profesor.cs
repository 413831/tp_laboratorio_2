using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        static Random random;

        #region Métodos

        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0,3));
        }

        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder("");
                                                         // Muestro apellido, nombre y nacionalidad
            datos.AppendLine(base.MostrarDatos());      // Muestro el legajo
            datos.AppendLine(this.ParticiparEnClase()); // Muestro las clases del día

            return datos.ToString();
        }

        public static bool operator !=(Profesor profesor, Universidad.EClases clase)
        {
            return !(profesor == clase);
        }

        public static bool operator ==(Profesor profesor, Universidad.EClases clase)
        {
            if(profesor.clasesDelDia.Contains(clase))
            {
                return true;
            }
            return false;
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder clases = new StringBuilder("CLASES DEL DÍA ");

            foreach(Universidad.EClases clase in this.clasesDelDia)
            {
                clases.Append("\n"+clase.ToString());
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
            this.clasesDelDia = new Queue<Universidad.EClases>();

            for(int i = 2; i > 0;i--)
            {
                this._randomClases();
            }
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