using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
using System.IO;

namespace Clases_Instanciables
{
    public class Jornada //REVISAR TODA LA CLASE
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

        public bool Guardar(Jornada jornada)
        {
            StreamWriter archivo = new StreamWriter("Jornada.txt");

            try
            {
                archivo.Write(jornada.ToString());
                archivo.Close();
            }
            catch(ArgumentException e)
            {

            }

        }

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
        : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        public string Leer()
        {
            StreamReader archivo = new StreamWriter("Jornada.txt");
            String datosJornada = archivo.ReadToEnd();

            archivo.Close();

            return datosJornada;
        }

        public static bool operator !=(Jornada jornada, Alumno alumno)
        {
            return !(jornada == alumno);
        }

        public static bool operator ==(Jornada jornada, Alumno alumno)
        {
            if(jornada.clase == alumno.claseQueToma)
            {
                return true;
            }
            return false;
        }

        public static Jornada operator +(Jornada jornada, Alumno alumno)
        {
            //Sobrecarga de == en clase base Universitario
            foreach(Alumno auxiliarAlumno in jornada.alumnos)
            {
                if(auxiliarAlumno != alumno)
                {
                    jornada.alumnos.Add(alumno);
                }
            }
            return jornada;
        }

        public override string ToString()
        {
            StringBuilder datos = new StringBuilder("");

            datos.AppendFormat("Clase: {0}",this.clase.ToString());
            datos.AppendFormat("Profesor: {0}",this.instructor.ToString());

            foreach(Alumno alumno in jornada.alumnos)
            {
                datos.AppendFormat("\nAlumno: {0}",alumno.ToString());
            }
            return datos.ToString();
        }

        #endregion

    }
}