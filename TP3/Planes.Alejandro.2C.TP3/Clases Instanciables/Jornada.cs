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

        public static bool Guardar(Jornada jornada)
        {
            Texto archivo = new Texto();

            try
            {
                archivo.Guardar("Jornada.txt",jornada.ToString());
                return true;
            }
            catch(NullReferenceException exception)
            {
                throw new ArchivosException(exception);
            }
            catch(ArgumentException e)
            {
                throw new ArchivosException(e);
            }
        }

        public string Leer()
        {
            Texto archivo = new Texto();
            String datosArchivo;

            archivo.Leer("Jornada.txt", out datosArchivo);

            return datosArchivo;
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


        public static bool operator !=(Jornada jornada, Alumno alumno)
        {
            return !(jornada == alumno);
        }

        public static bool operator ==(Jornada jornada, Alumno alumno)
        {
            if(alumno == jornada.clase)
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

            datos.AppendFormat("CLASE DE {0} ",this.clase.ToString());
            datos.AppendFormat("POR {0}",this.instructor.ToString());

            foreach(Alumno alumno in this.alumnos)
            {
                datos.AppendFormat("\nALUMNO: {0}",alumno.ToString());
            }
            return datos.ToString();
        }

        #endregion

    }
}