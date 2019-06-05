using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

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
        private List<Jornada> jornadas;
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
                return this.jornadas;
            }
            set
            {
                this.jornadas = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return this.jornadas[i];
            }
            set
            {
                this.jornadas[i] = value;
            }
        }

        #endregion

        #region Métodos

        public Universidad()
        {

        }

        public bool Guardar(Universidad universidad)
        {
            Xml<string> exportarXml = new Xml<string>();

            if(exportarXml.Guardar("Universidad.xml", universidad.ToString()))
            {
                return true;
            }
            return false;
        }

        public bool Leer(string archivo, out Universidad datos)
        {
            Xml<Universidad> importarXml = new Xml<Universidad>();

            if (importarXml.Leer(archivo,out datos))
            {
                return true;
            }
            return false;
        }

        private static string MostrarDatos(Universidad universidad)
        {
            StringBuilder datos = new StringBuilder("");

            foreach(Profesor profesor in universidad.profesores)
            {
                datos.AppendLine(profesor.ToString());
            }

            foreach(Alumno alumno in universidad.alumnos)
            {
                datos.AppendLine(alumno.ToString());
            }

            foreach(Jornada jornada in universidad.jornadas)
            {
                datos.AppendLine(jornada.ToString());
            }
            return datos.ToString();        
        }

        public static bool operator !=(Universidad universidad, Alumno alumno)
        {
            return !(universidad == alumno);
        }

        public static bool operator !=(Universidad universidad, Profesor profesor)
        {
            return !(universidad == profesor);
        }

        public static Profesor operator !=(Universidad universidad, EClases clase)
        {
            foreach(Profesor profesor in universidad.profesores)
            {
                if(profesor != clase)
                {
                    return profesor;
                }
            }
            throw new SinProfesorException();
        }

        public static bool operator ==(Universidad universidad, Alumno alumno)
        {
            foreach(Alumno auxiliarAlumno in universidad.alumnos)
            {
                if(auxiliarAlumno == alumno)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator ==(Universidad universidad, Profesor profesor)
        {
            foreach(Profesor auxiliarProfesor in universidad.profesores)
            {
                if(auxiliarProfesor == profesor)
                {
                    return true;
                }
            }
            return false;
        }

        public static Profesor operator ==(Universidad universidad, EClases clase)
        {
            foreach(Profesor profesor in universidad.profesores)
            {
                if(profesor == clase)
                {
                    return profesor;
                }
            }
            throw new SinProfesorException();
        }


        public static Universidad operator +(Universidad universidad, EClases clase)
        {
            Jornada jornada;

            foreach(Profesor profesor in universidad.profesores)
            {
                if(profesor == clase) // Busco 1 profesor que tenga esa clase
                {
                    jornada = new Jornada(clase,profesor); //Asigno el profesor a la jornada

                    foreach(Alumno alumno in universidad.alumnos) // Busco todos los alumnos inscriptos en la clase
                    {
                        if(alumno == clase)
                        {
                            jornada += alumno;
                        }
                    }
                    universidad.jornadas.Add(jornada);
                    break;                  
                }
            }
            return universidad;
        }

        public static Universidad operator +(Universidad universidad, Alumno alumno)
        {
            foreach(Alumno auxiliarAlumno in universidad.alumnos)
            {
                if(auxiliarAlumno != alumno)
                {
                    universidad.alumnos.Add(alumno);
                }
            }
            return universidad;
        }

        public static Universidad operator +(Universidad universidad, Profesor profesor)
        {
            foreach(Profesor auxiliarProfesor in universidad.profesores)
            {
                if(auxiliarProfesor != profesor)
                {
                    universidad.profesores.Add(profesor);
                }
            }
            return universidad;
        }

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        #endregion
    }
}