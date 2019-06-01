using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        };

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

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

        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }

        #endregion

        #region Métodos

        public Universidad()
        {

        }

        public bool Guardar(Universidad dni)
        {

        }

        private string MostrarDatos(Universidad universidad)
        {

        }

        public static bool operator !=(Universidad universidad, Alumno alumno)
        {

        }

        public static bool operator !=(Universidad universidad, Profesor profesor)
        {

        }

        public static bool operator !=(Universidad universidad, EClases clase)
        {

        }

        public static bool operator ==(Universidad universidad, Alumno alumno)
        {

        }

        public static bool operator ==(Universidad universidad, Profesor profesor)
        {

        }

        public static bool operator ==(Universidad universidad, EClases clase)
        {

        }

        public static Universidad operator +(Universidad universidad, EClase clase)
        {

        }

        public static Universidad operator +(Universidad universidad, Alumno alumno)
        {

        }

        public static Universidad operator +(Universidad universidad, Profesor profesor)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }



        #endregion
    }
}
