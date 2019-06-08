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
                if(i < this.jornadas.Count)
                {
                    return this.jornadas[i];
                }
                return null;
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
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }

        public static bool Guardar(Universidad universidad)
        {
            Xml<string> exportarXml = new Xml<string>();

            if(exportarXml.Guardar("Universidad.xml", universidad.ToString()))
            {
                return true;
            }
            return false;
        }

        public static bool Leer(string archivo, out Universidad datos)
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

            foreach (Jornada jornada in universidad.Jornadas)
            {
                datos.AppendFormat("JORNADA: {0}",jornada.ToString());
            }

            foreach(Profesor profesor in universidad.Instructores)
            {
                datos.AppendLine(profesor.ToString());
            }

            foreach(Alumno alumno in universidad.Alumnos)
            {
                datos.AppendLine(alumno.ToString());
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
            foreach(Profesor profesor in universidad.Instructores)
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
            foreach(Alumno auxiliarAlumno in universidad.Alumnos)
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
            foreach(Profesor auxiliarProfesor in universidad.Instructores)
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
            foreach(Profesor profesor in universidad.Instructores)
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

            foreach(Profesor profesor in universidad.Instructores)
            {
                if(profesor == clase) // Busco 1 profesor que tenga esa clase
                {
                    jornada = new Jornada(clase,profesor); //Asigno el profesor a la jornada

                    foreach(Alumno alumno in universidad.Alumnos) // Busco todos los alumnos inscriptos en la clase
                    {
                        if(alumno == clase)
                        {
                            jornada += alumno;
                        }
                    }
                    universidad.Jornadas.Add(jornada);
                    break;                  
                }
                else
                {
                    throw new SinProfesorException();
                }
            }
            return universidad;
        }

        public static Universidad operator +(Universidad universidad, Alumno alumno)
        {
            if(universidad != alumno)
            {
                universidad.Alumnos.Add(alumno);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return universidad;
        }

        public static Universidad operator +(Universidad universidad, Profesor profesor)
        {
            if(universidad != profesor)
            {
                universidad.Instructores.Add(profesor);
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