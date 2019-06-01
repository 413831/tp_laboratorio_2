using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase; // CONSULTAR ENUMERADO ECLASES
        private Profesor instructor;

        #region Propiedades

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        #endregion

        #region Métodos

        public bool Guardar(Jornada jornadad)
        {

        }

        private Jornada()
        {

        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
        {

        }

        public string Leer()
        {

        }

        public static bool operator !=(Jornada jornada, Alumno alumno)
        {

        }

        public static bool operator ==(Jornada jornada, Alumno alumno)
        {

        }

        public static Jornada operator +(Jornada jornada, Alumno alumno)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }

        #endregion

    }
}
